using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using S08__NovoProjetoBanco.Interfaces;
using S08__NovoProjetoBanco.Models;
using S08__NovoProjetoBanco.Services;
using System;

namespace S08__NovoProjetoBanco.Controllers
{
    [Microsoft.AspNetCore.Components.Route("transacao")]
    [Route("api/[controller]")]
    [ApiController]
    public class TransacaoController : Controller
    {
        public readonly IClienteServices _clienteServices;


        public TransacaoController(IClienteServices clienteServices)
        {
            _clienteServices = clienteServices;
        }

        [HttpPost("/Transacoes/{idCliente")]
        public ActionResult<string> IncluirTransacao([FromBody] Transacao transacao, [FromRoute] int idCliente)
        {
            try
            {
                Cliente cliente = _clienteServices.BuscarCliente(idCliente);
                if (cliente != null)
                {
                    cliente.Extrato.Add(transacao);
                    return Ok("Transação adicionada com sucesso!");
                }
                return BadRequest("Cliente não encontrado");
            }
            catch (System.Exception)
            {
                return BadRequest("Ocorreu um erro na requisição");
            }
        }

        [HttpGet("/Transacoes/{idCliente")]
        public ActionResult<string> ExibirTransacao(int idCliente)
        {
            try
            {
                Cliente cliente = _clienteServices.BuscarCliente(idCliente);
                if (cliente != null)
                {
                    return Ok(cliente.Extrato);
                }

                return BadRequest("Cliente não encontrato.");
            }
            catch (System.Exception)
            {
                return BadRequest("Ocorreu um erro na requisição");
            }
        }
    }

}
