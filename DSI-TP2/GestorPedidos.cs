using System;
using System.Collections.Generic;
namespace DSI_TP2
{
    class GestorPedidos
    {

        static RegistroPedidos RegistroPedidos = new RegistroPedidos();
        static RegistroClientes RegistroClientes = new RegistroClientes();
        static RegistroMaterial RegistroMaterial = new RegistroMaterial();
        static RegistroEmpresas RegistroEmpresas = new RegistroEmpresas();
        static RegistroMetodoAplicacion RegistroMetodoAplicacion = new RegistroMetodoAplicacion();

        static void Main(string[] args)
        {

            while (true)
            {
                var finalizado = Operando();

                if (finalizado)
                {
                    break;
                }
            }
        }

        static bool Operando()
        {
            Console.WriteLine("----------------MENU---------------");
            Console.WriteLine("1. Registrar un pedido");
            Console.WriteLine("2. Mostrar Pedidos");
            Console.WriteLine("3. Volver a cotizar un pedido");
            Console.WriteLine("4. Registrar un cliente ");
            Console.WriteLine("5. Registrar una empresa ");


            string opcionMenu = Console.ReadLine();
            Console.Clear();

            switch (int.Parse(opcionMenu))
            {
                case 1:
                    {
                        RegistarPedido();
                        break;
                    }
                case 2:
                    {
                        MostrarPedidos();
                        break;
                    }
                case 3:
                    {
                        RecotizarPedido();
                        break;
                    }
                case 4:
                    {
                        RegistrarCliente();
                        break;
                    }
                case 5:
                    {
                        RegistrarEmpresa();
                        break;
                    }
                default:
                    {
                        Console.WriteLine("La opción ingresada no es válida\n");
                        break;
                    }

            }


            var continuar = MostrarMenuContinuar();
            return continuar;
        }


        static bool MostrarMenuContinuar()
        {
            Console.WriteLine("\nDesea continuar operando?   \n 1.Sí \n 2.No");
            var opcionOperar = int.Parse(Console.ReadLine());
            Console.Clear();
            if (opcionOperar == 1) return false;
            else return true;
        }

        static void RegistarPedido()
        {
            Console.WriteLine("Elija el cliente:");

            RegistroClientes.MostrarClientes();
            var clienteIndice = int.Parse(Console.ReadLine()) - 1;
            var cliente = RegistroClientes.Clientes[clienteIndice];
            Console.Clear();

            Console.WriteLine("Indique el área que desea curbir (en m2): ");
            var superficie = double.Parse(Console.ReadLine());
            Console.Clear();

            Console.WriteLine("Elija el material");
            RegistroMaterial.MostrarMateriales();
            var materialIndice = int.Parse(Console.ReadLine()) - 1;
            Material material = RegistroMaterial.Materiales[materialIndice];
            Console.Clear();

            Console.WriteLine("Elija el método de aplicación");
            RegistroMetodoAplicacion.MostrarMetodosAplicacion();
            var metodoAplicacionIndice = int.Parse(Console.ReadLine()) - 1;
            MetodoAplicacion metodoAplicacion = RegistroMetodoAplicacion.MetodosAplicacion[metodoAplicacionIndice];
            Console.Clear();

            Console.WriteLine("Ingrese la dirección de la obra: ");
            var direccion = Console.ReadLine();
            Console.Clear();

            var pedidoNuevo = new Pedido(material, superficie, direccion, cliente, metodoAplicacion);
            pedidoNuevo.MostrarPedido();

            Console.WriteLine("\n ¿Desea guardar el pedido? \n 1.Sí \n 2.No");
            var guardar = int.Parse(Console.ReadLine());
            Console.Clear();


            if (guardar == 1)
            {
                Console.WriteLine("Pedido guardado!\n");
                RegistroPedidos.AgregarPedido(pedidoNuevo);
            }
        }



        static void MostrarPedidos()
        {
           Console.Clear(); 
           Console.WriteLine("\n --------------PEDIDOS---------------\n "); 
            RegistroPedidos.MostrarPedidos();

        }



        static void RegistrarCliente()
        {

            Console.WriteLine("-------CARGAR INFORMACIÓN------");

            Console.WriteLine("Ingrese el nombre: ");
            var nombre = Console.ReadLine();

            Console.WriteLine("\nIngrese el apellido: ");
            var apellido = Console.ReadLine();

            Console.WriteLine("\nIngrese el e-mail: ");
            var email = Console.ReadLine();

            Console.WriteLine("\nIngrese el teléfono: ");
            var telefono = double.Parse(Console.ReadLine());

            Console.WriteLine("\nSeleccione la empresa:  ");

            RegistroEmpresas.MostrarEmpresas();
            var empresaIndice = int.Parse(Console.ReadLine()) - 1;
            Empresa empresa = RegistroEmpresas.Empresas[empresaIndice];


            var cliente = new Cliente(nombre, apellido, email, telefono, empresa);

            Console.Clear();
            cliente.MostrarClienteExpandido();
            Console.WriteLine(" \n ¿Guardar? \n1.Si \n2.No");

            var guardar = int.Parse(Console.ReadLine());
            if (guardar == 1) RegistroClientes.agregarCliente(cliente);

            Console.Clear();
            Console.WriteLine("Cliente guardado!");

        }

        static void RegistrarEmpresa()
        {

            Console.WriteLine("Ingrese el nombre: ");
            var nombre = Console.ReadLine();

            var empresa = new Empresa(nombre);

            Console.Clear();
            empresa.MostrarEmpresa();
            Console.WriteLine(" \n ¿Guardar? \n1.Si \n2.No");

            var guardar = int.Parse(Console.ReadLine());
            if (guardar == 1) RegistroEmpresas.AgregarEmpresa(empresa);

            Console.Clear();
            Console.WriteLine("Empresa guardada!");



        }

        static void RecotizarPedido()
        {


            MostrarPedidos();

            Console.WriteLine("\nIngrese el pedido a cotizar: ");
            var pedidoIndice = int.Parse(Console.ReadLine()) - 1;
            RegistroPedidos.Pedidos[pedidoIndice].CotizarPedido();

            Console.Clear();

            RegistroPedidos.Pedidos[pedidoIndice].MostrarPedido();
        }







    }
}

