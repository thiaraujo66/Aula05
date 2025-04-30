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

        public async Task<IActionResult> Editar(int Id) 
        {
            var clientes = await _clienteService.ObterClientesAsync();
            var cliente = clientes.FirstOrDefault(x => x.Id == Id);

            if (cliente == null) return NotFound();

            ClienteModel clienteModel = new ClienteModel();

            clienteModel = ClasseParaModelo(cliente);

            return View(clienteModel);
        }

        [HttpPost]
        public async Task<IActionResult> Editar(ClienteModel pCliente)
        {
            if (!ModelState.IsValid) return View(pCliente);

            Cliente cliente = ModeloParaClasse(pCliente);

            await _clienteService.AtualizaCliente(cliente);

            return RedirectToAction(nameof(Index));
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

        private Cliente ModeloParaClasse(ClienteModel cliente)
        {
            return new Cliente
            {
                Id = cliente.Id,
                Nome = cliente.Nome,
                Email = cliente.Email
            };
        }
    }
}
