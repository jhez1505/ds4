using Microsoft.AspNetCore.Mvc.RazorPages;
using Semestralv1._2.Models;
using System.Net.Http.Json;

namespace Semestralv1._2.Pages.Usuarios
{
    public class IndexModel : PageModel
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _config;

        public List<UsuarioDto> Usuarios { get; set; } = new();

        public IndexModel(IHttpClientFactory httpClientFactory, IConfiguration config)
        {
            _httpClientFactory = httpClientFactory;
            _config = config;
        }

        public async Task OnGet()
        {
            var client = _httpClientFactory.CreateClient();
            var url = $"{_config["ApiSettings:BaseUrl"]}/api/Usuarios";

            Usuarios = await client.GetFromJsonAsync<List<UsuarioDto>>(url)
                       ?? new List<UsuarioDto>();
        }
    }
}
