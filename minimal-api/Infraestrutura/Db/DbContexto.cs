using Microsoft.EntityFrameworkCore;
using MinimalApi.Dominio.Entidades;

namespace MinimalApi.Infraestrutura.Db;

class DbContexto : DbContext
{
    private readonly IConfiguration _configuracaoAppSettings;
    public DbContexto(IConfiguration configurationAppSettings)
    {
        _configuracaoAppSettings = configurationAppSettings;
    }
    public DbSet<Administrador> Administradores { get; set; } = default!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if(!optionsBuilder.IsConfigured)
        {
                    var stringConexao = _configuracaoAppSettings.GetConnectionString("mysql");

        if (!string.IsNullOrEmpty(stringConexao))
        {
            optionsBuilder.UseMySql(
                stringConexao,
                ServerVersion.AutoDetect(stringConexao));
        }

        }

    }
}