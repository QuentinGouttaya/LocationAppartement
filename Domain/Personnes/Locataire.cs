using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GSBAppartement.Domain.Personnes
{
    [Table("Locataire")]
    public class Locataire : Personne
    {
        [Column("id_locataire")]
        public Guid LocataireId { get; set; }

        [Column("rib")]
        public string Rib { get; set; }

        [Column("id_appartement")]
        public Guid AppartementId { get; set; }

    }
}
