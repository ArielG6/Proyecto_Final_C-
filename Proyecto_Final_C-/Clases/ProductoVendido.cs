using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Final_C_.Clases
{
    public class ProductoVendido
    {
        public int Id { get; set; }
        public int Stock { get; set; }
        public int IdProducto { get; set; }
        public int IdVenta { get; set; }

        //Constructor por defecto
        public ProductoVendido()
        {
            Id = 0;
            Stock = 0;
            IdProducto = 0;
            IdVenta = 0;
        }
        //Constructor parametrizado
        public ProductoVendido(int Id, int Stock, int IdProducto, int IdVenta)
        {
            this.Id = Id;
            this.Stock = Stock;
            this.IdProducto = IdProducto;
            this.IdVenta = IdVenta;
        }

        public List<ProductoVendido> TraerProductosVendidos(int IdUsuarioBuscar)
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
