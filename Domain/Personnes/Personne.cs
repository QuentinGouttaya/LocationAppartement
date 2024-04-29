using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GSBAppartement.Domain.Personnes;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GSBAppartement.Domain.Personnes
{
    public abstract class Personne
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        [Column("prenom")]
        public string Prenom { get; set; }

        [Column("nom")]
        public string Nom { get; set; }

        [Column("adresse")]
        public string Adresse { get; set; }

        [Column("ville")]
        public string Ville { get; set; }

        [Column("code_postal")]
        public string CodePostal { get; set; }

        [Column("tel")]
        public string Tel { get; set; }

    }
}
