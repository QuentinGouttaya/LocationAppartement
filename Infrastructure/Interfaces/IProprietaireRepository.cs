using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using GSBAppartement.Domain.Personnes;
using GSBAppartement.Domain.Appartement;

namespace GSBAppartement.Repository.Interfaces
{

    public interface IProprietaireRepository
    {
        Task<IEnumerable<Proprietaire>> GetAllAsync();
        Task<ICollection<Appartement>> GetProprietaireAppartementsByIdAsync(Guid IdProprietaire);
        Task<Proprietaire> GetByIdAsync(Guid id);
    }
}



