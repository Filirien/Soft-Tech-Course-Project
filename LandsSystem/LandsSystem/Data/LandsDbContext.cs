namespace LandsSystem.Data
{
using Microsoft.AspNet.Identity.EntityFramework;

    public class LandsDbContext : IdentityDbContext<User>
    {
        public LandsDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static LandsDbContext Create()
        {
            return new LandsDbContext();
        }
    }

}