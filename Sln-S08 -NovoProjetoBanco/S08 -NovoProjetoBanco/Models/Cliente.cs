using Microsoft.AspNetCore.Components.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S08__NovoProjetoBanco.Models

{
    public abstract class Cliente
    {
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Endereco { get; set; }
        public int NumeroConta { get; set; }
        public double Saldo
        {
            get { return ObterSaldo(); }
            private set { }
        }

        public abstract string ResumoCliente();

        public List<Transacao> Extrato { get; set; }

        public Cliente()
        {
            Extrato = new List<Transacao>();
        }

        public Cliente(string email, string telefone, string endereco, int numeroConta, List<Transacao> extrato)
        {
            Email = email;
            Telefone = telefone;
            Endereco = endereco;
            NumeroConta = numeroConta;
            Extrato = extrato;
        }
        private double ObterSaldo()
        {
            double saldo = 0;
            foreach (Transacao transacao in Extrato)
            {
                saldo += transacao.Valor;
            }

            return saldo;
        }
    }
}
