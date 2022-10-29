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
        [HttpGet("GetInicioSesion")]
        public Usuario GetInicioSesion(string nombreUsuario,string contrasena)
        {
            return ADO_Usuario.InicioDeSesión(nombreUsuario, contrasena);
        }
        [HttpPost("CrearUsuario")]
        public void CrearUsuario([FromBody] Usuario usuario)
        {
            ADO_Usuario.CrearUsuario(usuario);
        }
        [HttpPut("PutModificarUsuario")]
        public void ModificarUsuario([FromBody] Usuario usuario)
        {
            ADO_Usuario.ModificarUsuario(usuario);
        }
        [HttpGet("GetUsuario")]
        public Usuario GetUsuario(string nombreUsuario)
        {
            return ADO_Usuario.TraerUsuario(nombreUsuario);
        }
        [HttpDelete("EliminarUsuario")]
        public void EliminarUsuario([FromBody] int id)
        {
            ADO_Usuario.EliminarUsuario(id);
        }
    }
}
