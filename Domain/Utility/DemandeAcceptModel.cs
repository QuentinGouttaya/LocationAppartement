using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GSBAppartement.Domain.Utility;


public class DemandeAcceptModel
{
	public Guid DemandeId { get; set; }
	public Guid ClientId { get; set; }
	public string Rib { get; set; }
}
