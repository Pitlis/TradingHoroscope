using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class UserInit : DropCreateDatabaseIfModelChanges<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            var userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(context));

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            
            var role1 = new IdentityRole { Name = "admin" };
            var role2 = new IdentityRole { Name = "user" };

            // добавляем роли в бд
            roleManager.Create(role1);
            roleManager.Create(role2);

            // создаем пользователей
            var admin1 = new ApplicationUser { Email = "prizzzrag@gmail.com", UserName = "prizzzrag@gmail.com" };
            string password = "ad46D_ewr3";
            var result = userManager.Create(admin1, password);
            if (result.Succeeded)
            {
                // добавляем для пользователя роль
                userManager.AddToRole(admin1.Id, role1.Name);
                userManager.AddToRole(admin1.Id, role2.Name);
            }
            var admin2 = new ApplicationUser { Email = "2@mail.ru", UserName = "2" };
            password = "ad46D_ewr3";
            result = userManager.Create(admin2, password);
            if (result.Succeeded)
            {
                // добавляем для пользователя роль
                userManager.AddToRole(admin2.Id, role1.Name);
                userManager.AddToRole(admin2.Id, role2.Name);
            }

            base.Seed(context);
        }
    }
}
