using Microsoft.AspNetCore.Mvc;
using Guarderia.api.Data;
using Guarderia.api.Models;

namespace Guarderia.api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PadresController : ControllerBase
    {
        private readonly GuarderiaDbContext _context;

        public PadresController(GuarderiaDbContext context)
        {
            _context = context;
        }

        // GET: api/Padres
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_context.Padres.ToList());
        }

        // GET: api/Padres/1
        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var padre = _context.Padres.Find(id);
            if (padre == null) return NotFound();
            return Ok(padre);
        }

        // POST: api/Padres
        [HttpPost]
        public IActionResult Create([FromBody] PadreCreateDto dto)
        {
            // 1️⃣ Crear Padre
            var padre = new Padre
            {
                Cedula = dto.Cedula,
                Nombre = dto.Nombre,
                Apellido = dto.Apellido,
                Telefono = dto.Telefono,
                Correo = dto.Correo,
                Direccion = dto.Direccion,
                Estado = "Activo"
            };

            _context.Padres.Add(padre);
            _context.SaveChanges();
            // ⬆️ AQUÍ YA EXISTE ParentID

            // 2️⃣ Crear Usuario automáticamente
            var usuario = new Usuario
            {
                Username = dto.Cedula,             // o correo si prefieres
                Password = "123456",
                Role = "Padre",
                ParentID = padre.ParentID
            };

            _context.Usuarios.Add(usuario);
            _context.SaveChanges();

            return Ok(new
            {
                PadreID = padre.ParentID,
                Usuario = usuario.Username
            });
        }



        // PUT: api/Padres/1
        [HttpPut("{id:int}")]
        public IActionResult Update(int id, [FromBody] Padre padre)
        {
            var existente = _context.Padres.Find(id);
            if (existente == null) return NotFound();

            existente.Cedula = padre.Cedula;
            existente.Nombre = padre.Nombre;
            existente.Apellido = padre.Apellido;
            existente.Telefono = padre.Telefono;
            existente.Correo = padre.Correo;
            existente.Direccion = padre.Direccion;
            existente.Estado = padre.Estado;

            _context.SaveChanges();
            return Ok(existente);
        }

        // DELETE: api/Padres/1
        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            var padre = _context.Padres.Find(id);
            if (padre == null) return NotFound();

            padre.Estado = "Inactivo";
            _context.SaveChanges();

            return Ok("Padre desactivado");
        }
    }
}
