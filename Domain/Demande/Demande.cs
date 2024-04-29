using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using GSBAppartement.Domain.Personnes;


namespace GSBAppartement.Domain.Demande
{

	[Table("Demande")]
	public class Demande
	{
		[Key]
		[Column("id")]
		public Guid Id { get; set; }

		[Column("id_client")]
		public Guid ClientId { get; set; }

		[Column("id_appartement")]
		public Guid AppartementId { get; set; }

		[Column("date_limite")]
		public DateTime DateLimite { get; set; }
	}
}
