using System.Data.SqlClient;
using WebApplicationDePrueba2.Models;
using static WebApplicationDePrueba2.Controllers.ProductoController;

namespace WebApplicationDePrueba2.Repository
{
    public class ADO_Producto
    {
        public static List<Producto> TraerProducto(int IdUsuarioBuscar)
        {
            //Método que recibe un número de IdUsuario como parámetro y
            //trae todos los productos cargados en la base de este usuario en particular.

            var listaProductos = new List<Producto>();

            SqlConnectionStringBuilder connectionBuilder = new();
            connectionBuilder.DataSource = "LAPTOP-JBSHHD62";
            connectionBuilder.InitialCatalog = "SistemaGestion";
            connectionBuilder.IntegratedSecurity = true;

            var connectionString = connectionBuilder.ConnectionString;

            using (SqlConnection connect = new SqlConnection(connectionString))
            {
                connect.Open();

                SqlCommand cmd = connect.CreateCommand();
                cmd.CommandText = "SELECT * FROM Producto WHERE IdUsuario = @idUsu";
                var parametro = new SqlParameter("idUsu", System.Data.SqlDbType.Int);
                parametro.Value = IdUsuarioBuscar;
                cmd.Parameters.Add(parametro);

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Producto product = new Producto();

                        product.Id = Convert.ToInt32(dr.GetValue(0));
                        product.Descripciones = dr.GetString(1).ToString();
                        product.Costo = Convert.ToDouble(dr.GetValue(2));
                        product.PrecioVenta = Convert.ToDouble(dr.GetValue(3));
                        product.Stock = Convert.ToInt32(dr.GetValue(4));
                        product.IdUsuario = Convert.ToInt32(dr.GetValue(5));

                        listaProductos.Add(product);

                    }
                    dr.Close();
                }

                connect.Close();
            }

            return listaProductos;
        }
        public static void CrearProducto(Producto producto)
        {
            //Método para ingresar un nuevo producto.

            SqlConnectionStringBuilder connectionBuilder = new();
            connectionBuilder.DataSource = "LAPTOP-JBSHHD62";
            connectionBuilder.InitialCatalog = "SistemaGestion";
            connectionBuilder.IntegratedSecurity = true;

            var connectionString = connectionBuilder.ConnectionString;

            using (SqlConnection connect = new SqlConnection(connectionString))
            {
                connect.Open();

                SqlCommand cmd = connect.CreateCommand();
                cmd.CommandText = "INSERT INTO Producto VALUES (@Descripcion,@Costo,@PrecioVenta,@Stock,@IdUsuario)";

                var paramDescripcion = new SqlParameter("Descripcion", System.Data.SqlDbType.VarChar);
                paramDescripcion.Value = producto.Descripciones;
                cmd.Parameters.Add(paramDescripcion);

                var paramCosto = new SqlParameter("Costo", System.Data.SqlDbType.Decimal);
                paramCosto.Value = producto.Costo;
                cmd.Parameters.Add(paramCosto);

                var paramPrecioVenta = new SqlParameter("PrecioVenta", System.Data.SqlDbType.Decimal);
                paramPrecioVenta.Value = producto.PrecioVenta;
                cmd.Parameters.Add(paramPrecioVenta);

                var paramStock = new SqlParameter("Stock", System.Data.SqlDbType.Int);
                paramStock.Value = producto.Stock;
                cmd.Parameters.Add(paramStock);

                var paramIdUsuario = new SqlParameter("IdUsuario", System.Data.SqlDbType.Int);
                paramIdUsuario.Value = producto.IdUsuario;
                cmd.Parameters.Add(paramIdUsuario);

                cmd.ExecuteNonQuery();
                connect.Close();
            }
        }
        public static void ModificarProducto(Producto producto)
        {
            SqlConnectionStringBuilder connectionBuilder = new();
            connectionBuilder.DataSource = "LAPTOP-JBSHHD62";
            connectionBuilder.InitialCatalog = "SistemaGestion";
            connectionBuilder.IntegratedSecurity = true;

            var connectionString = connectionBuilder.ConnectionString;

            using (SqlConnection connect = new SqlConnection(connectionString))
            {
                connect.Open();

                SqlCommand cmd = connect.CreateCommand();
                cmd.CommandText = "UPDATE Producto SET Descripciones=@Descripcion, Costo=@Costo, PrecioVenta=@PrecioVenta, Stock=@Stock, IdUsuario=@IdUsuario WHERE Id = @Id";

                var paramId = new SqlParameter("Id", System.Data.SqlDbType.Int);
                paramId.Value = producto.Id;
                cmd.Parameters.Add(paramId);

                var paramDescripcion = new SqlParameter("Descripcion", System.Data.SqlDbType.VarChar);
                paramDescripcion.Value = producto.Descripciones;
                cmd.Parameters.Add(paramDescripcion);

                var paramCosto = new SqlParameter("Costo", System.Data.SqlDbType.Decimal);
                paramCosto.Value = producto.Costo;
                cmd.Parameters.Add(paramCosto);

                var paramPrecioVenta = new SqlParameter("PrecioVenta", System.Data.SqlDbType.Decimal);
                paramPrecioVenta.Value = producto.PrecioVenta;
                cmd.Parameters.Add(paramPrecioVenta);

                var paramStock = new SqlParameter("Stock", System.Data.SqlDbType.Int);
                paramStock.Value = producto.Stock;
                cmd.Parameters.Add(paramStock);

                var paramIdUsuario = new SqlParameter("IdUsuario", System.Data.SqlDbType.Int);
                paramIdUsuario.Value = producto.IdUsuario;
                cmd.Parameters.Add(paramIdUsuario);

                cmd.ExecuteNonQuery();
                connect.Close();
            }
        }
        public static void EliminarProducto(int IdAElimnar)
        {
            SqlConnectionStringBuilder connectionBuilder = new();
            connectionBuilder.DataSource = "LAPTOP-JBSHHD62";
            connectionBuilder.InitialCatalog = "SistemaGestion";
            connectionBuilder.IntegratedSecurity = true;

            var connectionString = connectionBuilder.ConnectionString;

            using (SqlConnection connect = new SqlConnection(connectionString))
            {
                connect.Open();

                SqlCommand cmd = connect.CreateCommand();
                cmd.CommandText = "DELETE FROM Producto WHERE Id = @Id";

                var paramId = new SqlParameter("Id", System.Data.SqlDbType.Int);
                paramId.Value = IdAElimnar;
                cmd.Parameters.Add(paramId);

                cmd.ExecuteNonQuery();
                connect.Close();
            }
        }
    }
    
}
