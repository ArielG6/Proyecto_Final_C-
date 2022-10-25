namespace WebApplicationDePrueba2.Models
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
    }
}
