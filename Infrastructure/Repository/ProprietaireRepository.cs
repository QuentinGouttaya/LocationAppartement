using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GSBAppartement.Domain.Personnes;
using GSBAppartement.Domain.Appartement;
using GSBAppartement.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using GSBAppartement.Infrastructure.Context;

namespace GSBAppartement.Repository.Implementations
{
    public class ProprietaireRepository : IProprietaireRepository, IDisposable
    {
        private readonly ApplicationDbContext _context;
        private bool _disposed = false;

        public ProprietaireRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Proprietaire>> GetAllAsync()
        {
            var proprietaires = await _context.Proprietaire
            .ToListAsync();

            foreach (var proprietaire in proprietaires)
            {
                var appartements = await _context.Appartement
                    .Where(a => a.ProprietaireId == proprietaire.ProprietaireId)
                    .ToListAsync();
                proprietaire.Appartements = appartements;
            }

            return proprietaires;
        }

        public async Task<Proprietaire> GetByIdAsync(Guid id)
        {
            return await _context.Proprietaire
            .FirstOrDefaultAsync(p => p.ProprietaireId == id);
        }


        public async Task<Proprietaire> AddAsync(Proprietaire proprietaire)
        {
            proprietaire.ProprietaireId = Guid.NewGuid();


            _context.Proprietaire.Add(proprietaire);
            await _context.SaveChangesAsync();
            return proprietaire;
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
