﻿using EcommerceAPI.DTO;
using EcommerceAPI.Models;

namespace EcommerceAPI.interfaces
{
    public interface IPagamentosRepository
    {
        List<Pagamento> ListarTodos();

        Pagamento BuscarPOId(int id);

        void Cadastrar(CadastrarPagamentoDTO pagamento);

        void Atualizar(int id,Pagamento pagamento);

        void Deletar(int id);

    }
}
