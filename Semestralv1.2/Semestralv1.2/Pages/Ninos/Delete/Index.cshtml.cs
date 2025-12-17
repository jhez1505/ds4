using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Semestralv1._2.Models;
using System.Net.Http.Json;

namespace Semestralv1._2.Pages.Ninos.Delete
{
    public class DeleteModel : PageModel
    {
        private readonly IHttpClientFactory _factory;
        private readonly IConfiguration _config;

        [BindProperty]
        public NinoDto Nino { get; set; } = new();

        public DeleteModel(IHttpClientFactory factory, IConfiguration config)
        {
            _factory = factory;
            _config = config;
        }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var client = _factory.CreateClient();
            var url = $"{_config["ApiSettings:BaseUrl"]}/api/Ninos/{id}";

            var response = await client.GetAsync(url);
            if (!response.IsSuccessStatusCode)
                return RedirectToPage("/Ninos/Index");

            Nino = await response.Content.ReadFromJsonAsync<NinoDto>()
                   ?? new NinoDto();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var client = _factory.CreateClient();
            var url = $"{_config["ApiSettings:BaseUrl"]}/api/Ninos/{Nino.ChildID}";

            await client.DeleteAsync(url);
            return RedirectToPage("/Ninos/Index");
        }
    }
}
