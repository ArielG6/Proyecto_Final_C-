﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Proyecto_Final_C_.Clases
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string NombreUsuario { get; set; }
        public string Contraseña { get; set; }
        public string Mail { get; set; }

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
        public Usuario(int Id, string Nombre, string Apellido, string NombreUsuario, string Contraseña, string Mail)
        {
            this.Id = Id;
            this.Nombre = Nombre;
            this.Apellido = Apellido;
            this.NombreUsuario = NombreUsuario;
            this.Contraseña = Contraseña;
            this.Mail = Mail;
        }
        
        public Usuario TraerUsuario(string nombreUsuario)
        {
            //Método que recibe como parámetro un nombre del usuario, lo busca en la base de datos y devuelve el
            //objeto con todos sus datos. 
            
            Usuario usuario = new Usuario();
            SqlConnectionStringBuilder connectionBuilder = new();
            connectionBuilder.DataSource = "LAPTOP-JBSHHD62";
            connectionBuilder.InitialCatalog = "SistemaGestion";
            connectionBuilder.IntegratedSecurity = true;

            var connectionString = connectionBuilder.ConnectionString;

            using (SqlConnection connect = new SqlConnection(connectionString))
            {
                connect.Open();

                SqlCommand cmd = connect.CreateCommand();
                cmd.CommandText = "SELECT * FROM Usuario WHERE NombreUsuario = @nomUsu";
                var parametro = new SqlParameter("nomUsu", System.Data.SqlDbType.VarChar);
                parametro.Value = nombreUsuario;
                cmd.Parameters.Add(parametro);

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        usuario.Id = Convert.ToInt32 (dr.GetValue(0));
                        usuario.Nombre = dr.GetString(1).ToString();
                        usuario.Apellido = dr.GetString(2).ToString();
                        usuario.NombreUsuario = dr.GetString(3).ToString();
                        usuario.Contraseña = dr.GetString(4).ToString();
                        usuario.Mail = dr.GetString(5).ToString();
                    }
                    dr.Close();
                }
                connect.Close();
            }
            return usuario;
        }

        public Usuario InicioDeSesión(string nombreUsuario, string password)
        {
            //Método que al que se le pasa como parámetro el nombre del usuario y la contraseña,
            //busca en la base de datos si el usuario existe y si coincide con la contraseña lo
            //devuelve (el objeto Usuario), caso contrario devuelve uno vacío (Con sus datos vacíos y el id en 0).  
            
            Usuario usuario = new Usuario();
            SqlConnectionStringBuilder connectionBuilder = new();
            connectionBuilder.DataSource = "LAPTOP-JBSHHD62";
            connectionBuilder.InitialCatalog = "SistemaGestion";
            connectionBuilder.IntegratedSecurity = true;

            var connectionString = connectionBuilder.ConnectionString;

            using (SqlConnection connect = new SqlConnection(connectionString))
            {
                connect.Open();

                SqlCommand cmd = connect.CreateCommand();
                cmd.CommandText = "SELECT * FROM Usuario WHERE NombreUsuario = @nomUsu and Contraseña = @pass";

                var paramUsuario = new SqlParameter("nomUsu", System.Data.SqlDbType.VarChar);
                paramUsuario.Value = nombreUsuario;
                cmd.Parameters.Add(paramUsuario);

                var parampassword = new SqlParameter("pass", System.Data.SqlDbType.VarChar);
                parampassword.Value = password;
                cmd.Parameters.Add(parampassword);

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        usuario.Id = Convert.ToInt32(dr.GetValue(0));
                        usuario.Nombre = dr.GetString(1).ToString();
                        usuario.Apellido = dr.GetString(2).ToString();
                        usuario.NombreUsuario = dr.GetString(3).ToString();
                        usuario.Contraseña = dr.GetString(4).ToString();
                        usuario.Mail = dr.GetString(5).ToString();
                    }
                    dr.Close();
                }
                connect.Close();
            }
            return usuario;
        }
    }
}
