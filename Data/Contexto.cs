using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sistema_de_Gerenciamento_de_Tarefas.Models.Entidades;
using Sistema_de_Gerenciamento_de_Tarefas.ViewModels;

namespace Sistema_de_Gerenciamento_de_Tarefas.Context
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {

        }
        public DbSet<ApplicationUser> Usuario { get; set; }

        public DbSet<LoginModel> LoginModel_1 { get; set; } = default!;

    }
}
