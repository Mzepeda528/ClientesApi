using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ClientesApi.Data;
using ClientesApi.Models;

namespace ClientesApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientesController : ControllerBase
    {
        private readonly ClientesDbContext _context;

        public ClientesController(ClientesDbContext context)
        {
            _context = context;
        }

        // GET: api/clientes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cliente>>> GetClientes()
        {
            return await _context.Clientes.ToListAsync();
        }

        // GET: api/clientes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cliente>> GetCliente(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);

            if (cliente == null)
            {
                return NotFound($"No se encontró el cliente con Id {id}");
            }

            return cliente;
        }

        // POST: api/clientes
        [HttpPost]
        public async Task<ActionResult<Cliente>> PostCliente(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCliente), new { id = cliente.Id_cliente }, cliente);
        }

        // PUT: api/clientes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCliente(int id, Cliente cliente)
        {
            if (id != cliente.Id_cliente)
            {
                return BadRequest("El Id de la URL no coincide con el Id del cliente.");
            }

            var clienteExistente = await _context.Clientes.FindAsync(id);
            if (clienteExistente == null)
            {
                return NotFound($"No se encontró el cliente con Id {id}");
            }

            clienteExistente.CUI = cliente.CUI;
            clienteExistente.NIT = cliente.NIT;
            clienteExistente.Nombres = cliente.Nombres;
            clienteExistente.Apellidos = cliente.Apellidos;
            clienteExistente.Direccion = cliente.Direccion;
            clienteExistente.Telefono = cliente.Telefono;
            clienteExistente.Fecha_Nacimiento = cliente.Fecha_Nacimiento;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/clientes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCliente(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente == null)
            {
                return NotFound($"No se encontró el cliente con Id {id}");
            }

            _context.Clientes.Remove(cliente);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
