using Microsoft.Data.SqlClient;
using Sistema_de_Gerenciamento_de_Tarefas.Enums;
using System.Configuration;
using System.Data.SqlClient;

namespace Sistema_de_Gerenciamento_de_Tarefas.Models
{
    public class UsuarioModel
    {
        
        public IConfiguration Configuration { get; }

        public  UsuarioModel(IConfiguration configuration)
        {
            Configuration = configuration;
            _conn = Configuration.GetConnectionString("DefaultConnection");
        }

        private readonly string _conn; 

        public int id { get; set; }
        public string Nome { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public PerfilEnum Perfil { get; set; }
        public string Senhha { get; set; } 
        public DateTime DataCadastro { get; set; }
        public DateTime? DataAtualizacao { get; set; }



        public bool PerformLogin() 
        {
            var result = false;
            var sql = "SELECT id, Nome, Senhha FROM Usuarios WHERE Nome = '" + this.Nome + "'"; // Incluído o campo Senhha na consulta SQL

            try
            {
                using (var cn = new SqlConnection(_conn))
                {
                    cn.Open();
                    using (var cmd = new SqlCommand(sql, cn))
                    {
                        using (var dr = cmd.ExecuteReader())
                        {
                            if (dr.HasRows)
                            {
                                if (dr.Read())
                                {
                                    if (this.Senhha == dr["Senhha"].ToString())
                                    {
                                        this.id = Convert.ToInt32(dr["id"]);
                                        this.Nome = dr["Nome"].ToString();
                                        result = true;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result; 
        }

    }
}
