using System;
using System.Collections.Generic;

namespace DSI_TP2
{

    class Cliente
    {
        public string Nombre { get; }
        public string Apellido { get; }
        public string Email { get; }
        public double Telefono { get; }
        public Empresa Empresa { get; }

       
       //Hice este controlador con menos parámetros para facilitar un preset de datos
        public Cliente(string nombre, string apellido)
        {
            Nombre = nombre;
            Apellido = apellido;
        }

        public Cliente(string nombre, string apellido, string email, double telefono, Empresa empresa)
        {
            Nombre = nombre;
            Apellido = apellido;
            Email = email;
            Telefono = telefono;
            Empresa = empresa;
        }

        public void MostrarCliente()
        {
            Console.WriteLine($"Cliente:  {Nombre} {Apellido}");
        }

        public void MostrarClienteExpandido()
        {
            Console.WriteLine( $"Cliente: {Nombre} {Apellido} ");
            Console.WriteLine($"Email: {Email} ");
            Console.WriteLine($"Telefono: {Telefono}");
            Console.WriteLine($"Empresa: {Empresa.Nombre}");   
        }
    }

}