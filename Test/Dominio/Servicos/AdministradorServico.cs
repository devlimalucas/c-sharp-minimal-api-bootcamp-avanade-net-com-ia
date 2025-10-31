using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using minimal_api.Dominio.Servicos;
using MinimalApi.Dominio.Entidades;
using MinimalApi.Infraestrutura.Db;

namespace Test.Domain.Entidades;

[DoNotParallelize]
[TestClass]
public sealed class AdministradorServicoTest
{
    private DbContexto CriarContextoDeTeste()
    {
        var assemblyPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        var path = Path.GetFullPath(Path.Combine(assemblyPath ?? "", "..", "..", ".."));

        var builder = new ConfigurationBuilder()
            .SetBasePath(path ?? Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddEnvironmentVariables();

        var configuration = builder.Build();

        return new DbContexto(configuration);
    }

    [TestMethod]
    public void TestandoSalvarAdministrador()
    {
        // Arrange
        var context = CriarContextoDeTeste();
        context.Database.ExecuteSqlRaw("TRUNCATE TABLE Administradores");

        var administradorServico = new AdministradorServico(context);

        var adm = new Administrador();

        adm.Email = "test@teste.com";
        adm.Senha = "123456";
        adm.Perfil = "Adm";

        // Act
        administradorServico.Incluir(adm);

        // Assert
        Assert.AreEqual(adm.Id, administradorServico.Todos(adm.Id).Count());
    }

    [TestMethod]
    public void TestandoBusPorId()
    {
        // Arrange
        var context = CriarContextoDeTeste();
        context.Database.ExecuteSqlRaw("TRUNCATE TABLE Administradores");

        var administradorServico = new AdministradorServico(context);

        var adm = new Administrador();
        adm.Email = "lltest@teste.com";
        adm.Senha = "123456";
        adm.Perfil = "Adm";

        // Act
        administradorServico.Incluir(adm);
        var admsDoBanco = administradorServico.BuscaPorId(adm.Id);

        // Assert
        Assert.AreEqual(adm.Id, admsDoBanco.Id);
    }
}
