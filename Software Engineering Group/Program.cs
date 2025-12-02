using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;
using Software_Engineering_Group.Data;
using SensoreApp.Models;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<Software_Engineering_GroupContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Software_Engineering_GroupContext") ?? throw new InvalidOperationException("Connection string 'Software_Engineering_GroupContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();

//builder.Services.AddDefaultIdentity<IdentityUser>().AddEntityFrameworkStores<Software_Engineering_GroupContext>();
builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<Software_Engineering_GroupContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.MapRazorPages();

using (var scope = app.Services.CreateScope())
{
    await RoleMaker.MakeRolesAsync(scope.ServiceProvider);
}

app.Run();
