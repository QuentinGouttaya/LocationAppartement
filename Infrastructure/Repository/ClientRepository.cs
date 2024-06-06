using GSBAppartement.Repository.Interfaces;
using GSBAppartement.Domain.Demande;
using GSBAppartement.Infrastructure.Context;
using GSBAppartement.Domain.Personnes;
using Microsoft.EntityFrameworkCore;


namespace GSBAppartement.Repository.Implementations
{
    public class ClientRepository : IClientRepository, IDisposable
    {
        private readonly ApplicationDbContext _context;
        private bool _disposed = false;

        public ClientRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Client>> GetAllAsync()
        {
            return await _context.Client
                .ToListAsync();
        }

        public async Task AddAsync(Client client)
        {
            client.ClientId = Guid.NewGuid();
            _context.Client.Add(client);
            await _context.SaveChangesAsync();
        }



        public async Task<IEnumerable<Demande>> GetAllDemandesAsync()
        {
            return await _context.Demande
                .ToListAsync();
        }

        public async Task<ICollection<Demande>> GetDemandesByClientIdAsync(Guid clientId)
        {
            return await _context.Demande
                .Where(d => d.ClientId == clientId)
                .ToListAsync();
        }

        public async Task<Client> GetByIdAsync(Guid clientId)
        {
            var client = await _context.Client
                .FirstOrDefaultAsync(c => c.ClientId == clientId);

            client.Demandes = await GetDemandesByClientIdAsync(clientId);
            return client;

        }




        public async Task DeleteDemandeAsync(Demande demande)
        {
            _context.Demande.Remove(demande);
            await _context.SaveChangesAsync();
        }

        public async Task AcceptDemandeAsync(Guid demandeId, Guid clientId, string rib)
        {

            var client = await GetByIdAsync(clientId);
            if (client == null)
            {
                throw new Exception("Client not found");
            }

            var demande = client.Demandes.FirstOrDefault(d => d.Id == demandeId);
            if (demande == null)
            {
                throw new Exception("Demande not found");
            }

            var locataire = new Locataire
            {
                LocataireId = client.ClientId,
                Rib = rib,
                AppartementId = demande.AppartementId,
                Nom = client.Nom,
                Prenom = client.Prenom,
                Adresse = client.Adresse,
                Ville = client.Ville,
                CodePostal = client.CodePostal,
                Tel = client.Tel
            };
            _context.Entry(client).State = EntityState.Detached;

            _context.Client.Remove(client);


            await _context.SaveChangesAsync();

            _context.Locataire.Add(locataire);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid clientId)
        {
            var client = await _context.Client
                .FirstOrDefaultAsync(c => c.ClientId == clientId);

            if (client != null)
            {
                _context.Entry(client).State = EntityState.Detached;
                _context.Client.Remove(client);
                await _context.SaveChangesAsync();
            }

        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    // Dispose managed resources
                    _context?.Dispose();
                }

                // Dispose unmanaged resources
                // ... (if any)

                _disposed = true;
            }
        }

    }
}


