using Magazyn.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Magazyn.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, Role, int>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ApplicationUser>()
                .ToTable("AspNetUsers")
                .HasDiscriminator<int>("UserType")
                .HasValue<ApplicationUser>((int)RoleValue.Uzytkownik)
                .HasValue<Kierownik>((int)RoleValue.Kierownik)
                .HasValue<Pracownik>((int)RoleValue.Pracownik);
        }

        public DbSet<Magazyn.Models.Produkt> Produkt { get; set; }

        public DbSet<Magazyn.Models.Kategoria> Kategoria { get; set; }
    }
}