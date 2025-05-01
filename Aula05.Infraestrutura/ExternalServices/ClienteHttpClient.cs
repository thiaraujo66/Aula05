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

        public async Task<Cliente> ObterClienteAsync(int id) 
        {
            return await _httpClient.GetFromJsonAsync<Cliente>($"https://localhost:44390/api/Cliente/{id}") ?? new Cliente();
        }

        public async Task ExcluirClienteAsync(int id) 
        {
            await _httpClient.DeleteAsync($"https://localhost:44390/api/Cliente/{id}");
        }

        public async Task CriarClienteAsync(Cliente cliente) 
        {
            await _httpClient.PostAsJsonAsync($"https://localhost:44390/api/Cliente", cliente);
        }
    }
}
