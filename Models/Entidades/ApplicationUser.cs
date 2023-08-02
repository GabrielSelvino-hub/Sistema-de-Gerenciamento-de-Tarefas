using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sistema_de_Gerenciamento_de_Tarefas.Models.Entidades
{
    [Table("ApplicationUser")]
    public class ApplicationUser : IdentityUser
    {
        [Display(Name = "Id")]
        [Column("Id")]
        public int userId { get; set; }
        [Display(Name = "Nome")]
        [Column("Nome")]
        public string userName { get; set; }
        [Display(Name = "Senha")]
        [Column("Senha")]
        public string senha { get; set; }

    }
}
