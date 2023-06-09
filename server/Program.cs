using Microsoft.OpenApi.Models;
using DataAccess;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
     c.SwaggerDoc("v1", new OpenApiInfo { Title = "Carpool application API", Description = "API for the Carpool application", Version = "v1" });
});

builder.Services.AddCors(options => {});
builder.Services.AddDbContext<CarpoolContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("Postgresql")));
builder.Services.AddScoped<ICarpoolEntryRepository, CarpoolEntryRepository>();


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

app.MapControllers();

app.Run();
