using GSBAppartement.Domain.Appartement;
using GSBAppartement.Domain.Personnes;
using GSBAppartement.Domain.Demande;


namespace GSBAppartement.Repository.Interfaces
{
    public interface IClientRepository
    {
        Task<Client> GetByIdAsync(Guid id);
        Task<IEnumerable<Client>> GetAllAsync();
        Task<ICollection<Demande>> GetDemandesByClientIdAsync(Guid clientId);
        Task<IEnumerable<Demande>> GetAllDemandesAsync();
        Task DeleteAsync(Guid id);
        Task DeleteDemandeAsync(Demande demande);
        Task AcceptDemandeAsync(Guid demandeId, Guid clientId, string rib);
        Task AddAsync(Client client);
    }
}
