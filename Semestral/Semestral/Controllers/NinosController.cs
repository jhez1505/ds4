using Microsoft.AspNetCore.Mvc;
using Guarderia.api.Data;
using Guarderia.api.Models;

namespace Guarderia.api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NinosController : ControllerBase
    {
        private readonly GuarderiaDbContext _context;

        public NinosController(GuarderiaDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_context.Ninos.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var nino = _context.Ninos.Find(id);
            if (nino == null) return NotFound();
            return Ok(nino);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Nino nino)
        {
            _context.Ninos.Add(nino);
            _context.SaveChanges();
            return Ok(nino);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Nino nino)
        {
            var existente = _context.Ninos.Find(id);
            if (existente == null) return NotFound();

            existente.Nombre = nino.Nombre;
            existente.Apellido = nino.Apellido;
            existente.FechaNacimiento = nino.FechaNacimiento;
            existente.CondicionMedica = nino.CondicionMedica;
            existente.Alergias = nino.Alergias;
            existente.Estado = nino.Estado;

            _context.SaveChanges();
            return Ok(existente);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var nino = _context.Ninos.Find(id);
            if (nino == null) return NotFound();

            _context.Ninos.Remove(nino);
            _context.SaveChanges();
            return Ok("Niño eliminado");
        }
    }
}
