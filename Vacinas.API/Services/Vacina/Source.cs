using Newtonsoft.Json;
using System;
using System.Text.Json.Serialization;

namespace Vacinas.API.Services.Vacina
{
    public class Source
    {
        [JsonProperty("vacina_grupoAtendimento_nome")]
        [JsonPropertyName("vacina_grupoAtendimento_nome")]
        public string VacinaGrupoAtendimentoNome { get; set; }

        [JsonProperty("vacina_codigo")]
        [JsonPropertyName("vacina_codigo")]
        public string VacinaCodigo { get; set; }

        [JsonProperty("paciente_dataNascimento")]
        [JsonPropertyName("paciente_dataNascimento")]
        public string PacienteDataNascimento { get; set; }

        [JsonProperty("ds_condicao_maternal")]
        [JsonPropertyName("ds_condicao_maternal")]
        public string DsCondicaoMaternal { get; set; }

        [JsonProperty("paciente_endereco_nmPais")]
        [JsonPropertyName("paciente_endereco_nmPais")]
        public string PacienteEnderecoNMPais { get; set; }

        [JsonProperty("paciente_racaCor_valor")]
        [JsonPropertyName("paciente_racaCor_valor")]
        public string PacienteRacaCorValor { get; set; }

        [JsonProperty("sistema_origem")]
        [JsonPropertyName("sistema_origem")]
        public string SistemaOrigem { get; set; }

        [JsonProperty("paciente_id")]
        [JsonPropertyName("paciente_id")]
        public string PacienteId { get; set; }

        [JsonProperty("paciente_endereco_uf")]
        [JsonPropertyName("paciente_endereco_uf")]
        public string PacienteEnderecoUF { get; set; }

        [JsonProperty("paciente_idade")]
        [JsonPropertyName("paciente_idade")]
        public int PacienteIdade { get; set; }

        [JsonProperty("paciente_endereco_cep")]
        [JsonPropertyName("paciente_endereco_cep")]
        public string PacienteEnderecoCep { get; set; }

        [JsonProperty("estabelecimento_valor")]
        [JsonPropertyName("estabelecimento_valor")]
        public string EstabelecimentoValor { get; set; }

        [JsonProperty("estabelecimento_municipio_codigo")]
        [JsonPropertyName("estabelecimento_municipio_codigo")]
        public string EstabelecimentoMunicipioCodigo { get; set; }

        [JsonProperty("data_importacao_datalake")]
        [JsonPropertyName("data_importacao_datalake")]
        public DateTime DataImportacaoDataLake { get; set; }

        [JsonProperty("paciente_enumSexoBiologico")]
        [JsonPropertyName("paciente_enumSexoBiologico")]
        public string PacienteEnumSexoBiologico { get; set; }

        [JsonProperty("estabelecimento_municipio_nome")]
        [JsonPropertyName("estabelecimento_municipio_nome")]
        public string EstabelecimentoMunicipioNome { get; set; }

        [JsonProperty("vacina_grupoAtendimento_codigo")]
        [JsonPropertyName("vacina_grupoAtendimento_codigo")]
        public string VacinaGrupoAtendimentoCodigo { get; set; }

        [JsonProperty("vacina_descricao_dose")]
        [JsonPropertyName("vacina_descricao_dose")]
        public string VacinaDescricaoDose { get; set; }

        [JsonProperty("paciente_endereco_nmMunicipio")]
        [JsonPropertyName("paciente_endereco_nmMunicipio")]
        public string PacienteEnderecoNMMunicipio { get; set; }

        [JsonProperty("vacina_categoria_nome")]
        [JsonPropertyName("vacina_categoria_nome")]
        public string VacinaCategoriaNome { get; set; }

        [JsonProperty("vacina_fabricante_nome")]
        [JsonPropertyName("vacina_fabricante_nome")]
        public string VacinaFabricanteNome { get; set; }

        [JsonProperty("vacina_categoria_codigo")]
        [JsonPropertyName("vacina_categoria_codigo")]
        public string VacinaCategoriaCodigo { get; set; }

        [JsonProperty("dt_deleted")]
        [JsonPropertyName("dt_deleted")]
        public object DtDeleted { get; set; }

        [JsonProperty("paciente_nacionalidade_enumNacionalidade")]
        [JsonPropertyName("paciente_nacionalidade_enumNacionalidade")]
        public string PacienteNacionalidadeEnumNacionalidade { get; set; }

        [JsonProperty("vacina_numDose")]
        [JsonPropertyName("vacina_numDose")]
        public string VacinaNumDose { get; set; }

        [JsonProperty("status")]
        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonProperty("document_id")]
        [JsonPropertyName("document_id")]
        public string DocumentId { get; set; }

        [JsonProperty("vacina_lote")]
        [JsonPropertyName("vacina_lote")]
        public string VacinaLote { get; set; }

        [JsonProperty("id_sistema_origem")]
        [JsonPropertyName("id_sistema_origem")]
        public string IdSistemaOrigem { get; set; }

        [JsonProperty("@timestamp")]
        [JsonPropertyName("@timestamp")]
        public DateTime Timestamp { get; set; }

        [JsonProperty("estalecimento_noFantasia")]
        [JsonPropertyName("estalecimento_noFantasia")]
        public string EstabelecimentoNoFantasia { get; set; }

        [JsonProperty("@version")]
        [JsonPropertyName("@version")]
        public string Version { get; set; }

        [JsonProperty("paciente_racaCor_codigo")]
        [JsonPropertyName("paciente_racaCor_codigo")]
        public string PacienteRacaCorCodigo { get; set; }

        [JsonProperty("estabelecimento_razaoSocial")]
        [JsonPropertyName("estabelecimento_razaoSocial")]
        public string EstabelecimentoRazaoSocial { get; set; }

        [JsonProperty("vacina_nome")]
        [JsonPropertyName("vacina_nome")]
        public string VacinaNome { get; set; }

        [JsonProperty("estabelecimento_uf")]
        [JsonPropertyName("estabelecimento_uf")]
        public string EstabelecimentoUf { get; set; }

        [JsonProperty("data_importacao_rnds")]
        [JsonPropertyName("data_importacao_rnds")]
        public DateTime DataImportacaoRnds { get; set; }

        [JsonProperty("vacina_dataAplicacao")]
        [JsonPropertyName("vacina_dataAplicacao")]
        public DateTime VacinaDataAplicacao { get; set; }

        [JsonProperty("co_condicao_maternal")]
        [JsonPropertyName("co_condicao_maternal")]
        public int? CoCondicaoMaternal { get; set; }

        [JsonProperty("paciente_endereco_coPais")]
        [JsonPropertyName("paciente_endereco_coPais")]
        public string PacienteEnderecoCoPais { get; set; }

        [JsonProperty("vacina_fabricante_referencia")]
        [JsonPropertyName("vacina_fabricante_referencia")]
        public string VacinaFabricanteReferencia { get; set; }

        [JsonProperty("paciente_endereco_coIbgeMunicipio")]
        [JsonPropertyName("paciente_endereco_coIbgeMunicipio")]
        public string PacienteEnderecoCoIbgeMunicipio { get; set; }
    }
}
