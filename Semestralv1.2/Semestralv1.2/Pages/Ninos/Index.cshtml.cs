using Microsoft.AspNetCore.Mvc.RazorPages;
using Semestralv1._2.Models;
using System.Net.Http.Json;

namespace Semestralv1._2.Pages.Ninos
{
    public class IndexModel : PageModel
    {
        private readonly IHttpClientFactory _factory;
        private readonly IConfiguration _config;

        public List<NinoDto> Ninos { get; set; } = new();

        public IndexModel(IHttpClientFactory factory, IConfiguration config)
        {
            _factory = factory;
            _config = config;
        }

        public async Task OnGet()
        {
            var client = _factory.CreateClient();
            var url = $"{_config["ApiSettings:BaseUrl"]}/api/Ninos";

            Ninos = await client.GetFromJsonAsync<List<NinoDto>>(url)
                    ?? new List<NinoDto>();
        }
    }
}
