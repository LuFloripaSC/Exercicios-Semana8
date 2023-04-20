using S08__NovoProjetoBanco.Models;
using System;


namespace S08__NovoProjetoBanco.Interfaces
{
    public interface IClienteServices
    {
        void NovaConta(Cliente cliente);
        List<PessoaFisica> MostrarClientesPF();
        List<PessoaJuridica> MostrarClientesJP();
        Cliente BuscarCliente(int id);
        Cliente AtualizarPessoaFisica(PessoaFisica pessoaFisica, int id);
        Cliente AtualizarPessoaJuridica(PessoaJuridica pessoaJuridica, int id);
        void DeletarCliente(int id);
        void IncluirTransacao(Transacao transacao, int idCliente);
        List<Transacao> ExibirTransacao(int idCliente);
    }
}
