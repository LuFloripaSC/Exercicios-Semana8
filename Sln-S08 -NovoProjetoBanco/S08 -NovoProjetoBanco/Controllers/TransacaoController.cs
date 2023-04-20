using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using S08__NovoProjetoBanco.Interfaces;
using System;

namespace S08__NovoProjetoBanco.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransacaoController : Controller
    {
        private IClienteServices _clienteService;
    }

    public TransacaoController(IClienteServices clienteServices)
    {
        _clienteService = clienteServices;
    }

    [HttpPost ("{idCliente")]
    public ActionResult IncluirTransacao([FromBody] Transacao transacao, [FromRoute] int idCliente)
    {
        _clienteService.IncluirTransacao(transacao, idCliente);
        return Created(Request.Path, transacao);
    }

    [HttpGet ("{idCliente")]
    public ActionResult ExibirTransacao([FromRoute] int idCliente)
    {
        return Ok(_clienteService.ExibirTransacao(idCliente));
    }

}
