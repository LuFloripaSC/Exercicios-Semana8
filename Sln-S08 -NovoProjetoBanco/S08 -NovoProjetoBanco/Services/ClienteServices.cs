using S08__NovoProjetoBanco.Models;
using Microsoft.AspNetCore.Mvc;
using S08__NovoProjetoBanco.Interfaces;

namespace S08__NovoProjetoBanco.Services
{
    public class ClienteServices : IClienteServices

    {
        static List<Cliente> _clientes = new();

        public void NovaConta(Cliente cliente)
        {
            _clientes.Add(cliente);
        }

        public List<PessoaFisica> MostrarClientesPF()
        {
            List<PessoaFisica> clientesPF = _clientes.OfType<PessoaFisica>().ToList();
            return clientesPF;
        }

        public List<PessoaJuridica> MostrarClientesPJ()
        {
            List<PessoaJuridica> clientesPJ = _clientes.OfType<PessoaJuridica>().ToList();
            return clientesPJ;
        }

        public Cliente BuscarCliente(int id)
        {
            Console.WriteLine("Digite o número da conta");
            var op = int.Parse(Console.ReadLine());

            var cliente = _clientes.Find(x => x.NumeroConta == op);
            return cliente;
        }

        public void DeletarCliente(int id)
        {
            _clientes.Remove(BuscarCliente(id));
        }

        public Cliente AtualizarPessoaFisica(PessoaFisica pessoaFisica, int id)
        {
            PessoaFisica newPessoaFisica = BuscarCliente(id) as PessoaFisica;

            if (pessoaFisica != null)
            {
                newPessoaFisica.Email = pessoaFisica.Email;
                newPessoaFisica.Telefone = pessoaFisica.Telefone;
                newPessoaFisica.Endereco = pessoaFisica.Endereco;
                newPessoaFisica.Nome = pessoaFisica.Nome;
                newPessoaFisica.CPF = pessoaFisica.CPF;
                newPessoaFisica.DataNascimento = pessoaFisica.DataNascimento;
            }

            return newPessoaFisica;
        }

        public Cliente AtualizarPessoaJuridica(PessoaJuridica pessoaJuridica, int id)
        {
            PessoaJuridica newPessoaJuridica = BuscarCliente(id) as PessoaJuridica;

            if (pessoaJuridica != null)
            {
                newPessoaJuridica.Email = pessoaJuridica.Email;
                newPessoaJuridica.Telefone = pessoaJuridica.Telefone;
                newPessoaJuridica.Endereco = pessoaJuridica.Endereco;
                newPessoaJuridica.CNPJ = newPessoaJuridica.CNPJ;
                newPessoaJuridica.RazaoSocial = pessoaJuridica.RazaoSocial;
                newPessoaJuridica.NomeFantasia = pessoaJuridica.NomeFantasia;
                newPessoaJuridica.DataAbertura = pessoaJuridica.DataAbertura;
            }

            return newPessoaJuridica;
        }
        public void IncluirTransacao(Transacao transacao, int idCliente)
        {
            Cliente cliente = BuscarCliente(idCliente);

            cliente.Extrato.Add(transacao); 
        }

        public List<Transacao> ExibirTransacao(int idCliente)
        {
            Cliente cliente = BuscarCliente(idCliente);

            return cliente.Extrato;
        }

    }
}
