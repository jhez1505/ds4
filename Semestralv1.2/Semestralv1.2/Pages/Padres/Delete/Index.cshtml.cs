using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Semestralv1._2.Models;
using System.Net.Http.Json;

namespace Semestralv1._2.Pages.Padres.Delete
{
    public class DeleteModel : PageModel
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _config;

        [BindProperty]
        public PadreDto Padre { get; set; } = new();

        public DeleteModel(IHttpClientFactory httpClientFactory, IConfiguration config)
        {
            _httpClientFactory = httpClientFactory;
            _config = config;
        }

        // Cargar datos para confirmar
        public async Task<IActionResult> OnGetAsync(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var url = $"{_config["ApiSettings:BaseUrl"]}/api/Padres/{id}";

            var response = await client.GetAsync(url);

            if (!response.IsSuccessStatusCode)
                return RedirectToPage("/Padres/Index");

            Padre = await response.Content.ReadFromJsonAsync<PadreDto>()
                    ?? new PadreDto();

            return Page();
        }

        // Confirmar eliminación
        public async Task<IActionResult> OnPostAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var url = $"{_config["ApiSettings:BaseUrl"]}/api/Padres/{Padre.ParentID}";

            var response = await client.DeleteAsync(url);

            if (!response.IsSuccessStatusCode)
                return Page();

            return RedirectToPage("/Padres/Index");
        }

    }
}
