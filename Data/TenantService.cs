namespace TestApp1.Data
{
    
   
        public class TenantService
    {
       
        
        private string tenant = "test";
        public string GetTenant() => tenant;

        public void SetTenant(string tenant)
        {
            this.tenant = tenant;
        }
    }
}
