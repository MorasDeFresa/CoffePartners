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
builder.Services.AddScoped<ITypeQualityRepository, TypeQualityRepository>();
builder.Services.AddScoped<ILevelRepository, LevelRepository>();
builder.Services.AddScoped<IMachineryRepository, MachineryRepository>();
builder.Services.AddScoped<IPlayerRepository, PlayerRepository>();
builder.Services.AddScoped<IStatesCultivationRepository, StatesCultivationRepository>();
builder.Services.AddScoped<IScoreRepository, ScoreRepository>();
builder.Services.AddScoped<IFarmRepository, FarmRepository>();
builder.Services.AddScoped<IHarvestRepository, HarvestRepository>();
builder.Services.AddScoped<IHarvestProcessRepository, HarvestProcessRepository>();
#endregion

#region Services
builder.Services.AddScoped<ICultivationService, CultivationService>();
builder.Services.AddScoped<ICultivationHarvestService, CultivationHarvestService>();
builder.Services.AddScoped<ITypeQualityService, TypeQualityService>();
builder.Services.AddScoped<ILevelService, LevelService>();
builder.Services.AddScoped<IMachineryService, MachineryService>();
builder.Services.AddScoped<IPlayerService, PlayerService>();
builder.Services.AddScoped<IStatesCultivationService, StatesCultivationService>();
builder.Services.AddScoped<IScoreService, ScoreService>();
builder.Services.AddScoped<IFarmService, FarmService>();
builder.Services.AddScoped<IHarvestService, HarvestService>();
builder.Services.AddScoped<IHarvestProcessService, HarvestProcessService>();
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

