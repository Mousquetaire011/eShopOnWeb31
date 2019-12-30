using Microsoft.AspNetCore.Identity;
using Microsoft.eShopWeb.ApplicationCore.Constants;
using System.Threading.Tasks;

namespace Microsoft.eShopWeb.Infrastructure.Identity
{
    public class AppIdentityDbContextSeed
    {/// <summary>
     /// FRo: N'exécutez les opérations que si elles sont nécessaires pour éviter de léver des warnings à chaque démarrage d'application.
     /// </summary>
     /// <param name="userManager"></param>
     /// <param name="roleManager"></param>
     /// <returns></returns>
        public static async Task SeedAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            // Création du Rôle Admin
            if (!await roleManager.RoleExistsAsync(AuthorizationConstants.Roles.ADMINISTRATORS))
            {
                await roleManager.CreateAsync(new IdentityRole(AuthorizationConstants.Roles.ADMINISTRATORS));
            }

            // Création utilisateur demouser@microsoft.com
            var defaultUser = new ApplicationUser { UserName = "demouser@microsoft.com", Email = "demouser@microsoft.com" };
            ApplicationUser doesExistsDefautUser = await userManager.FindByNameAsync(defaultUser.UserName);
            if (doesExistsDefautUser == null)
            {
                await userManager.CreateAsync(defaultUser, AuthorizationConstants.DEFAULT_PASSWORD);
            }

            // Création, utilisateur : admin@microsoft.com
            string adminUserName = "admin@microsoft.com";
            var adminUser = new ApplicationUser { UserName = adminUserName, Email = adminUserName };

            ApplicationUser doesExistsAdminUser = await userManager.FindByNameAsync(adminUserName);
            if (doesExistsAdminUser == null)
            {
                await userManager.CreateAsync(adminUser, AuthorizationConstants.DEFAULT_PASSWORD);

                // Mettre utilisateur admin@microsoft.com dans le role "Administrators"
                adminUser = await userManager.FindByNameAsync(adminUserName);
                if (!await userManager.IsInRoleAsync(adminUser, AuthorizationConstants.Roles.ADMINISTRATORS))
                {
                    await userManager.AddToRoleAsync(adminUser, AuthorizationConstants.Roles.ADMINISTRATORS);
                }
            }
        }
    }
}
