using CommsWall.WebApp.Data;
using Blazored.Modal;
using CommsWall.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddBlazoredModal();
builder.Services.AddSingleton<WeatherForecastService>();


// --testing -towards --production grade phase
builder.Services.AddDbContext<CommsDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("AzureSqlDB"), b => b.MigrationsAssembly("CommsWall.WebApp"));
});
// --end testing -towards --production grade phase


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
