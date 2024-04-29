using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GSBAppartement.Domain.Appartement;
using GSBAppartement.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using GSBAppartement.Infrastructure.Context;
using GSBAppartement.Domain.Personnes;


namespace GSBAppartement.Repository.Implementations
{
    public class AppartementRepository : IAppartementRepository, IDisposable
    {
        private readonly ApplicationDbContext _context;
        private bool _disposed = false;

        public AppartementRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Appartement>> GetAllAsync()
        {
            return await _context.Appartement.ToListAsync();
        }

        public async Task<Appartement> GetByIdAsync(Guid id)
        {
            return await _context.Appartement.FindAsync(id);
        }

        public async Task<IEnumerable<Locataire>> GetLocatairesByAppartementIdAsync(Guid appartementId)
        {
            return await _context.Locataire
                .Where(l => l.AppartementId == appartementId)
                .ToListAsync();
        }

        public async Task<ICollection<Appartement>> GetProprietairesAppartementsByIdAsync(Guid ProprietaireId)
        {
            return await _context.Appartement
                .Where(a => a.ProprietaireId == ProprietaireId)
                .ToListAsync();
        }


        public async Task<Appartement> AddAsync(Appartement appartement)
        {
            _context.Appartement.Add(appartement);
            await _context.SaveChangesAsync();
            return appartement;
        }

        public async Task<Appartement> UpdateAsync(Appartement appartement)
        {
            _context.Entry(appartement).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return appartement;
        }

        public async Task<Appartement> DeleteAsync(Guid id)
        {
            var appartement = await _context.Appartement.FindAsync(id);
            if (appartement == null)
            {
                return null;
            }

            _context.Appartement.Remove(appartement);
            await _context.SaveChangesAsync();
            return appartement;
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

        // Finalizer (uncomment if you have unmanaged resources)
        //~AppartementRepository()
        //{
        //    Dispose(false);
        //}
    }
}
