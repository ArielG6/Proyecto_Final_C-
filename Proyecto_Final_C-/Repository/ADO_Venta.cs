using static WebApplicationDePrueba2.Controllers.VentaController;
using System.Data.SqlClient;
using static WebApplicationDePrueba2.Controllers.ProductoController;
using WebApplicationDePrueba2.Models;

namespace WebApplicationDePrueba2.Repository
{
    public class ADO_Venta
    {
        public static List<Venta> TraerVentas(int IdUsuarioBuscar)
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
        public static void CargarVenta(List<Producto> listaProductos, int IdUsuarioVendedor)
        {
            //Método que recibe una lista de productos y el número de IdUsuario de quien la efectuó,
            //primero carga una nueva venta en la base de datos, luego carga los productos recibidos en la
            //base de ProductosVendidos uno por uno por un lado, y finalmente, descuenta el stock en la base
            //de productos.
            SqlConnectionStringBuilder connectionBuilder = new();
            connectionBuilder.DataSource = "LAPTOP-JBSHHD62";
            connectionBuilder.InitialCatalog = "SistemaGestion";
            connectionBuilder.IntegratedSecurity = true;

            var connectionString = connectionBuilder.ConnectionString;

            using (SqlConnection connect = new SqlConnection(connectionString))
            {
                connect.Open();
                int IdNuevaVenta = 0;
                foreach (Producto producto in listaProductos)
                {
                    SqlCommand cmd = connect.CreateCommand();
                    cmd.CommandText = "INSERT INTO Venta VALUES (@Comentarios,@IdUsuario)";

                    var paramComentarios = new SqlParameter("Comentarios", System.Data.SqlDbType.VarChar);
                    paramComentarios.Value = " ";
                    cmd.Parameters.Add(paramComentarios);

                    var paramIdUsuario = new SqlParameter("IdUsuario", System.Data.SqlDbType.Int);
                    paramIdUsuario.Value = IdUsuarioVendedor;
                    cmd.Parameters.Add(paramIdUsuario);

                    cmd.ExecuteNonQuery();

                    cmd.CommandText = "SELECT max(Id) FROM Venta";

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            IdNuevaVenta = Convert.ToInt32(dr.GetValue(0));
                        }
                        dr.Close();
                    }

                    cmd.CommandText = "INSERT INTO ProductoVendido VALUES (@Stock,@IdProducto,@IdVenta)";

                    var paramStock = new SqlParameter("Stock", System.Data.SqlDbType.Int);
                    paramStock.Value = producto.Stock;
                    cmd.Parameters.Add(paramStock);

                    var paramIdProducto = new SqlParameter("IdProducto", System.Data.SqlDbType.Int);
                    paramIdProducto.Value = producto.Id;
                    cmd.Parameters.Add(paramIdProducto);

                    var paramIdVenta = new SqlParameter("IdVenta", System.Data.SqlDbType.Int);
                    paramIdVenta.Value = IdNuevaVenta;
                    cmd.Parameters.Add(paramIdVenta);

                    cmd.ExecuteNonQuery();

                    cmd.CommandText = "UPDATE Producto SET Stock=Stock-@StockNuevo WHERE Id = @Id";

                    var paramId = new SqlParameter("Id", System.Data.SqlDbType.Int);
                    paramId.Value = producto.Id;
                    cmd.Parameters.Add(paramId);

                    var paramStockNuevo = new SqlParameter("StockNuevo", System.Data.SqlDbType.Int);
                    paramStockNuevo.Value = producto.Stock;
                    cmd.Parameters.Add(paramStockNuevo);

                    cmd.ExecuteNonQuery();
                }
                connect.Close();
            }
        }
    }
}
