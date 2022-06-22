using AirlineApplication.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNetCore.Builder;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AirlineApplication.Startup))]
namespace AirlineApplication
{
    public partial class Startup
    {

        public void Configuration(IAppBuilder app)
        {
            
            ConfigureAuth(app);
            CreateDefaultAdminRole();
        }
        private void CreateDefaultAdminRole()
        {
            ApplicationDbContext context = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            // In Startup iam creating first Admin Role and creating a default Admin User     
            if (!roleManager.RoleExists("Admin"))
            {

                // first we create Admin rool    
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);

                //Here we create a Admin super user who will maintain the website                   

                var user = new ApplicationUser();
                user.UserName = "Admin";
                user.Email = "AdminXAir@mailinator.com";
                string userPWD = "Qwerty@1234";
                var chkUser = UserManager.Create(user, userPWD);

                //Add default User to Role Admin    
                if (chkUser.Succeeded)
                {
                    var result1 = UserManager.AddToRole(user.Id, "Admin");
                }
            }
        }


    }
}
