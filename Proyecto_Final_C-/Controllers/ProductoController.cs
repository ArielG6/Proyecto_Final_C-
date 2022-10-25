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
        [HttpGet(Name = "TraerProducto")]
        public List<Producto> TraerProducto([FromBody] int id)
        {
            return ADO_Producto.TraerProducto(id);
        }
        [HttpPost(Name = "CrearProducto")]
        public void CrearProducto([FromBody] Producto producto)
        {
            ADO_Producto.CrearProducto(producto);
        }
        [HttpPut(Name = "ModificarProducto")]
        public void ModificarProducto([FromBody] Producto producto)
        {
            ADO_Producto.ModificarProducto(producto);
        }
        [HttpDelete(Name = "EliminarProducto")]
        public void EliminarProducto([FromBody] int id)
        {
            ADO_Producto.EliminarProducto(id);
        }
    }
}
