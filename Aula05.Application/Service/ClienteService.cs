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

        public Task CriarClienteAsync(Cliente cliente)
        {
            if (cliente == null)
                throw new Exception("O cliente deve ser preenchido corretamente");

            if (string.IsNullOrEmpty(cliente.Nome))
                throw new Exception("O nome do cliente deve ser preenchido");

            return _clienteHttpClient.CriarClienteAsync(cliente);
        }

        public Task ExcluirClienteAsync(int id)
        {
            return _clienteHttpClient.ExcluirClienteAsync(id);
        }

        public async Task<Cliente> ObterClienteAsync(int id)
        {
            return await _clienteHttpClient.ObterClienteAsync(id);
        }

        public async Task<List<Cliente>> ObterClientesAsync()
        {
            return await _clienteHttpClient.BuscarClientesAsync();
        }
    }
}
