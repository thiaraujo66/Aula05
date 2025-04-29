using Aula05.Application.Contratos;
using Aula05.Domain.Models;
using Aula05.Models.Cliente;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;

namespace Aula05.Controllers
{
    public class ClienteController : Controller
    {
        private readonly IClienteService _clienteService;

        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        public async Task<IActionResult> Index()
        {
            List<Cliente> retorno = await _clienteService.ObterClientesAsync();

            List<ClienteModel> clientes = new List<ClienteModel>();

            retorno.ForEach(x => 
            {
                ClienteModel cliente = new ClienteModel();

                cliente = ClasseParaModelo(x);

                clientes.Add(cliente);
            });

            return View(clientes);
        }

        private ClienteModel ClasseParaModelo(Cliente cliente) 
        {
            return new ClienteModel
            {
                Id = cliente.Id,
                Nome = cliente.Nome,
                Email = cliente.Email
            };
        }
    }
}
