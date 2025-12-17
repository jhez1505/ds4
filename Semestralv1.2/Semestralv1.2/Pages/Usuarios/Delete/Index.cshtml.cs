using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class DeleteModel : PageModel
{
    private readonly IHttpClientFactory _factory;
    private readonly IConfiguration _config;

    public int UserID { get; set; }

    public DeleteModel(IHttpClientFactory factory, IConfiguration config)
    {
        _factory = factory;
        _config = config;
    }

    public void OnGet(int id)
    {
        UserID = id;
    }

    public async Task<IActionResult> OnPostAsync(int id)
    {
        var client = _factory.CreateClient();
        await client.DeleteAsync(
            $"{_config["ApiSettings:BaseUrl"]}/api/Usuarios/{id}"
        );

        return RedirectToPage("../Index");
    }
}
