using Vacinas.API.Model;

namespace Vacinas.API.Repositories
{
    public interface IConsultaRepository
    {
        Task<Relatorio> Get(string name, string cpf, string data);

        Task<IEnumerable<Relatorio>> GetRelatorios();
    }
}
