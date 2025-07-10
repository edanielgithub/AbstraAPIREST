using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebMundo.Models;

namespace WebMundo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly DbMundoContext _context;

        public UsuarioController(DbMundoContext context)
        {
            _context = context;
        }

        [HttpGet("listar usuarios")]
        public async Task<ActionResult<IEnumerable<Usuario>>> ListarUsuario()
        {
            var usuario = await _context.Usuarios.ToListAsync();
            return Ok(usuario);
        }

        [HttpPost("guardar usuario")]
        public async Task<ActionResult<Ciudad>> GuardarUsuario(Usuario usuario)
        {
            usuario.FecCreacion = DateTime.Now;
            usuario.FecAct = DateTime.Now;
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPut("actualizar_usuario/{usr}")]
        public async Task<ActionResult> ActualizarUsuario(string usr, Usuario usuario)
        {
            var usuarioActualizado = await _context.Usuarios.FindAsync(usr);

            if (usuarioActualizado == null)
            {
                return NotFound(); //400
            }

            usuarioActualizado.Clave = usuario.Clave;
            usuarioActualizado.Nombres = usuario.Nombres;
            usuarioActualizado.Apellidos = usuario.Apellidos;
            usuarioActualizado.FecAct = DateTime.Now;

            await _context.SaveChangesAsync();

            return Ok(usuarioActualizado);
        }

        [HttpDelete("eliminar_usuario/{usr}")]
        public async Task<ActionResult> EliminarCiudad(string usr)
        {
            var usuario = await _context.Usuarios.FindAsync(usr);

            if (usuario == null)
            {
                return NotFound(); //400
            }

            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpGet("buscar_usuario/{usr}")]
        public async Task<ActionResult<Ciudad>> BuscarPorUsr(string usr)
        {
            var usuario = await _context.Usuarios.FindAsync(usr);
            if (usuario == null)
            {
                return NotFound();
            }
            return Ok(usuario);
        }
    }
}
    

