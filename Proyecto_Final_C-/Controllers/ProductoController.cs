using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static WebApplicationDePrueba2.Controllers.VentaController;
using WebApplicationDePrueba2.Repository;
using WebApplicationDePrueba2.Models;

namespace WebApplicationDePrueba2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        [HttpPost("CrearProducto")]
        public void CrearProducto([FromBody] Producto producto)
        {
            ADO_Producto.CrearProducto(producto);
        }
        [HttpPut("ModificarProducto")]
        public void ModificarProducto([FromBody] Producto producto)
        {
            ADO_Producto.ModificarProducto(producto);
        }
        [HttpDelete("EliminarProducto")]
        public void EliminarProducto([FromBody] int id)
        {
            ADO_Producto.EliminarProducto(id);
        }
        [HttpGet("TraerProducto")]
        public List<Producto> TraerProducto(int id)
        {
            return ADO_Producto.TraerProducto(id);
        }
        [HttpGet("TraerProductos")]
        public List<Producto> TraerProductos()
        {
            return ADO_Producto.TraerProductos();
        }
    }
}
