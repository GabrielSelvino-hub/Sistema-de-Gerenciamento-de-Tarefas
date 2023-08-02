using System.ComponentModel.DataAnnotations;

namespace Sistema_de_Gerenciamento_de_Tarefas.ViewModels
{
    public class LoginModel
    {
        [Key]
        public int UserId { get; set; }

        [Required(ErrorMessage = "O Campo Usuario é obrigatorio.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "O Campo Senha é obrigatorio.")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }


    }
}
