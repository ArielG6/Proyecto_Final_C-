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
        [HttpPost("CargarVenta")]
        public void CargarVenta([FromBody] List<Producto> listaProductos, [FromQuery] int IdUsuarioVendedor)
        {
            ADO_Venta.CargarVenta(listaProductos, IdUsuarioVendedor);
        }
        [HttpDelete("EliminarVenta")]
        public void ElminarVenta([FromQuery] int id)
        {
            ADO_Venta.EliminarVenta(id);
        }
        [HttpGet("TraerVentas")]
        public List<Venta> TraerVentas()
        {
            return ADO_Venta.TraerVentas();
        }
        [HttpGet("TraerVentasUsuario")]
        public List<Venta> TraerVentasUsuario(int id)
        {
            return ADO_Venta.TraerVentasUsuario(id);
        }
    }
}
