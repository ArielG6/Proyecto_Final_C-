using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplicationDePrueba2.Models;
using WebApplicationDePrueba2.Repository;
using static WebApplicationDePrueba2.Controllers.ProductoController;

namespace WebApplicationDePrueba2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentaController : ControllerBase
    {
        [HttpGet(Name = "TraerVentas")]
        public List<Venta> Get([FromQuery] int id)
        {
            return ADO_Venta.TraerVentas(id);
        }
        [HttpPost(Name = "CargarVenta")]
        public void CargarVenta([FromBody] List<Producto> listaProductos, [FromQuery] int IdUsuarioVendedor)
        {
            ADO_Venta.CargarVenta(listaProductos, IdUsuarioVendedor);
        }
    }
}
