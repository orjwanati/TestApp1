using Microsoft.EntityFrameworkCore;


namespace TestApp1.Data
{
    public class MyContext : DbContext
    {

        public virtual DbSet<Tenant>? Tenants { get; set; }
    }
    
}
