using CommsWall.WebApp.Data;
using Blazored.Modal;
using CommsWall.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using CommsWall.Infrastructure.PluginInterfaces.ChatSubscribersRp;
using CommsWall.Data.Store.ChatSubscribersDST;
using CommsWall.Infrastructure.ChatSubscribersScreen.ManageSubscribers.SubTasks;
using CommsWall.Infrastructure.ChatSubscribersScreen.QuerySubscribers.SubTasks;
using CommsWall.Infrastructure.ChatSessionsScreen.ManageSessions.SubTasks;
using CommsWall.Infrastructure.ChatSessionsScreen.QuerySessions.SubTasks;
using CommsWall.Infrastructure.PluginInterfaces.ChatSessionsRp;
using CommsWall.Data.Store.ChatSessionsDST;
using CommsWall.Infrastructure.PluginInterfaces.BrowserStorage;
using CommsWall.Infrastructure.BrowserStorageScreen;
using CommsWall.Infrastructure.ChatSessionsScreen.ManageMessages.SubTasks;
using CommsWall.Infrastructure.ChatSessionsScreen.QueryMessages.SubTasks;
using Microsoft.AspNetCore.ResponseCompression;
using CommsWall.WebApp.Hubs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddBlazoredModal();
builder.Services.AddSingleton<WeatherForecastService>();


// --testing -towards --production grade phase
builder.Services.AddResponseCompression(opts =>
{
    opts.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(new[] { "application/octet-stream" });
});

builder.Services.AddDbContext<CommsDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("AzureSqlDB"), b => b.MigrationsAssembly("CommsWall.WebApp"));
});

builder.Services.AddScoped<IChatSubscribersRepository, ChatSubscribersRepository>();
builder.Services.AddScoped<IManageChatSubscribers, ManageChatSubscribers>();
builder.Services.AddTransient<IQueryChatSubscribers, QueryChatSubscribers>();

builder.Services.AddScoped<IChatSessionsRepository, ChatSessionsRepository>();
builder.Services.AddScoped<IManageChatSessions, ManageChatSessions>();
builder.Services.AddTransient<IQueryChatSessions, QueryChatSessions>();

builder.Services.AddTransient<IManageMessages, ManageMessages>();
builder.Services.AddTransient<IQueryMessages, QueryMessages>();

builder.Services.AddScoped<IUserBrowserData, UserBrowserData>();
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
app.MapHub<CommsHub>("/commshub");
app.MapFallbackToPage("/_Host");

app.Run();
