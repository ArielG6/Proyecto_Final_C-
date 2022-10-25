using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplicationDePrueba2.Models;
using WebApplicationDePrueba2.Repository;

namespace WebApplicationDePrueba2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    { 
        [HttpGet("GetUsuario")]
        public Usuario GetUsuario()
        {
            return ADO_Usuario.TraerUsuario("eperez");
        }
        [HttpGet("GetInicioSesion")]
        public Usuario GetInicioSesion()
        {
            return ADO_Usuario.InicioDeSesión("eperez","SoyErnestoPerez");
        }
        [HttpPut("PutModificarUsuario")]
        public void ModificarUsuario([FromBody]Usuario usuario)
        {
            ADO_Usuario.ModificarUsuario(usuario);
        }

    }
}
