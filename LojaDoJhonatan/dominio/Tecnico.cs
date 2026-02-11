using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LojaDoJhonatan.dominio
{
    [Table("tecnicos")]
    public class Tecnico
    {
        [Key]
        [Column("id_tecnico")]
        public int IdTecnico { get; set; }

        [Column("nome")]
        public string Nome { get; set; }

        [Column("especialidade")]
        public string Especialidade { get; set; }

    }
}
