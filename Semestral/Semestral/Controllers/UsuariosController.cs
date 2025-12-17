using Guarderia.api.Data;
using Guarderia.api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Guarderia.api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly GuarderiaDbContext _context;

        public UsuariosController(GuarderiaDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_context.Usuarios.ToList());
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var usuario = _context.Usuarios.Find(id);
            if (usuario == null) return NotFound();
            return Ok(usuario);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            _context.SaveChanges();
            return Ok(usuario);
        }

        [HttpPut("{id:int}")]
        public IActionResult Update(int id, [FromBody] Usuario usuario)
        {
            var existente = _context.Usuarios.Find(id);
            if (existente == null) return NotFound();

            existente.Username = usuario.Username;
            existente.Password = usuario.Password;
            existente.Role = usuario.Role;
            existente.ParentID = usuario.ParentID;

            _context.SaveChanges();
            return Ok(existente);
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            var usuario = _context.Usuarios.Find(id);
            if (usuario == null) return NotFound();

            _context.Usuarios.Remove(usuario);
            _context.SaveChanges();
            return Ok();
        }
    }
}
