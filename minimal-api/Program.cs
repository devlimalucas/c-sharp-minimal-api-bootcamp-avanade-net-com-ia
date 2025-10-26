using Microsoft.OpenApi.Models;
using MinimalApi.DTOs;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Minha API (.NET 9)", Version = "v1" });
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

app.MapGet("/", () => "API .NET 9 funcionando 👌");

app.MapPost("/login", (LoginDTO loginDTO) => {
     if (loginDTO.Email == "adm@teste.com" && loginDTO.Senha == "123456")
         return Results.Ok("Login com sucesso");
     else
         return Results.Unauthorized();
});

app.UseHttpsRedirection();
app.UseAuthorization();

app.Run();
