namespace WebApplicationDePrueba2.Models
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
        public Venta(int ID, string Comentarios, int IdUsuario)
        {
            this.Id = Id;
            this.Comentarios = Comentarios;
            this.IdUsuario = IdUsuario;
        }
    }
}
