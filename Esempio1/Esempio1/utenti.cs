using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Esempio1
{
    [Table("utenti")]
    public partial class utenti
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        [StringLength(50)]
        public string nome { get; set; }

        [StringLength(50)]
        public string cognome { get; set; }

        [StringLength(50)]
        public string indirizzo { get; set; }
    }
}
