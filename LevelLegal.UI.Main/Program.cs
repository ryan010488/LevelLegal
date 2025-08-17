using LevelLegal.Domain.Entities.Data;
using LevelLegal.Domain.Interfaces.Repositories;
using LevelLegal.Domain.Interfaces.Services;
using LevelLegal.Infrastructure.Repositories;
using LevelLegal.Infrastructure.Services;
using LevelLegal.Infrastructure.Utilities;
using LevelLegal.UI.Main.Components;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContextFactory<DataAccess>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("LevelLegalDataAccess") ?? throw new InvalidOperationException("Connection string 'TaskMngtSystemContext' not found.")));

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddHttpClient();
builder.Services.AddControllers();

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);

builder.Services.AddScoped<IEvidenceRepository, EvidenceRepository>();
builder.Services.AddScoped<IMatterRepository, MatterRepository>();

builder.Services.AddScoped<IEvidenceService, EvidenceService>();
builder.Services.AddScoped<IMatterService, MatterService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
