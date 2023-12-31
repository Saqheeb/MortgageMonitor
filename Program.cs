using Microsoft.EntityFrameworkCore;
using MortgageMoniteringSystem.Models;
using MortgageMoniteringSystem.Services;



var builder = WebApplication.CreateBuilder(args);
string? connection = builder.Configuration.GetConnectionString("SqlDb");

// Add services to the container.
builder.Services.AddMvc();
//builder.Services.AddScoped<IFeatureManagementService, FeatureManagementService>();


builder.Services.AddDbContext<RiskManagerContext>(options =>
{
    options.UseSqlServer(connection);
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
