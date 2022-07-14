namespace TestApp1
{
    public interface ITentantService
    {
        string Tenant { get; }

        void SetTenant(string tenant);

        string[] GetTenants();

        //event TenantChangedEventHandler OnTenantChanged;
    }
}
