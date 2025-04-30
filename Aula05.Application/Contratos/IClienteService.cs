using Aula05.Domain.Models;

namespace Aula05.Application.Contratos
{
    public interface IClienteService
    {
        Task<List<Cliente>> ObterClientesAsync();
        Task AtualizaCliente(Cliente cliente);
    }
}
