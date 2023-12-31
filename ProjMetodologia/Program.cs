using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using ProjMetodologia.Data;
using ProjMetodologia.Data.CentroCosto;
using ProjMetodologia.Data.MovimientoPlanilla;
using ProjMetodologia.Pages.CentroCostos;
using ProjMetodologia.Shared;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<SharedStateService>();
builder.Services.AddSingleton<SharedCentroCostos>();
builder.Services.AddSingleton<SharedMovimientoPlanilla>();
// En el m�todo ConfigureServices de Program.cs
builder.Services.AddScoped<ICreatePage, CreatePageImplementation>();


builder.Services.AddScoped(sp =>
    new HttpClient
    {
        BaseAddress = new Uri(@"http://apiservicios.ecuasolmovsa.com:3009/")
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
