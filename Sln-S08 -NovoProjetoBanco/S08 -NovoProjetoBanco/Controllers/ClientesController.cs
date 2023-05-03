using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using S08__NovoProjetoBanco.Interfaces;
using S08__NovoProjetoBanco.Models;
using S08__NovoProjetoBanco.Services;

namespace S08__NovoProjetoBanco.Controllers
{
    [Route("clientes]")]
    [ApiController]
    public class ClientesController : Controller
    {
        IClienteServices _clienteServices;

        public ClientesController(IClienteServices clienteServices)
        {
            _clienteServices = clienteServices;
        }

        [HttpGet]
        [Route("pessoaFisica")]
        public ActionResult ExibirPessoaFisica()
        {
            return Ok(_clienteServices.MostrarClientesPF());
        }

        [HttpGet]
        [Route("pessoaJuridica")]
        public ActionResult ExibirPessoaJuridica()
        {
            return Ok(_clienteServices.MostrarClientesPJ());
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult GetPorId([FromRoute] int id)
        {
            return Ok(_clienteServices.BuscarCliente(id));
        }

        [HttpPost]
        [Route("pessoaFisica")]
        public ActionResult PostPessoaFisica([FromBody] PessoaFisica pessoaFisica)
        {
            _clienteServices.NovaConta(pessoaFisica);
            return Created(Request.Path, pessoaFisica);
        }

        [HttpPost]
        [Route("pessoaJuridica")]
        public ActionResult PostPessoaJuridica([FromBody] PessoaJuridica pessoaJuridica)
        {
            _clienteServices.NovaConta(pessoaJuridica);
            return Created(Request.Path, pessoaJuridica);
        }

        [HttpPut]
        [Route("pessoaFisica/{id}")]
        public ActionResult AtualizarPessoaFisica([FromBody] PessoaFisica pessoaFisica, int id)
        {
            _clienteServices.AtualizarPessoaFisica(pessoaFisica, id);
            return Ok();
        }

        [HttpPut]
        [Route("pessoaJuridica/{id}")]
        public ActionResult AtualizarPessoaJuridica([FromBody] PessoaJuridica pessoaJuridica, int id)
        {
            _clienteServices.AtualizarPessoaJuridica(pessoaJuridica, id);
            return Ok();
        }

        [HttpDelete]
        [Route("{id}")]
        public ActionResult DeletarCliente([FromRoute] int id)
        {
            Cliente clienteDeletar = _clienteServices.BuscarCliente(id);

            if (clienteDeletar.Saldo != 0)
            {
                return BadRequest($"Não foi possível deletar cliente. Cliente com saldo de: {clienteDeletar.Saldo}");
            }
            _clienteServices.DeletarCliente(id);
            return Ok();
        }
    }
}
