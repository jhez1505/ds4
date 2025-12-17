using Microsoft.AspNetCore.Mvc;
using Guarderia.api.Data;
using Guarderia.api.Models;

namespace Guarderia.api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PagosController : ControllerBase
    {
        private readonly GuarderiaDbContext _context;

        public PagosController(GuarderiaDbContext context)
        {
            _context = context;
        }

        // GET: api/Pagos
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_context.Pagos.ToList());
        }

        // POST: api/Pagos
        [HttpPost]
        public IActionResult Create([FromBody] Pago dto)
        {
            // 1️⃣ Crear Pago
            var pago = new Pago
            {
                ParentID = dto.ParentID,
                ChildID = dto.ChildID,
                Monto = dto.Monto,
                MetodoPago = dto.MetodoPago,
                Referencia = dto.Referencia,
                Observacion = dto.Observacion,
                FechaPago = DateTime.Now
            };

            _context.Pagos.Add(pago);
            _context.SaveChanges();

            // 2️⃣ Crear Factura automáticamente
            var factura = new Factura
            {
                PagoID = pago.PagoID,
                ParentID = pago.ParentID,
                ChildID = pago.ChildID,
                FechaEmision = DateTime.Now,
                MontoTotal = pago.Monto
            };

            _context.Facturas.Add(factura);
            _context.SaveChanges();

            return Ok(new
            {
                Pago = pago,
                Factura = factura
            });
        }
    }
}
