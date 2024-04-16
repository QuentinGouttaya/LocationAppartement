using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSBAppartement.Domain.Personnes
{
    public class Locataire : Personne
    {
        public Guid id_locataire { get; set; }
        public int rib { get; set; }

        public int id_appartement { get; set; }

        public Personne Personne { get; set; }
    }
}
