using Vacina.API.Context;
using Vacinas.API.Model;
using Newtonsoft.Json;
using Vacinas.API.Services.Vacina;
using Microsoft.EntityFrameworkCore;

namespace Vacinas.API.Repositories
{
    public class ConsultaRepository : IConsultaRepository
    {
        public readonly ConsultaContext _context;
        public ConsultaRepository()
        {
        }

        public ConsultaRepository(ConsultaContext context)
        {
            _context = context;
        }

        public async Task<Relatorio> Get(string name, string cpf, string dataSolicitacao)
        {
            //***** Tudo o que está comentado foi o que não havia sido feito

            var cliente = _context.Consulta.Where(c => c.Cpf == cpf).FirstOrDefault();
            //buscar cpf
            if (cliente == null)
            {
                _context.Consulta.Add(new Consulta {Nome = name, Cpf = cpf, DataSolicitacao = DateTime.Now });
                await _context.SaveChangesAsync();
            }
            
            var culture = new System.Globalization.CultureInfo("pt-br");
            string cpfValidado = string.Empty;
            DateTime dataSolicitada = DateTime.Now;

            if (DateTime.TryParseExact(dataSolicitacao, "dd/MM/yyyy", culture, System.Globalization.DateTimeStyles.None, out var dataDigitada)
                || DateTime.TryParseExact(dataSolicitacao, "ddMMyyyy", culture, System.Globalization.DateTimeStyles.None, out dataDigitada))
            {
                dataSolicitada = dataDigitada;
            }
            else
            {
                string textoErro = $"A data digitada não é válida. Por favor, tente novamente";
                throw new Exception(textoErro);
            }

            if (IsValidCPF(cpf))
            {
                cpfValidado = cpf.Replace(".", "").Replace("-", "");
            }

            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Post, "https://imunizacao-es.saude.gov.br/_search?scroll=1m");
            request.Headers.Add("Authorization", "Basic aW11bml6YWNhb19wdWJsaWM6cWx0bzV0JjdyX0ArI1Rsc3RpZ2k=");
            request.Headers.Add("User-Agent", "PostmanRuntime/7.31.3");
            request.Headers.Add("Connection", "keep-alive");
            var content = new StringContent("{\r\n    \"size\": 10000\r\n}", null, "application/json");
            request.Content = content;

            try
            {
                var response = await client.SendAsync(request);

                if (!response.IsSuccessStatusCode)
                {
                    string textoErro = $"Erro na chamada POST: {response.StatusCode} - {response.ReasonPhrase}";
                    throw new Exception(textoErro);
                }

                response.EnsureSuccessStatusCode();
                var jsonString = await response.Content.ReadAsStringAsync();
                var jsonObject = JsonConvert.DeserializeObject<ResponseVacina>(jsonString);
                var vacinasAplicadasRJ = jsonObject?.Hits.HitList.Where(c => c.Source.VacinaDataAplicacao.Date == dataSolicitada.Date)
                    .Where(i => i.Source.EstabelecimentoUf == "RJ");

                //fazer a busca e adiciona os dados dentro do relatorio e salva no banco

                var relatorio = new Relatorio
                {
                    DataSolicitacao = DateTime.Now,
                    DescricaoRelatorio = $"Relatório Vacinas Pfizer aplicadas no RJ_{dataSolicitada}",
                    QuantidadeTotalVacinados = vacinasAplicadasRJ.Count(),
                    SolicitanteId = cliente == null ? cliente.Id : _context.Consulta.Where(c => c.Cpf == cpf).FirstOrDefault().Id
                };

                // salvar o relatório no banco de dados com chave estrangeira sendo o id referente ao cpf

                _context.Relatorio.Add(relatorio);
                await _context.SaveChangesAsync();

                return relatorio;
            }
            catch (Exception e)
            {
                throw new Exception($"Ocorreu um erro: {e.Message}");
            }
        }
        public async Task<IEnumerable<Relatorio>> GetRelatorios()
        {
            //Precisa buscar todos os dados dos relatorios no banco e listar
            return await _context.Relatorio.ToListAsync();
        }

        private static bool IsValidCPF(string cpf)
        {
            int[] firstMultiplier = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] secondMultiplier = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            string temporaryCPF;
            string digit;
            int sum;
            int remainder;

            cpf = cpf?.Trim();
            cpf = cpf?.Replace(".", "").Replace("-", "");

            if (cpf.Length != 11)
                return false;

            if (cpf.All(x => x == cpf.First()))
                return false;

            if (cpf.Any(x => !Char.IsDigit(x)))
                return false;

            temporaryCPF = cpf.Substring(0, 9);

            sum = 0;

            for (int i = 0; i < 9; i++)
                sum += int.Parse(temporaryCPF[i].ToString()) * firstMultiplier[i];

            remainder = sum % 11;

            remainder = remainder < 2 ? 0 : 11 - remainder;

            digit = remainder.ToString();
            temporaryCPF += digit;
            sum = 0;

            for (int i = 0; i < 10; i++)
                sum += int.Parse(temporaryCPF[i].ToString()) * secondMultiplier[i];

            remainder = sum % 11;

            remainder = remainder < 2 ? 0 : 11 - remainder;

            digit += remainder.ToString();

            return cpf.EndsWith(digit);
        }
    }
}
