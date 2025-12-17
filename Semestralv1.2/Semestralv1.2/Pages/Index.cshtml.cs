using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http.Json;
using Semestralv1._2.Models;

namespace Semestralv1._2.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _config;

        public DashboardDto Dashboard { get; set; } = new();

        public IndexModel(IHttpClientFactory httpClientFactory, IConfiguration config)
        {
            _httpClientFactory = httpClientFactory;
            _config = config;
        }

        public async Task OnGet()
        {
            var client = _httpClientFactory.CreateClient();
            var url = $"{_config["ApiSettings:BaseUrl"]}/api/Dashboard";

            Dashboard = await client.GetFromJsonAsync<DashboardDto>(url)
                         ?? new DashboardDto();
        }
    }
}
