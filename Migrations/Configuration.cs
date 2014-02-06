namespace IsmsWebApplication.Migrations
{
    using IsmsWebApplication.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Web.Security;
    using WebMatrix.WebData;

    internal sealed class Configuration : DbMigrationsConfiguration<IsmsWebApplication.DataContext.IsmDataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(IsmsWebApplication.DataContext.IsmDataContext context)
        {
            //Add an admin
            var adminUser = "darragh.oriordan@gmail.com";
            var adminseedPassword = "migrated";
            var adminRole = "Administrator";

            WebSecurity.InitializeDatabaseConnection(
           "DefaultConnection",
           "UserProfile",
           "UserId",
           "UserName", autoCreateTables: true);
            var roles = (SimpleRoleProvider)Roles.Provider;
            var membership = (SimpleMembershipProvider)Membership.Provider;

            if (!WebSecurity.UserExists(adminUser))
            {
                WebSecurity.CreateUserAndAccount(adminUser, adminseedPassword);
            }

            if (!roles.RoleExists(adminRole))
            {
                roles.CreateRole(adminRole);
            }

            if (!roles.IsUserInRole(adminUser, adminRole))
            {
                roles.AddUsersToRoles(new string[] { adminUser }, new string[] { adminRole });
            }

            //add the basic config(s)
            var configs = new List<IsmConfiguration>();
           configs.Add( new IsmConfiguration()
                   {
                       BaseImageUrl = "~/Images/ievaThought.jpg",
                       BubbleTextInputHeight = "190",
                       BubbleTextInputWidth = "290",
                       BubbleTextInputLeft = "570",
                       BubbleTextInputTop = "60",
                       CreatedOn = DateTime.UtcNow,
                       TargetName = "Ieva",
                       Username = adminUser
                   });
           configs.Add(new IsmConfiguration()
           {
               BaseImageUrl = "~/Images/kristinespeech.jpg",
               BubbleTextInputHeight = "300",
               BubbleTextInputWidth = "280",
               BubbleTextInputLeft = "640",
               BubbleTextInputTop = "50",
               CreatedOn = DateTime.UtcNow,
               TargetName = "Kristine",
               Username = adminUser
           });
           configs.Add(new IsmConfiguration()
           {
               BaseImageUrl = "~/Images/taniaspeech.jpg",
               BubbleTextInputHeight = "190",
               BubbleTextInputWidth = "380",
               BubbleTextInputLeft = "540",
               BubbleTextInputTop = "60",
               CreatedOn = DateTime.UtcNow,
               TargetName = "Tania",
               Username = adminUser
           });
           configs.Add(new IsmConfiguration()
           {
               BaseImageUrl = "~/Images/editespeech.jpg",
               BubbleTextInputHeight = "200",
               BubbleTextInputWidth = "270",
               BubbleTextInputLeft = "180",
               BubbleTextInputTop = "20",
               CreatedOn = DateTime.UtcNow,
               TargetName = "Edite",
               Username = adminUser
           });
           foreach (var c in configs)
           {
               if (!context.IsmConfigurations.Any(
                   ic => ic.TargetName == c.TargetName
                       && ic.BaseImageUrl == c.BaseImageUrl))
               {
                   context.IsmConfigurations.AddOrUpdate<IsmConfiguration>(c);
               };
           }
        }
    }
}
