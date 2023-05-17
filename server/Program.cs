using Microsoft.OpenApi.Models;
using DataAccess;
using System.Data.Common;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
     c.SwaggerDoc("v1", new OpenApiInfo { Title = "Carpool application API", Description = "API for the Carpool application", Version = "v1" });
});

builder.Services.AddCors(options => {});
builder.Services.AddScoped<PostgresConnector>();
builder.Services.AddScoped<PostgresConnectorOptions>(new PostgresConnectorOptions { connString = builder.Configuration.GetConnectionString("Postgresql") });
//builder.Services.AddDbContext<>


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapRazorPages();


app.UseSwagger();
app.UseSwaggerUI(c =>
{
   c.SwaggerEndpoint("/swagger/v1/swagger.json", "Carpool application API");
});

app.MapGet("/", () => "Hello World!");
app.MapGet("/carpool-entry/{id}", (int id) => CarpoolEntryController.GetCarpoolEntry(id));
app.MapGet("/carpool-entry", () => CarpoolEntryController.GetCarpoolEntries());
app.MapPost("/carpool-entry", (CarpoolEntry entry) => CarpoolEntryController.CreateCarpoolEntry(entry));
app.MapPut("/carpool-entry", (CarpoolEntry entry) => CarpoolEntryController.UpdateCarpoolEntry(entry));
app.MapDelete("/carpool-entry/{id}", (int id) => CarpoolEntryController.RemoveCarpoolEntry(id));

app.MapControllers();


app.Run();
