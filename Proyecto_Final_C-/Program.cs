using Proyecto_Final_C_.Clases;
using System.Collections.Generic;
using System.Data.SqlClient;

class Program
{
    static void Main(string[] args)
    {
        //Pruebas de funcionamiento de los métodos
        //Traer usuario
        /*Usuario usuario = new Usuario();
        usuario = usuario.TraerUsuario("tcasazza");
        Console.WriteLine("Id: " + usuario.Id);
        Console.WriteLine("Nombre: " + usuario.Nombre);
        Console.WriteLine("Apellido: " + usuario.Apellido);
        Console.WriteLine("Nombre de Usuario: " + usuario.NombreUsuario);
        Console.WriteLine("Contraseña: " + usuario.Contraseña);
        Console.WriteLine("Email: " + usuario.Mail);
        //Traer producto
        Producto producto = new Producto();
        var listaProductos = new List<Producto>();
        listaProductos = producto.TraerProducto(1);
        foreach (Producto prod in listaProductos)
        {
            Console.WriteLine(prod.Descripciones);
        }
        //Traer productos vendidos
        var listaProductosVendidos = new List<ProductoVendido>();
        ProductoVendido productoVendido = new ProductoVendido();
        listaProductosVendidos = productoVendido.TraerProductosVendidos(1);
        foreach (ProductoVendido prod in listaProductosVendidos)
        {
            Console.WriteLine(prod.IdProducto);
        }
        //Traer ventas
        Venta venta = new Venta();
        var listaVentas = new List<Venta>();
        listaVentas = venta.TraerVentas(1);
        foreach (Venta vent in listaVentas)
        {
            Console.WriteLine(vent.Id);
        }
        //Inicio de sesión
        usuario = usuario.InicioDeSesión("eperez","SoyErnestoPerez");   //Usuario y contraseña correctos
        //usuario = usuario.InicioDeSesión("eperez","SoyErstoPerez"); //Contraseña incorrecta
        Console.WriteLine("Id: " + usuario.Id);
        Console.WriteLine("Nombre: " + usuario.Nombre);
        Console.WriteLine("Apellido: " + usuario.Apellido);
        Console.WriteLine("Nombre de Usuario: " + usuario.NombreUsuario);
        Console.WriteLine("Contraseña: " + usuario.Contraseña);
        Console.WriteLine("Email: " + usuario.Mail);*/

        Usuario usuario = new Usuario();
        usuario.Id = 1;
        usuario.Nombre = "Harry";
        usuario.Apellido = "Potter";
        usuario.NombreUsuario = "hpotter";
        usuario.Contraseña = "TheBoyWhoLived";
        usuario.Mail = "hpotter@gmail.com";

        Console.WriteLine("Id: " + usuario.Id);
        Console.WriteLine("Nombre: " + usuario.Nombre);
        Console.WriteLine("Apellido: " + usuario.Apellido);
        Console.WriteLine("Nombre de Usuario: " + usuario.NombreUsuario);
        Console.WriteLine("Contraseña: " + usuario.Contraseña);
        Console.WriteLine("Email: " + usuario.Mail);

        usuario.ModificarUsuario(usuario);

        usuario = usuario.TraerUsuario("hpotter");
        Console.WriteLine("Id: " + usuario.Id);
        Console.WriteLine("Nombre: " + usuario.Nombre);
        Console.WriteLine("Apellido: " + usuario.Apellido);
        Console.WriteLine("Nombre de Usuario: " + usuario.NombreUsuario);
        Console.WriteLine("Contraseña: " + usuario.Contraseña);
        Console.WriteLine("Email: " + usuario.Mail);

        /*Producto producto = new Producto();
        var listaProductos = new List<Producto>();
        listaProductos = producto.TraerProducto(2);
        foreach (Producto prod in listaProductos)
        {
            Console.WriteLine(prod.Descripciones);
        }

        producto.eliminarProducto(9);

        listaProductos = producto.TraerProducto(2);
        foreach (Producto prod in listaProductos)
        {
            Console.WriteLine(prod.Descripciones);
        }*/
        /*
        Producto producto = new Producto();
        producto.Id = 2;
        //producto.Descripciones = "Pantalon Jean";
        //producto.Costo = 800;
        //producto.PrecioVenta = 4000;
        producto.Stock = 1;
        //producto.IdUsuario = 1;
        var listaProductos = new List<Producto>();
        listaProductos.Add(producto);

        Venta venta = new Venta();
        var listaVentas = new List<Venta>();
        listaVentas = venta.TraerVentas(1);
        foreach (Venta vent in listaVentas)
        {
            Console.WriteLine(vent.Id);
        }

        venta.CargarVenta(listaProductos,4);

        listaVentas = venta.TraerVentas(1);
        foreach (Venta vent in listaVentas)
        {
            Console.WriteLine(vent.Id);
        }*/
    }

}