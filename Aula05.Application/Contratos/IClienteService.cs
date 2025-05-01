using Aula05.Domain.Models;

namespace Aula05.Application.Contratos
{
    public interface IClienteService
    {
        Task<List<Cliente>> ObterClientesAsync();
        Task AtualizaCliente(Cliente cliente);
        Task<Cliente> ObterClienteAsync(int id);
        Task CriarClienteAsync(Cliente cliente);
        Task ExcluirClienteAsync(int id);
    }
}
