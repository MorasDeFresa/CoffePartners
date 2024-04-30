using CoffePartners.Data;
using CoffePartners.Repository;
using CoffePartners.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

#region Repostiories 
builder.Services.AddScoped<ICultivationRepository, CultivationRepository>();
builder.Services.AddScoped<ICultivationHarvestRepository, CultivationHarvestRepository>();
#endregion

#region Services
builder.Services.AddScoped<ICultivationService, CultivationService>();
builder.Services.AddScoped<ICultivationHarvestService, CultivationHarvestService>();
#endregion

// builder.Services.AddScoped<IPlayerRepository, PlayerRepository>();
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DatabaseURL"));
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();

