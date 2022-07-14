namespace TestApp1.Data
{
    
   
        public class TenantService
    {
        private static readonly string[] Tenants = new[]
       {
            "XYZINC",
            "LOWCORP",
            "ANIMALLLC"
        };

        private string tenant = Tenants.First();
        public string GetTenant() => tenant;

        public void SetTenant(string tenant)
        {
            Console.WriteLine("SetTenant to: " + tenant);
            this.tenant = tenant;
        }

        public string[] GetTenants()
        {
              return TenantService.Tenants;
        }
        }
    }
