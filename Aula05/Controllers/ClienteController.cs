using Aula05.Application.Contratos;
using Aula05.Domain.Models;
using Aula05.Models.Cliente;
using Microsoft.AspNetCore.Mvc;

namespace Aula05.Controllers
{
    public class ClienteController : Controller
    {

        #region [ Constantes ]

        private readonly IClienteService _clienteService;

        #endregion

        #region [ Construtores ]

        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        #endregion

        #region [ Métodos Públicos ]

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
            Cliente cliente = await _clienteService.ObterClienteAsync(Id);

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

        public IActionResult Criar() 
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Criar(ClienteModel cliente) 
        {
            if (!ModelState.IsValid) return View(cliente);

            Cliente novoCliente = ModeloParaClasse(cliente);

            await _clienteService.CriarClienteAsync(novoCliente);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Excluir(int id) 
        {
            Cliente cliente = await _clienteService.ObterClienteAsync(id);

            if (cliente == null) return NotFound();

            ClienteModel model = ClasseParaModelo(cliente);

            return View(model);
        }

        [HttpPost, ActionName("ExcluirConfirmado")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ExcluirConfirmado(int id) 
        {
            await _clienteService.ExcluirClienteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        #endregion

        #region [ Métodos Privados ]

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

        #endregion
    }
}
