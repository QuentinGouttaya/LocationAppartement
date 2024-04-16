using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using GSBAppartement.Domain.Personnes;


namespace GSBAppartement.Domain.Appartement
{
    [Table("Appartement")]
    public class Appartement
    {
        [Column("id")]
        public Guid Id { get; set; }

        [Column("type_appart")]
        public string TypeAppart { get; set; }

        [Column("nbr_chambre")]
        public int NbrChambre { get; set; }

        [Column("prix_loc")]
        public decimal PrixLoc { get; set; }

        [Column("prix_charge")]
        public decimal PrixCharge { get; set; }

        [Column("adresse")]
        public string Adresse { get; set; }

        [Column("ville")]
        public string Ville { get; set; }

        [Column("code_postal")]
        public string CodePostal { get; set; }

        [Column("etage")]
        public string Etage { get; set; }

        [Column("avec_ascenseur")]
        public bool AvecAscenseur { get; set; }

        [Column("avec_preavis")]
        public bool AvecPreavis { get; set; }

        [Column("date_libre")]
        public DateTime DateLibre { get; set; }

        [Column("id_proprietaire")]
        public Guid ProprietaireId { get; set; }

        [Column("id_arrondissement")]
        public int ArrondissementId { get; set; }

    }


}
