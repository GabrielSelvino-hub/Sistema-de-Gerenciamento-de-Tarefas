using Sistema_de_Gerenciamento_de_Tarefas.Context;
using Sistema_de_Gerenciamento_de_Tarefas.Models.Contracts.IRepositories;

namespace Sistema_de_Gerenciamento_de_Tarefas.Models.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly Contexto _context;

        public UsuarioRepository(Contexto context)
        {
            _context = context;
        }

        public void Atualizar(IUsuarioRepository entidade)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(IUsuarioRepository entidade)
        {
            throw new NotImplementedException();
        }

        public void Excluir(int Id)
        {
            throw new NotImplementedException();
        }

        public List<IUsuarioRepository> Listar()
        {
            throw new NotImplementedException();
        }

        public IUsuarioRepository PesquisarPorId(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
