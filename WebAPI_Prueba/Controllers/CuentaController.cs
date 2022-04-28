using DataAccess.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebAPI_Prueba.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CuentaController : ControllerBase
    {
        private ModelContext _context;
        //Constructor para crear un contexto del controlador de cuenta
        public CuentaController(ModelContext context)
        {
            _context = context;
        }

        //Metodo de tipo GET para listar las cuentas
        [HttpGet]
        public async Task<List<Cuentum>> Listar()
        {
            return await _context.Cuenta.ToListAsync();
        }
        //Metodo de tipo GET para buscar cuentas por id_cuenta
        [HttpGet("{id}")]
        public async Task<ActionResult<Cuentum>> BuscarPorId(decimal id)
        {
            var retorno = await _context.Cuenta.FirstOrDefaultAsync(x => x.IdCuenta == id);

            if (retorno != null)
                return retorno;
            else
                return NotFound();
        }

        //Metodo de tipo POST para añadir cuentas a la base de datos
        [HttpPost]
        public async Task<ActionResult<Cuentum>> Guardar(Cuentum c)
        {
            try
            {
                await _context.Cuenta.AddAsync(c);
                await _context.SaveChangesAsync();
              //  c.IdCuenta = await _context.Cuenta.MaxAsync(u => u.IdCuenta);

                return c;
            }
            catch (DbUpdateException)
            {
                return StatusCode(500, "Se encontró un error");
            }
        }
        //Metodo de tipo PUT para actualizar las cuentas
        [HttpPut]
        public async Task<ActionResult<Cuentum>> Actualizar(Cuentum c)
        {
            if (c == null || c.IdCuenta == 0)
                return BadRequest("Faltan datos");

            Cuentum cu = await _context.Cuenta.FirstOrDefaultAsync(x => x.IdCuenta == c.IdCuenta);

            if (cu == null)
                return NotFound();

            try
            {
                cu.NumeroCuenta = c.NumeroCuenta;
                _context.Cuenta.Update(cu);
                await _context.SaveChangesAsync();

                return cu;
            }
            catch (DbUpdateException)
            {
                return StatusCode(500, "Se encontró un error");
            }
        }
        //Metodo de tipo DELETE para eliminar la cuenta por su id_cuenta

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Eliminar(decimal id)
        {
            Cuentum cat = await _context.Cuenta.FirstOrDefaultAsync(x => x.IdCuenta == id);

            if (cat == null)
                return NotFound();

            try
            {
                _context.Cuenta.Remove(cat);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateException)
            {
                return StatusCode(500, "Se encontró un error");
            }
        }
    }
}
