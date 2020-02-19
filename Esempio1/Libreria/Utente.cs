using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria
{
    public partial class Utente
    {

        public string nome { get; set; }
        public string cognome { get; set; }

        string NomeCompleto()
        {
            return this.nome + " " + this.cognome;
        }

    }
}
