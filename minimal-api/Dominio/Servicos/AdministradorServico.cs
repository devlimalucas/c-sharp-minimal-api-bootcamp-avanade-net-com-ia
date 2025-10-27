using Microsoft.EntityFrameworkCore;
using minimal_api.Dominio.Interfaces;
using MinimalApi.Dominio.Entidades;
using MinimalApi.DTOs;
using MinimalApi.Infraestrutura.Db;

namespace minimal_api.Dominio.Servicos
{
    public class AdministradorServico(DbContexto contexto) : IAdministradorServico
    {
        private readonly DbContexto _contexto = contexto;

        public Administrador? Login(LoginDTO loginDTO)
        {
            var adm = _contexto.Administradores.Where(a => a.Email == loginDTO.Email && a.Senha == loginDTO.Senha).FirstOrDefault();

            return adm;
        }
    
    }
}