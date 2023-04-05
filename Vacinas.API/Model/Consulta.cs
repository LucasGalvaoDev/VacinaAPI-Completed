using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vacinas.API.Model
{
    [Table("tbl_consulta")]
    public class Consulta
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string? Nome { get; set; }

        [Required]
        public string Cpf { get; set; }

        public DateTime DataSolicitacao { get; set; }
    }
}
