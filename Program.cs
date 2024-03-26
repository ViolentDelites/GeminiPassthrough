using ISB.CLWater.Web.Components;
using ISB.CLWater.Service.DI;
using ISB.CLWater.Web.Components.Layout;
using ISB.CLWater.Service.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddDbContext<CLWaterContext>();

var configuration = builder.Configuration;
var connectionString = configuration.GetConnectionString("SQLConnection");

ServiceDependencyInjection.RegisterServices(builder.Services, connectionString);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

// Set the default layout
builder.Services.AddScoped(sp =>
{
    var navigationManager = sp.GetRequiredService<NavigationManager>();
    return new HttpClient { BaseAddress = new Uri(navigationManager.BaseUri) };
});
builder.Services.AddSingleton<MainLayout>();

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();
app.MapRazorComponents<App>().AddInteractiveServerRenderMode();
app.Run();