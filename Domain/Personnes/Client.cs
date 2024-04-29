using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;


namespace GSBAppartement.Domain.Personnes
{
    [Table("Client")]
    public class Client : Personne
    {
        [Column("id_client")]
        public Guid ClientId { get; set; }

        public virtual ICollection<Demande.Demande> Demandes { get; set; }


    }
}
