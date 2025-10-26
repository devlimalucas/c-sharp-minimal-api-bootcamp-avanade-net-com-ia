using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace minimal_api.Models
{
    public class LoginDTO
    {
        public string Email { get; set; } = default!;
        public string Senha { get; set; } = default!;
    }
}

// using Microsoft.OpenApi.Models;
// using minimal_api.Models;

// var builder = WebApplication.CreateBuilder(args);

// builder.Services.AddEndpointsApiExplorer();
// builder.Services.AddSwaggerGen(c =>
// {
//     c.SwaggerDoc("v1", new OpenApiInfo { Title = "Minha API (.NET 9)", Version = "v1" });
// });

// var app = builder.Build();

// if (app.Environment.IsDevelopment())
// {
//     app.UseSwagger();
//     app.UseSwaggerUI(c =>
//     {
//         c.SwaggerEndpoint("/swagger/v1/swagger.json", "Minha API v1");
//     });
// }

// app.MapGet("/", () => "API .NET 9 funcionando 👌");

// app.MapPost("/login", (LoginDTO loginDTO) => {
//     if (loginDTO.Email == "adm@teste.com" && loginDTO.Senha == "123456")
//         return Results.Ok("Login com sucesso");
//     else
//         return Results.Unauthorized();
// });

// app.UseHttpsRedirection();
// app.UseAuthorization();

// app.Run();