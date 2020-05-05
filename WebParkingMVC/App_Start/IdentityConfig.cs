using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Net.Configuration;
using System.Net.Mail;
using System.Net.Mime;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Services.Description;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using WebParkingMVC.Models;

namespace WebParkingMVC
{
    public class EmailService : IIdentityMessageService
    {
        public Task SendAsync(IdentityMessage message)
        {
            // Plug in your email service here to send an email.
            //return Task.FromResult(0);
            return Task.Factory.StartNew(
                                          () => 
                                          {
                                              sendMail(message);
                                          });
        }
        //Added according to https://go.microsoft.com/fwlink/?LinkID=320771
        public void sendMail(IdentityMessage message)
        {
            #region formatter
            string text = string.Format("Please click on this link to {0}: {1}", message.Subject, message.Body);
            string html = "Please confirm your account by clicking this link: <a href=\"" + message.Body + "\">link</a><br/>";

            html += HttpUtility.HtmlEncode(@"Or click on the copy the following link on the browser:" + message.Body);
            #endregion


           // SmtpSection smtpSection = (SmtpSection)ConfigurationManager.GetSection("system.net/mailSettings/smtp");
            //MailAddress from = new MailAddress(smtpSection.From);

            MailMessage msg = new MailMessage();
            msg.From = new MailAddress(ConfigurationManager.AppSettings["Email"].ToString());
            msg.To.Add(new MailAddress(message.Destination));
            msg.Subject = message.Subject;
            msg.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(text, null, MediaTypeNames.Text.Plain));
            msg.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(html, null, MediaTypeNames.Text.Html));

            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", Convert.ToInt32(587));
            System.Net.NetworkCredential credentials = new System.Net.NetworkCredential(ConfigurationManager.AppSettings["Email"].ToString(), ConfigurationManager.AppSettings["Password"].ToString());
            smtpClient.Credentials = credentials;
            smtpClient.EnableSsl = false;
            smtpClient.Send(msg);
        }

    }

   


    public class SmsService : IIdentityMessageService
    {
        public Task SendAsync(IdentityMessage message)
        {
            // Plug in your SMS service here to send a text message.
            return Task.FromResult(0);
        }
    }

    // Configure the application user manager used in this application. UserManager is defined in ASP.NET Identity and is used by the application.
    public class ApplicationUserManager : UserManager<ApplicationUser>
    {
        public ApplicationUserManager(IUserStore<ApplicationUser> store)
            : base(store)
        {
        }

        public static ApplicationUserManager Create(IdentityFactoryOptions<ApplicationUserManager> options, IOwinContext context)
        {
            var manager = new ApplicationUserManager(new UserStore<ApplicationUser>(context.Get<ApplicationDbContext>()));
            // Configure validation logic for usernames
            manager.UserValidator = new UserValidator<ApplicationUser>(manager)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = true
            };

            // Configure validation logic for passwords
            manager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 6,
                RequireNonLetterOrDigit = true,
                RequireDigit = true,
                RequireLowercase = true,
                RequireUppercase = true,
            };

            // Configure user lockout defaults
            manager.UserLockoutEnabledByDefault = true;
            manager.DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(5);
            manager.MaxFailedAccessAttemptsBeforeLockout = 5;

            // Register two factor authentication providers. This application uses Phone and Emails as a step of receiving a code for verifying the user
            // You can write your own provider and plug it in here.
            manager.RegisterTwoFactorProvider("Phone Code", new PhoneNumberTokenProvider<ApplicationUser>
            {
                MessageFormat = "Your security code is {0}"
            });
            manager.RegisterTwoFactorProvider("Email Code", new EmailTokenProvider<ApplicationUser>
            {
                Subject = "Security Code",
                BodyFormat = "Your security code is {0}"
            });
            manager.EmailService = new EmailService();
            manager.SmsService = new SmsService();
            var dataProtectionProvider = options.DataProtectionProvider;
            if (dataProtectionProvider != null)
            {
                manager.UserTokenProvider =
                    new DataProtectorTokenProvider<ApplicationUser>(dataProtectionProvider.Create("ASP.NET Identity"));
            }
            return manager;
        }
    }

    // Configure the application sign-in manager which is used in this application.
    public class ApplicationSignInManager : SignInManager<ApplicationUser, string>
    {
        public ApplicationSignInManager(ApplicationUserManager userManager, IAuthenticationManager authenticationManager)
            : base(userManager, authenticationManager)
        {
        }

        public override Task<ClaimsIdentity> CreateUserIdentityAsync(ApplicationUser user)
        {
            return user.GenerateUserIdentityAsync((ApplicationUserManager)UserManager);
        }

        public static ApplicationSignInManager Create(IdentityFactoryOptions<ApplicationSignInManager> options, IOwinContext context)
        {
            return new ApplicationSignInManager(context.GetUserManager<ApplicationUserManager>(), context.Authentication);
        }
    }

    //Code ADDED for ApplicationRole Manager. Then should add one line at Startup.Auth or else no roles will be created
    public class ApplicationRoleManager : RoleManager<ApplicationRole>
    {
        public ApplicationRoleManager(IRoleStore<ApplicationRole, string> roleStore)
            : base(roleStore)
        {
        }

        public static ApplicationRoleManager Create(IdentityFactoryOptions<ApplicationRoleManager> options, IOwinContext context)
        {
            return new ApplicationRoleManager(new RoleStore<ApplicationRole>(context.Get<ApplicationDbContext>()));
        }

    }


    //Code Added for Application Initialize entity data to db
    public class ApplicationDbInitializer : CreateDatabaseIfNotExists<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            InitializeIdentityData(context);
            base.Seed(context);
        }

        public static void InitializeIdentityData(ApplicationDbContext db)
        {
            var userManger = HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var roleManager = HttpContext.Current.GetOwinContext().Get<ApplicationRoleManager>();

            //Admins Credential
            string userName = "admin@unipi.gr";
            string Password = "P@ssw0rd";

            //Managers Credential
            string ManagerUserName = "manager@unipi.gr";
            string ManagerPassword = "P@ssw0rd";

            string roleAdmin = "Admin";
            string roleManagers = "Manager";
            string roleSimpleUser = "User";

//-------------------Create Roles-------------------------------------------------//
            //Create Role Managers if Not Exist
            var roleforManager = roleManager.FindByName(roleManagers);
            if (roleforManager == null)
            {
                roleforManager = new ApplicationRole(roleManagers);
                var roleresult = roleManager.Create(roleforManager);
            }

            //Create Role Simple User if Not Exist
             var roleUser = roleManager.FindByName(roleSimpleUser);
            if (roleUser == null)
            {
                roleUser = new ApplicationRole(roleSimpleUser);
                var roleresult = roleManager.Create(roleUser);
            }

            //Create Role Admin User if Not Exist
            var roleAdmininstrator = roleManager.FindByName(roleAdmin);
            if (roleAdmininstrator == null)
            {
                roleAdmininstrator = new ApplicationRole(roleAdmin);
                var roleresult = roleManager.Create(roleAdmininstrator);
            }
//-----------------------------------------------------------------------------------------//
            //Create userName admin if not exist
            var user = userManger.FindByName(userName);
            if (user == null)
            {
                user = new ApplicationUser { UserName = userName, Email = userName };
                var result = userManger.Create(user, Password);
                result = userManger.SetLockoutEnabled(user.Id, false);
            }

            //Add user Admin to Role Admin if not already Added
            var rolesForAdminUser = userManger.GetRoles(user.Id);
            if (!rolesForAdminUser.Contains(roleAdmininstrator.Name))
            {
                var result = userManger.AddToRole(user.Id, roleAdmininstrator.Name);
            }
//-----------------------------------------------------------------------------------------------------//

            //Create userName manager if not exist
            var manager = userManger.FindByName(ManagerUserName);
            if (manager == null)
            {
                manager = new ApplicationUser { UserName = ManagerUserName, Email = ManagerUserName };
                var result = userManger.Create(manager, ManagerPassword);
                result = userManger.SetLockoutEnabled(manager.Id, false);
            }


            //Add user Manager to Role Manager if not already Added
            var rolesForManager = userManger.GetRoles(user.Id);
            if (!rolesForManager.Contains(roleforManager.Name))
            {
                var result = userManger.AddToRole(manager.Id, roleforManager.Name);
            }

        }
    }
}
