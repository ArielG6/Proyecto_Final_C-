using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplicationDePrueba2.Models;
using WebApplicationDePrueba2.Repository;

namespace WebApplicationDePrueba2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoVendidoController : ControllerBase
    {
        [HttpGet(Name = "TraerProductosVendidos")]
        public List<ProductoVendido> Get()
        {
            return ADO_ProductoVendido.TraerProductosVendidos(1);
        }
    }
}
