using Aula05.Application.Contratos;
using Aula05.Domain.Models;
using Aula05.Infraestrutura.ExternalServices;

namespace Aula05.Application.Service
{
    public class ClienteService : IClienteService
    {
        private readonly ClienteHttpClient _clienteHttpClient;

        public ClienteService(ClienteHttpClient clienteHttpClient)
        {
            _clienteHttpClient = clienteHttpClient;
        }

        public Task AtualizaCliente(Cliente cliente)
        {
            return _clienteHttpClient.AtualizarClienteAsync(cliente); 
        }

        public async Task<List<Cliente>> ObterClientesAsync()
        {
            return await _clienteHttpClient.BuscarClientesAsync();
        }
    }
}
