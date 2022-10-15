using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Final_C_.Clases
{
    public class Venta
    {
        public int Id { get; set; }
        public string Comentarios { get; set; }
        public int IdUsuario { get; set; }
       
        //Constructor por defecto
        public Venta()
        {
            Id = 0;
            Comentarios = String.Empty;
            IdUsuario = 0;
        }
        //Constructor parametrizado
        public Venta (int ID, string Comentarios, int IdUsuario)
        {
            this.Id = Id;
            this.Comentarios = Comentarios;
            this.IdUsuario = IdUsuario;
        }
        public List<Venta> TraerVentas(int IdUsuarioBuscar)
        {
            //Método que recibe un número de IdUsuario como parámetro y
            //trae todas las ventas de la base asignados a este usuario en particular.

            var listaVentas = new List<Venta>();

            SqlConnectionStringBuilder connectionBuilder = new();
            connectionBuilder.DataSource = "LAPTOP-JBSHHD62";
            connectionBuilder.InitialCatalog = "SistemaGestion";
            connectionBuilder.IntegratedSecurity = true;

            var connectionString = connectionBuilder.ConnectionString;

            using (SqlConnection connect = new SqlConnection(connectionString))
            {
                connect.Open();

                SqlCommand cmd = connect.CreateCommand();
                cmd.CommandText = "SELECT * FROM Venta WHERE IdUsuario = @idUsu";
                var parametro = new SqlParameter("idUsu", System.Data.SqlDbType.Int);
                parametro.Value = IdUsuarioBuscar;
                cmd.Parameters.Add(parametro);

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Venta venta = new Venta();

                        venta.Id = Convert.ToInt32(dr.GetValue(0));
                        venta.Comentarios = dr.GetString(1).ToString();
                        venta.IdUsuario = Convert.ToInt32(dr.GetValue(2));

                        listaVentas.Add(venta);

                    }
                    dr.Close();
                }

                connect.Close();
            }

            return listaVentas;
        }
    }
}
