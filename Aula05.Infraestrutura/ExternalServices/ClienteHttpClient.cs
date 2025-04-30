using Aula05.Domain.Models;
using System.Net.Http.Json;

namespace Aula05.Infraestrutura.ExternalServices
{
    public class ClienteHttpClient
    {
        private readonly HttpClient _httpClient;

        public ClienteHttpClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Cliente>> BuscarClientesAsync() 
        {
            return await _httpClient.GetFromJsonAsync<List<Cliente>>("https://localhost:44390/api/Cliente") ?? new List<Cliente>();
        }

        public async Task AtualizarClienteAsync(Cliente cliente) 
        {
            await _httpClient.PutAsJsonAsync($"https://localhost:44390/api/Cliente/{cliente.Id}", cliente);
        }
    }
}
