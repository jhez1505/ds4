using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Semestralv1._2.Models;
using System.Net.Http.Json;

namespace Semestralv1._2.Pages.Usuarios.Edit
{
    public class EditModel : PageModel
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _config;

        [BindProperty]
        public UsuarioDto Usuario { get; set; } = new();

        public EditModel(IHttpClientFactory httpClientFactory, IConfiguration config)
        {
            _httpClientFactory = httpClientFactory;
            _config = config;
        }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var url = $"{_config["ApiSettings:BaseUrl"]}/api/Usuarios/{id}";

            var response = await client.GetAsync(url);

            if (!response.IsSuccessStatusCode)
                return RedirectToPage("/Usuarios/Index");

            Usuario = await response.Content.ReadFromJsonAsync<UsuarioDto>()
                      ?? new UsuarioDto();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            var client = _httpClientFactory.CreateClient();
            var url = $"{_config["ApiSettings:BaseUrl"]}/api/Usuarios/{Usuario.UserID}";

            var response = await client.PutAsJsonAsync(url, Usuario);

            if (!response.IsSuccessStatusCode)
                return Page();

            return RedirectToPage("/Usuarios/Index");
        }
    }
}
