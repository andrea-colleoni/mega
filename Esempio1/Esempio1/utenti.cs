namespace Esempio1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

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
