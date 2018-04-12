using Microsoft.AspNet.Identity.EntityFramework;
using Schedule.DAL.Entities;
using System.Data.Entity;

namespace Schedule.DAL.EF
{
        public class ApplicationContext : IdentityDbContext<ApplicationUser>
        {
            public ApplicationContext(string conectionString) : base(conectionString) { }

            public DbSet<ClientProfile> ClientProfiles { get; set; }
        }   
}
