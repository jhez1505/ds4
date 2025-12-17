using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Semestralv1._2.Models;
using System.Net.Http.Json;

namespace Semestralv1._2.Pages.Usuarios.Create
{
    public class CreateModel : PageModel
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _config;

        [BindProperty]
        public UsuarioDto Usuario { get; set; } = new();

        public CreateModel(IHttpClientFactory httpClientFactory, IConfiguration config)
        {
            _httpClientFactory = httpClientFactory;
            _config = config;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var client = _httpClientFactory.CreateClient();

            var response = await client.PostAsJsonAsync(
                $"{_config["ApiSettings:BaseUrl"]}/api/Usuarios",
                Usuario
            );

            if (!response.IsSuccessStatusCode)
                return Page();

            return RedirectToPage("/Usuarios/Index");
        }
    }
}
