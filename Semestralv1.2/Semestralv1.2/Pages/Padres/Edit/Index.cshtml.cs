using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Semestralv1._2.Models;
using System.Net.Http.Json;

namespace Semestralv1._2.Pages.Padres.Edit
{
    public class EditModel : PageModel
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _config;

        [BindProperty]
        public PadreDto Padre { get; set; } = new();

        public EditModel(IHttpClientFactory httpClientFactory, IConfiguration config)
        {
            _httpClientFactory = httpClientFactory;
            _config = config;
        }

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


        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            var client = _httpClientFactory.CreateClient();
            var url = $"{_config["ApiSettings:BaseUrl"]}/api/Padres/{Padre.ParentID}";

            var response = await client.PutAsJsonAsync(url, Padre);

            if (!response.IsSuccessStatusCode)
                return Page(); 

            return RedirectToPage("/Padres/Index");
        }
    }
}
