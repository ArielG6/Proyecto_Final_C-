using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Final_C_.Clases
{
    public class Producto
    {
        public int Id { get; set; }
        public string Descripciones { get; set; }
        public double Costo { get; set; }
        public double PrecioVenta { get; set; }
        public int Stock { get; set; }
        public int IdUsuario { get; set; }

        //Constructor por defecto
        public Producto()
        {
            Id = 0;
            Descripciones = String.Empty;
            Costo = 0;
            PrecioVenta = 0;
            Stock = 0;
            IdUsuario = 0;
        }
        //Constructor parametrizado
        public Producto(int Id, string Desripciones, double Costo, double PrecioVenta, int Stock, int IdUsuario)
        {
            this.Id = Id;
            this.Descripciones = Desripciones;
            this.Costo = Costo;
            this.PrecioVenta = PrecioVenta;
            this.Stock = Stock;
            this.IdUsuario = IdUsuario;
        }

        public List<Producto> TraerProducto(int IdUsuarioBuscar)
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
        public void CrearProducto(Producto producto)
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
        public void ModificarProducto(Producto producto)
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
        public void eliminarProducto(int IdAElimnar)
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
