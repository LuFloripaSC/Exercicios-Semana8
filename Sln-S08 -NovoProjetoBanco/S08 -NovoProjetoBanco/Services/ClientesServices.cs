using S08__NovoProjetoBanco.Models;
using Microsoft.AspNetCore.Mvc;

namespace S08__NovoProjetoBanco.Services;

public class ClientesServices

{
    static List<Cliente> _clientes = new();

    public void CriarConta(Cliente cliente)
    {
        _clientes.Add(cliente);
    }

    public Cliente BuscarCliente()
    {
        Console.WriteLine("Digite o número da conta");
        var op = int.Parse(Console.ReadLine());

        var cliente = _clientes.Find(x => x.NumeroConta == op);
        return cliente;
    }

    public void ExibirClientes()
    {
        foreach (var cliente in _clientes)
        {
            Console.WriteLine(cliente.ResumoCliente());
        }
    }


}
