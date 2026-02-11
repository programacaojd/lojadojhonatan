using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LojaDoJhonatan.dominio
{
    [Table("celulares")]
    public class Celular
    {
        [Key]
        [Column("id_celular")]
        public int IdCelular { get; set; }

        [Column("id_cliente")]
        public int IdCliente { get; set; }

        [Column("marca")]
        public string Marca { get; set; }

        [Column("modelo")]
        public string Modelo { get; set; }

        [Column("imei")]
        public string Imei { get; set; }
    }
}
