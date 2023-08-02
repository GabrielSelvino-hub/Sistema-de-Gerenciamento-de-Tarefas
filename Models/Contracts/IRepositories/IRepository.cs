namespace Sistema_de_Gerenciamento_de_Tarefas.Models.Repositories
{
    public interface IRepository<T, Y>
    {
        void Cadastrar(T entidade);
        List<T> Listar();
        T PesquisarPorId(Y Id);
        void Atualizar(T entidade);
        void Excluir(Y Id);
    }
}
