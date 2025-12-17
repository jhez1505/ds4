using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Semestralv1._2.Models;
using System.Net.Http.Json;

namespace Semestralv1._2.Pages.Pagos.Create
{
    public class CreateModel : PageModel
    {
        private readonly IHttpClientFactory _factory;
        private readonly IConfiguration _config;

        [BindProperty]
        public PagoDto Pago { get; set; } = new();

        public CreateModel(IHttpClientFactory factory, IConfiguration config)
        {
            _factory = factory;
            _config = config;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var client = _factory.CreateClient();
            var url = $"{_config["ApiSettings:BaseUrl"]}/api/Pagos";

            var response = await client.PostAsJsonAsync(url, Pago);

            if (!response.IsSuccessStatusCode)
                return Page();

            return RedirectToPage("/Pagos/Index");
        }
    }
}
