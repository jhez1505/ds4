using Microsoft.AspNetCore.Mvc.RazorPages;
using Semestralv1._2.Models;
using System.Text.Json;

namespace Semestralv1._2.Pages.Padres
{
    public class IndexModel : PageModel
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _config;

        public List<PadreDto> Padres { get; set; } = new();

        public IndexModel(IHttpClientFactory httpClientFactory, IConfiguration config)
        {
            _httpClientFactory = httpClientFactory;
            _config = config;
        }

        public async Task OnGet()
        {
            var client = _httpClientFactory.CreateClient();
            var url = $"{_config["ApiSettings:BaseUrl"]}/api/Padres";

            var response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                Padres = JsonSerializer.Deserialize<List<PadreDto>>(json,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true })
                    ?? new List<PadreDto>();
            }
        }
    }
}
