using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vacinas.API.Model
{
    [Table("tbl_relatorio")]
    public class Relatorio
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime DataSolicitacao { get; set; }

        [Required]
        public string? DescricaoRelatorio { get; set; }

        [Required]
        public int QuantidadeTotalVacinados { get; set; }

        [Required]
        public int SolicitanteId { get; set; }
    }
}
