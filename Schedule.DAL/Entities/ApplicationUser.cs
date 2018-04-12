using Microsoft.AspNet.Identity.EntityFramework;

namespace Schedule.DAL.Entities
{
    public class ApplicationUser :
        IdentityUser
    {
        public virtual ClientProfile ClientProfile { get; set; }
    }
}
