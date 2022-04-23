using Magazyn.Models;
using Microsoft.AspNetCore.Identity;

namespace Magazyn.Data
{
    public static class SeedDataExtension
    {
        public static async Task SeedData(this IServiceCollection services)
        {
            var serviceProvider = services.BuildServiceProvider();
            var dbContext = serviceProvider.GetRequiredService<ApplicationDbContext>();
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            var roleManager = serviceProvider.GetRequiredService<RoleManager<Role>>();

            // Role
            if (!roleManager.RoleExistsAsync("Uzytkownik").Result)
            {
                var uzytkownikRole = new Role()
                {
                    Name = "Uzytkownik",
                    RoleValue = RoleValue.Uzytkownik
                };
                await roleManager.CreateAsync(uzytkownikRole);
            }
            if (!roleManager.RoleExistsAsync("Pracownik").Result)
            {
                var arbeitNieRobiFrei = new Role()
                {
                    Name = "Pracownik",
                    RoleValue = RoleValue.Pracownik
                };
                await roleManager.CreateAsync(arbeitNieRobiFrei);

            }

            if (!roleManager.RoleExistsAsync("Kierownik").Result)
            {
                var panieKierowniku = new Role()
                {
                    Name = "Kierownik",
                    RoleValue = RoleValue.Kierownik
                };
                await roleManager.CreateAsync(panieKierowniku);

            }

            if (!roleManager.RoleExistsAsync("Admin").Result)
            {
                var adminRole = new Role()
                {
                    Name = "Admin",
                    RoleValue = RoleValue.Admin
                };
                await roleManager.CreateAsync(adminRole);
            }

            // Dodawanie użytkowników
            var userPass = "Qwerty1!";
            var usr = userManager.FindByNameAsync("jeden@x.com").Result;
            if (usr == null)
            {
                var usr1 = new ApplicationUser()
                {
                    FirstName = "Zwykly",
                    LastName = "Janusz",
                    UserName = "jeden@x.com",
                    Email = "jeden@x.com",
                };
                await userManager.CreateAsync(usr1, userPass);
                await userManager.AddToRoleAsync(usr1, "Uzytkownik");
            }
            usr = userManager.FindByNameAsync("dwa@x.com").Result;
            if (usr == null)
            {
                var usr2 = new ApplicationUser()
                {
                    FirstName = "Zwykla",
                    LastName = "Grazyna",
                    UserName = "dwa@x.com",
                    Email = "dwa@x.com",
                };
                await userManager.CreateAsync(usr2, userPass);
                await userManager.AddToRoleAsync(usr2, "Uzytkownik");
            }

            if (userManager.FindByNameAsync("trzy@x.com").Result == null)
            {
                var usr3 = new Pracownik()
                {
                    FirstName = "Ten",
                    LastName = "Pracuje",
                    UserName = "trzy@x.com",
                    Email = "trzy@x.com",
                };
                await userManager.CreateAsync(usr3, userPass);
                await userManager.AddToRoleAsync(usr3, "Uzytkownik");
            }

            if (userManager.FindByNameAsync("cztery@x.com").Result == null)
            {
                var usr4 = new Pracownik()
                {
                    FirstName = "Nastepny",
                    LastName = "Pracuś",
                    UserName = "cztery@x.com",
                    Email = "cztery@x.com",
                };
                await userManager.CreateAsync(usr4, userPass);
                await userManager.AddToRoleAsync(usr4, "Pracownik");
            }

            if (userManager.FindByNameAsync("piec@x.com").Result == null)
            {
                var usr5 = new Pracownik()
                {
                    FirstName = "Pracownik",
                    LastName = "Kolejny",
                    UserName = "piec@x.com",
                    Email = "piec@x.com",
                };
                await userManager.CreateAsync(usr5, userPass);
                await userManager.AddToRoleAsync(usr5, "Pracownik");
            }

            if (userManager.FindByNameAsync("kierownik@x.com").Result == null)
            {
                var usr6 = new Kierownik()
                {
                    FirstName = "Adam",
                    LastName = "Mickiewicz",
                    UserName = "kierownik@x.com",
                    Email = "kierownik@x.com",
                };
                await userManager.CreateAsync(usr6, userPass);
                await userManager.AddToRoleAsync(usr6, "Kierownik");
            }

            if (userManager.FindByNameAsync("elektron@x.com").Result == null)
            {
                var usr7 = new Kierownik()
                {
                    FirstName = "Nicola",
                    LastName = "Tesla",
                    UserName = "elektron@x.com",
                    Email = "elektron@x.com",
                };
                await userManager.CreateAsync(usr7, userPass);
                await userManager.AddToRoleAsync(usr7, "Kierownik");
            }

            await dbContext.SaveChangesAsync();
        }
    }
}
