using Microsoft.OpenApi.Models;
using minimal_api.Models;

var builder = WebApplication.CreateBuilder(args);

// Adiciona controllers
builder.Services.AddControllers();

// Configura Swagger clássico
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Minha API (.NET 9)", Version = "v1" });
});

var app = builder.Build();

// Habilita Swagger no ambiente de desenvolvimento
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Minha API v1");
    });
}

// Rota raiz de teste
app.MapGet("/", () => "API .NET 9 funcionando 👌");

app.MapPost("/login", (LoginDTO loginDTO) => {
     if (loginDTO.Email == "adm@teste.com" && loginDTO.Senha == "123456")
         return Results.Ok("Login com sucesso");
     else
         return Results.Unauthorized();
});

// Mapeia controllers
app.MapControllers();

app.UseHttpsRedirection();
app.UseAuthorization();

app.Run();