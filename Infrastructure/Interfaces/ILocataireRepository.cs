using GSBAppartement.Domain.Personnes;
using GSBAppartement.Domain.Appartement;

namespace GSBAppartement.Repository.Interfaces
{

    public interface ILocataireRepository
    {

        Task<IEnumerable<Locataire>> GetAllAsync();
        Task<Locataire> GetByIdAsync(Guid locataireId);
        Task UpdateAsync(Locataire locataire);
        Task DeleteAsync(Guid locataireId);
        Task AddAsync(Guid ClientId, string rib, Guid appartementId);
    }
}
