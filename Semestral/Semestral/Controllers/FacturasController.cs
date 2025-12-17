using Microsoft.AspNetCore.Mvc;
using Guarderia.api.Data;

namespace Guarderia.api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FacturasController : ControllerBase
    {
        private readonly GuarderiaDbContext _context;

        public FacturasController(GuarderiaDbContext context)
        {
            _context = context;
        }

        // GET: api/Facturas
        [HttpGet]
        public IActionResult GetAll()
        {
            var facturas = _context.Facturas
                .OrderByDescending(f => f.FechaEmision)
                .ToList();

            return Ok(facturas);
        }

        // GET: api/Facturas/5
        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var factura = _context.Facturas.Find(id);
            if (factura == null) return NotFound();
            return Ok(factura);
        }
    }
}
