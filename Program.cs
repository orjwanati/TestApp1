using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using TestApp1.Areas.Identity;
using TestApp1.Data;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<TenantService>();

// Add services to the container.
//var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
//builder.Services.AddDbContext<ApplicationDbContext>((sp, options) =>
//{
//    options.UseSqlServer(connectionString);
//});

//builder.Services.AddDbContext<MyContext>(options =>
//{

//});
builder.Services.AddDbContextFactory<ApplicationDbContext>((sp, opts) =>
{
    var tenantProvider = sp.GetRequiredService<TenantService>();
    opts.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=aspnet-OrjuwanApp1-{tenantProvider.GetTenant()};Trusted_Connection=True;MultipleActiveResultSets=true");
    //opts.UseSqlServer($"Data Source={tenantProvider.GetTenant()}.sqlite");
}, ServiceLifetime.Transient);



builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<IdentityUser>>();
builder.Services.AddSingleton<WeatherForecastService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
