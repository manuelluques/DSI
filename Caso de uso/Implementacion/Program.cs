using System;
using System.Collections.Generic;

namespace AgregarCarrito_openShop
{
    class GestorVentas
    {
        static Carrito Carrito = new Carrito();
        static List<FormasPago> FormasPagos = new List<FormasPago>();
        static List<Venta> Ventas = new List<Venta>();

        static void Main(string[] args)
        {
            FormasPagos.Add(new FormasPago("Tarjeta en 6 cuotas sin interés"));
            FormasPagos.Add(new FormasPago("Débito"));

            while (true)
            {
                var finalizado = Operando();

                if (finalizado)
                {
                    break;
                }
            }

            System.Console.WriteLine("Fin");

        }

        static public bool Comprar()
        {
            RegistroProductos.MostrarProductos();

            Console.WriteLine();
            Console.WriteLine("Seleccione un producto:");
            var opcionProducto = System.Console.ReadLine();
            var producto = RegistroProductos.Productos[int.Parse(opcionProducto) - 1];

            Console.WriteLine();
            Console.WriteLine("Introduzca la cantidad de productos que desea comprar:");
            var opcionCantidad = System.Console.ReadLine();
            int cantidadElegida = (int.Parse(opcionCantidad));

            Carrito.Agregar(producto, cantidadElegida);
            Carrito.MostrarCarrito();


            Console.WriteLine(" \n1- Seguir comprando \n2- Abonar los productos del carrito");
            var opcionSeguir = System.Console.ReadLine();
            Console.Clear();



            if (int.Parse(opcionSeguir) == 1)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        static public FormasPago AgregarPago()
        {
            Console.WriteLine();
            Console.WriteLine("Formas de pago:");
            int pos = 1;
            foreach (var pago in FormasPagos)
            {
                Console.WriteLine(pos + "- " + pago.Tipo);
                pos++;
            }

            Console.WriteLine();
            Console.WriteLine("Seleccione una forma de pago (Digite 1 o 2)");
            var seleccion2 = System.Console.ReadLine();
            Console.Clear();
            var formasPagos = FormasPagos[int.Parse(seleccion2) - 1];
            Console.WriteLine("La forma de pago elegida fue: " + formasPagos.Tipo);
            Console.WriteLine("");

            return formasPagos;
        }

        static public bool Operando()
        {

            Console.WriteLine();
            Console.WriteLine("Menú: \n 1.Comprar \n 2.Preparar pedido ");

            var opcionMenu = int.Parse(Console.ReadLine());
            Console.Clear();

            switch (opcionMenu)
            {
                case 1:
                    {
                        while (true)
                        {
                            var finalizado = Comprar();

                            if (finalizado)
                            {
                                break;
                            }
                        }

                        var pago = AgregarPago();

                        var productos = Carrito.obtenerProductosEnCarrito();

                        var venta = new Venta(productos, pago);



                        Ventas.Add(venta);


                        Console.WriteLine("Gracias por su compra, vuelva pronto");

                        break;
                    }

                case 2:
                    {
                        Console.WriteLine("Pedidos:  ");

                        if (Ventas.Count > 0)
                        {

                            foreach (var item in Ventas)
                            {
                                Console.WriteLine("\n -------------------------------- \n");
                                Console.WriteLine('>' + item.Fecha.ToShortDateString());
                                item.Carrito.MostrarCarrito();
                                item.FormaPago.MostrarFormaPago();
                            }
                        }
                        else
                        {
                            Console.WriteLine("No se registraron ventas");
                        }

                        break;
                    }

                default:
                    {
                        Console.WriteLine("La opción ingresada no es válida");
                        break;
                    };
            }


            Console.WriteLine("\nDesea continuar operando?   \n 1.Sí \n 2.No");
            var opcionOperar = int.Parse(Console.ReadLine());
            Console.Clear();
            if (opcionOperar == 1) return false;
            else return true;
        }
    }

    class FormasPago
    {
        public string Tipo { get; set; }
        public FormasPago(string tipo)
        {
            Tipo = tipo;
        }

        public void MostrarFormaPago()
        {
           
            Console.WriteLine("\nForma de pago: "+this.Tipo);
        }

    }
    class Carrito
    {
        private List<ProductoEnCarrito> Productos = new List<ProductoEnCarrito>();

        public void Agregar(Producto producto, int cantidad)
        {
            var prodEnCarrito = new ProductoEnCarrito();
            prodEnCarrito.Producto = producto;
            prodEnCarrito.Cantidad = cantidad;

            Productos.Add(prodEnCarrito);
        }

        public List<ProductoEnCarrito> obtenerProductosEnCarrito()
        {
            return Productos;
        }

        public void MostrarCarrito()
        {
            Console.WriteLine("");
            Console.WriteLine("Productos en carrito: ");

            decimal totalCarrito = 0;
            foreach (var productoEnCarrito in Productos)
            {
                var cantidad = productoEnCarrito.Cantidad;
                var precio = productoEnCarrito.Producto.Precio;
                var nombre = productoEnCarrito.Producto.Nombre;
                Console.WriteLine(cantidad + "x " + nombre + " $" + cantidad * precio);

                totalCarrito = totalCarrito + cantidad * precio;
            }

            Console.WriteLine("Total: $" + totalCarrito);
        }
    }

    class ProductoEnCarrito
    {
        public Producto Producto { get; set; }
        public int Cantidad { get; set; }
    }

    class Producto
    {
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public string Marca { get; set; }

        public Producto(string nombre, decimal precio, string marca)
        {
            Nombre = nombre;
            Precio = precio;
            Marca = marca;
        }
    }
    class RegistroProductos
    {
        public static List<Producto> Productos = new List<Producto>();
        static RegistroProductos()
        {
            Productos.Add(new Producto("Cafetera", 3000, "Philips"));
            Productos.Add(new Producto("Celular", 249999.99m, "Apple"));
            Productos.Add(new Producto("Televisor", 22000, "Sony"));
            Productos.Add(new Producto("Ojotas", 700, "Havaianas"));
            Productos.Add(new Producto("Teclado", 6500.99m, "Razer"));
        }

        static public void MostrarProductos()
        {
            Console.WriteLine();
            Console.WriteLine("OPEN SHOP");
            Console.WriteLine("Listado de productos:");
            int pos = 1;
            foreach (var producto in Productos)
            {
                Console.WriteLine(pos + "-" + producto.Nombre + " " + producto.Marca + " $" + producto.Precio);
                pos++;
            }
        }
    }


    class Venta
    {
        public FormasPago FormaPago { get; set; }
        public Carrito Carrito { get; set; }
        public DateTime Fecha { get; set; }

        public Venta(List<ProductoEnCarrito> productos, FormasPago formaPago)
        {
            Carrito = new Carrito();
            Fecha = DateTime.Now;
            FormaPago = formaPago; 

            foreach (var item in productos)
            {
                Carrito.Agregar(item.Producto, item.Cantidad);
            }
        }

    }
}