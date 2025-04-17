using EcommerceAPI.Models;

namespace EcommerceAPI.interfaces
{
    public interface IProdutoRepository
    {//R - read (LEitura)
        //Retorno
        List<Produto> ListarTodos();
        //Recebe um identificador, e retornaro produtocorrespondente

        Produto BuscarPOId(int id);

        // C - Create (Cadastro)

        void Cadastrar(Produto produto);

        //U - Update (Atualizacao)
        //Recebe um identificador para encontrar um produto, e recebe o produtonovo para substituir o antigo

        void Atualizar(int id, Produto produto);

        //D - delete(delecao)
        //Receber o identificador de quem quero excluir

        void Deletar(int id);
    }
}
