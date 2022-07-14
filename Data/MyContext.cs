using Microsoft.EntityFrameworkCore;

//@inject ITenantService

namespace TestApp1.Data
{
    public class MyContext : DbContext
    {
        private static readonly string[] Tenants = new[]
   {
        "TEN001",
        "TEN002",
        "TEN003",
        "TEN004",
        "TEN005",

    };
        //public virtual DbSet<Tenant> Tenants { get; set; }
    }
}
