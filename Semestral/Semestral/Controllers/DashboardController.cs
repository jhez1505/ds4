using Guarderia.api.Data;
using Guarderia.api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Guarderia.api.Controllers
{
    [ApiController]
    [Route("api/Dashboard")]
    public class DashboardController : ControllerBase
    {
        private readonly GuarderiaDbContext _context;

        public DashboardController(GuarderiaDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var mesActual = DateTime.Now.Month;
            var anioActual = DateTime.Now.Year;

            var data = new Dashboard
            {
                Padres = _context.Padres.Count(),
                Ninos = _context.Ninos.Count(),

                PagosMes = _context.Pagos
                    .Count(p => p.FechaPago.Month == mesActual &&
                                p.FechaPago.Year == anioActual),

                Deudores = _context.Padres
                    .Count(p => !_context.Pagos.Any(pg => pg.ParentID == p.ParentID))
            };

            return Ok(data);
        }
    }
}
