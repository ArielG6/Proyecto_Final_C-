using static WebApplicationDePrueba2.Controllers.ProductoVendidoController;
using System.Data.SqlClient;
using WebApplicationDePrueba2.Models;

namespace WebApplicationDePrueba2.Repository
{
    public class ADO_ProductoVendido
    {
        public static List<ProductoVendido> TraerProductosVendidos(int IdUsuarioBuscar)
        {
            //Método que trae todos los productos vendidos de un Usuario.

            var listaProductosVendidos = new List<ProductoVendido>();

            SqlConnectionStringBuilder connectionBuilder = new();
            connectionBuilder.DataSource = "LAPTOP-JBSHHD62";
            connectionBuilder.InitialCatalog = "SistemaGestion";
            connectionBuilder.IntegratedSecurity = true;

            var connectionString = connectionBuilder.ConnectionString;

            using (SqlConnection connect = new SqlConnection(connectionString))
            {
                connect.Open();

                SqlCommand cmd = connect.CreateCommand();
                cmd.CommandText = "SELECT pv.Id, pv.Stock ,pv.IdProducto, pv.IdVenta FROM ProductoVendido pv JOIN Venta v ON pv.IdVenta = v.Id WHERE v.IdUsuario = @idUsu";
                var parametro = new SqlParameter("idUsu", System.Data.SqlDbType.Int);
                parametro.Value = IdUsuarioBuscar;
                cmd.Parameters.Add(parametro);

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        ProductoVendido productVendido = new ProductoVendido();

                        productVendido.Id = Convert.ToInt32(dr.GetValue(0));
                        productVendido.Stock = Convert.ToInt32(dr.GetValue(1));
                        productVendido.IdProducto = Convert.ToInt32(dr.GetValue(2));
                        productVendido.IdVenta = Convert.ToInt32(dr.GetValue(3));

                        listaProductosVendidos.Add(productVendido);

                    }
                    dr.Close();
                }

                connect.Close();
            }

            return listaProductosVendidos;
        }
    }
}
