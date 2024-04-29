using Microsoft.EntityFrameworkCore;
using GSBAppartement.Domain.Appartement;
using GSBAppartement.Domain.Personnes;
using GSBAppartement.Domain.Demande;


namespace GSBAppartement.Infrastructure.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }


        public DbSet<Appartement> Appartement { get; set; }
        public DbSet<Locataire> Locataire { get; set; }
        public DbSet<Personne> Personne { get; set; }
        public DbSet<Proprietaire> Proprietaire { get; set; }
        public DbSet<Client> Client { get; set; }
        public DbSet<Demande> Demande { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Appartement>().ToTable("Appartement");
            modelBuilder.Entity<Personne>().ToTable("Personne");
            modelBuilder.Entity<Proprietaire>().ToTable("Proprietaire");
            modelBuilder.Entity<Locataire>().ToTable("Locataire");
            modelBuilder.Entity<Client>().ToTable("Client");
            modelBuilder.Entity<Demande>().ToTable("Demande");
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }
    }
}

