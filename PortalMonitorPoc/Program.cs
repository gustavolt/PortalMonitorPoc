using PortalMonitorPoc.Api.v1.Interfaces;
using PortalMonitorPoc.Api.v1.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddHttpClient();
builder.Services.AddScoped<IAzureDataFactoryService, AzureDataFactoryService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder => builder
            .AllowAnyOrigin()  // Permite qualquer origem
            .AllowAnyMethod()  // Permite qualquer método HTTP (GET, POST, etc)
            .AllowAnyHeader()); // Permite qualquer cabeçalho
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAllOrigins");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
