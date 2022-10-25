namespace WebApplicationDePrueba2.Models
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
    }
}
