using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Semestralv1._2.Models;
using System.Net.Http.Json;

namespace Semestralv1._2.Pages.Facturas
{
    public class DetailsModel : PageModel
    {
        private readonly IHttpClientFactory _factory;
        private readonly IConfiguration _config;

        public FacturaDto Factura { get; set; } = new();

        public DetailsModel(IHttpClientFactory factory, IConfiguration config)
        {
            _factory = factory;
            _config = config;
        }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var client = _factory.CreateClient();
            var url = $"{_config["ApiSettings:BaseUrl"]}/api/Facturas/{id}";

            var response = await client.GetAsync(url);
            if (!response.IsSuccessStatusCode)
                return RedirectToPage("Index");

            Factura = await response.Content.ReadFromJsonAsync<FacturaDto>()
                      ?? new FacturaDto();

            return Page();
        }
    }
}
