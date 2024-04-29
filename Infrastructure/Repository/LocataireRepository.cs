using GSBAppartement.Domain.Demande;
using GSBAppartement.Domain.Personnes;
using GSBAppartement.Domain.Appartement;
using GSBAppartement.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using GSBAppartement.Infrastructure.Context;

namespace GSBAppartement.Repository.Implementations
{
    public class LocataireRepository : ILocataireRepository, IDisposable
    {
        private readonly ApplicationDbContext _context;
        private bool _disposed = false;

        public LocataireRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Locataire>> GetAllAsync()
        {
            return await _context.Locataire
            .ToListAsync();
        }

        public async Task<Locataire> GetByIdAsync(Guid locataireId)
        {
            return await _context.Locataire
                .FirstOrDefaultAsync(l => l.LocataireId == locataireId);
        }

        public async Task AddAsync(Guid clientId, string rib, Guid appartementId)
        {
            var client = await _context.Client
                .FirstOrDefaultAsync(c => c.ClientId == clientId);



            if (client == null)
            {
                throw new Exception("Client not found");
            }

            var locataire = new Locataire
            {
                Id = client.Id,
                LocataireId = client.ClientId,
                Rib = rib,
                AppartementId = appartementId,
            };

            _context.Locataire.Add(locataire); // add the new Locataire record to the context
            await _context.SaveChangesAsync();

            _context.Client.Remove(client);
            await _context.SaveChangesAsync();


        }

        public async Task UpdateAsync(Locataire locataire)
        {
            _context.Entry(locataire).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid locataireId)
        {
            var locataire = await _context.Locataire
                .FirstOrDefaultAsync(l => l.LocataireId == locataireId);

            if (locataire != null)
            {
                _context.Locataire.Remove(locataire);
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


