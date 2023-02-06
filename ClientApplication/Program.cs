using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using ClientApplication.Services.HttpClientService;

using Blazorise;
using Blazorise.Material;
using Blazorise.Icons.Material;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddBlazorise( options =>options.Immediate = true)
    .AddMaterialProviders()
    .AddMaterialIcons();
    
// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromHours(12);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}

HttpClientService.SetBaseUrl("https://localhost:7216/");


app.UseStaticFiles();

app.UseRouting();

app.UseSession();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
