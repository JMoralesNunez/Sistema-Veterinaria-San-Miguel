using Microsoft.EntityFrameworkCore;
namespace Veterinaria.Data;

public class Db :DbContext
{
    public DbSet<Client> Clients { get; set; }
    public DbSet<Pet> Pets { get; set; }
    public DbSet<Veterinarian> Veterinarians { get; set; }
    public DbSet<MedicalHistory> MedicalHistories { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseMySql(
            "Server=168.119.183.3;Database=jhonatan_vet;User=root;Password=g0tIFJEQsKHm5$34Pxu1;Port=3307",
            new MySqlServerVersion(new Version(8, 0, 0)));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Client>()
            .HasMany(u => u.Pets)
            .WithOne(p => p.Client)
            .HasForeignKey(p => p.ClientId);
        
        modelBuilder.Entity<Pet>()
            .HasOne(p => p.History)
            .WithOne(h => h.Pet)
            .HasForeignKey<MedicalHistory>(h => h.PetId);

        modelBuilder.Entity<Pet>()
            .HasMany(p => p.Veterinarians)
            .WithMany(v => v.Pets);
    }
}