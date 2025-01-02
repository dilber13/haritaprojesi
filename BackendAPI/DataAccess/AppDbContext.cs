namespace BackendAPI.DataAccess
{
    using global::BackendAPI.Entities;
    using Microsoft.EntityFrameworkCore;

    public class AppDbContext : DbContext
    {
        public DbSet<Il> Iller { get; set; }
        public DbSet<Ilce> Ilceler { get; set; }
        public DbSet<Mahalle> Mahalleler { get; set; }
        public DbSet<Tasinmaz> Tasinmazlar { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Database=TasinmazDb;Username=postgres;Password=password");
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Il>()
                .HasMany(i => i.Ilceler)
                .WithOne(ilce => ilce.Il)
            .HasForeignKey(ilce => ilce.IlId);

            modelBuilder.Entity<Ilce>()
                .HasMany(i => i.Mahalleler)
                .WithOne(mahalle => mahalle.Ilce)
                .HasForeignKey(mahalle => mahalle.IlceId);

            modelBuilder.Entity<Mahalle>()
                .HasMany(m => m.Tasinmazlar)
                .WithOne(t => t.Mahalle)
                .HasForeignKey(t => t.MahalleId);
        }
    }

}
