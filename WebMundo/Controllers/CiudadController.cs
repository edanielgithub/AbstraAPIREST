using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebMundo.Models;

namespace WebMundo.Controllers
{
    [Route("api/[controller]")]
    [Authorize] //adicionado para la validacion de autorizacion
    [ApiController]
    public class CiudadController : ControllerBase
    {
        private readonly DbMundoContext _context;

        public CiudadController(DbMundoContext context)
        {
            _context = context;
        }

        [HttpGet("listar ciudades")]
        public async Task<ActionResult<IEnumerable<Ciudad>>> ListarCiudad()
        {
            var ciudad = await _context.Ciudads.ToListAsync();
            return Ok(ciudad);
        }

        [HttpPost("guardar ciudad")]
        public async Task<ActionResult<Ciudad>> GuardarCiudad(Ciudad ciudad)
        {
            ciudad.FecCreacion = DateTime.Now;
            ciudad.FecAct = DateTime.Now;
            _context.Ciudads.Add(ciudad);
            await _context.SaveChangesAsync();
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPut("actualizar_ciudad/{id}")]
        public async Task<ActionResult> ActualizarCiudad(int id, Ciudad ciudad)
        {
            var ciudadActualizada = await _context.Ciudads.FindAsync(id);

            if(ciudadActualizada == null)
            {
                return NotFound(); //400
            }

            ciudadActualizada.Nombre = ciudad.Nombre;
            ciudadActualizada.Poblacion = ciudad.Poblacion;
            ciudadActualizada.Superficie = ciudad.Superficie;
            ciudadActualizada.Pais = ciudad.Pais;
            ciudadActualizada.FecAct = DateTime.Now;

            await _context.SaveChangesAsync();

            return Ok(ciudadActualizada);
        }

        [HttpDelete("eliminar_ciudad/{id}")]
        public async Task<ActionResult> EliminarCiudad(int id)
        {
            var ciudad = await _context.Ciudads.FindAsync(id);

            if (ciudad == null)
            {
                return NotFound(); //400
            }

            _context.Ciudads.Remove(ciudad);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpGet("buscar_ciudad/{id}")]
        public async Task<ActionResult<Ciudad>> BuscarPorId(int id) 
        {
            var ciudad = await _context.Ciudads.FindAsync(id);
            if (ciudad == null)
            {
                return NotFound(); 
            }
            return Ok(ciudad);
        }
    }
}
