﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Final_C_.Clases
{
    public class Usuario
    {
        private int Id { get; set; };
        private string Nombre { get; set; };
        private string Apellido { get; set; };
        private string NombreUsuario { get; set; };
        private string Contraseña { get; set; };
        private string Mail { get; set; };

        //Constructor por defecto
        public Usuario()
        {
            Id = 0;
            Nombre = String.Empty;
            Apellido = String.Empty;
            NombreUsuario = String.Empty;
            Contraseña = String.Empty;
            Mail = String.Empty;
        }
        //Constructor parametrizado
        public Usuario(string Nombre, string Apellido, string NombreUsuario, string Contraseña, string Mail)
        {
            this.Nombre = Nombre;
            this.Apellido = Apellido;
            this.NombreUsuario = NombreUsuario;
            this.Contraseña = Contraseña;
            this.Mail = Mail;
        }
    }
}
