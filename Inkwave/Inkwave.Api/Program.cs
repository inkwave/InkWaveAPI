using Inkwave.Application.Extensions;
using Inkwave.Application.Interfaces;
using Inkwave.Infrastructure.Extensions;
using Inkwave.Persistence.Extensions;
using Inkwave.WebAPI;
using Inkwave.WebAPI.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddApplicationLayer();
builder.Services.AddInfrastructureLayer();
builder.Services.AddPersistenceLayer(builder.Configuration);
builder.Services.AddScoped<IFileHandler, FileHandler>();
builder.Services.AddScoped<IFileWriter, FileWriter>();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerConfiguration();
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
                      policy =>
                      {
                          policy
                          .AllowAnyOrigin()
                          .AllowAnyMethod()
                          .AllowAnyHeader();
                      });
});
builder.Services.AddAuthorization();
var app = builder.Build();


app.UseSwaggerSetup();

app.UseHttpsRedirection();
app.UseCors();

app.UseAuthorization();
app.UseApplicationLayer();

app.MapControllers();

app.Run();
