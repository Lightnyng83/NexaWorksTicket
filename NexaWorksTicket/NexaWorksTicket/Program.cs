using Microsoft.EntityFrameworkCore;
using NexaWorksTicket.Core.Repositories;
using NexaWorksTicket.Core.Services;
using NexaWorksTicket.Data;

var builder = WebApplication.CreateBuilder(args);

#region Database

// Pour le Add-Migration InitialCreate
//string connection = "Server=(localdb)\\mssqllocaldb;Database=NexaWorksTicket;User=;Password=;";
//Scaffold-DbContext 'Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=NexaWorksTicket' Microsoft.EntityFrameworkCore.SqlServer

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


#endregion Database
// Add services to the container.
// Support des Razor Pages et des contrôleurs MVC
builder.Services.AddRazorPages();
builder.Services.AddControllers(); // Ajout des services pour les contrôleurs

builder.Services.AddScoped<ITicketService, TicketService>();
builder.Services.AddScoped<ITicketRepository, TicketRepository>();

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

app.UseAuthorization();

// Configuration pour gérer les endpoints Razor Pages et les contrôleurs API
app.MapRazorPages();
app.MapControllers(); // Assure que les routes des contrôleurs sont accessibles

#region Migration Database

DatabaseSeeder.SeedDatabase(app.Services);

#endregion Migration Database

app.Run();


