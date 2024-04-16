using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using GSBAppartement.Domain.Appartement;

namespace GSBAppartement.Domain.Personnes
{
    public class Proprietaire : Personne
    {


        [Column("id_proprietaire")]
        public Guid ProprietaireId { get; set; }

        public virtual ICollection<Appartement.Appartement> Appartements { get; set; }
    }
}
