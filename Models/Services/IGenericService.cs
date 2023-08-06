namespace Sistema_de_Gerenciamento_de_Tarefas.Models.Services
{
    public interface IGenericService<T, Y>
    {
        void Cadastrar(T entidade);
        List<T> Listar();
        T PesquisarPorId(int id);   
        void Atualizar(T entidade); 
        void Excluir(int id);
    }
}
