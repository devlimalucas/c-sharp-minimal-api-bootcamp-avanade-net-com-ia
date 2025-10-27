using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using MinimalApi.DTOs;
using MinimalApi.Infraestrutura.Db;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Minha API (.NET 9)", Version = "v1" });
});

builder.Services.AddDbContext<DbContexto>(options => {
    options.UseMySql(
        builder.Configuration.GetConnectionString("mysql"),
        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("mysql")));
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Minha API v1");
    });
}

app.MapGet("/", () => "API .NET 9 funcionando!!");

app.MapPost("/login", (LoginDTO loginDTO) => {
     if (loginDTO.Email == "adm@teste.com" && loginDTO.Senha == "123456")
         return Results.Ok("Login com sucesso");
     else
         return Results.Unauthorized();
});

app.UseHttpsRedirection();
app.UseAuthorization();

app.Run();