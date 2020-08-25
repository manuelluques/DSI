using System.Collections.Generic;
using System;
namespace DSI_TP3
{

    public class Curso
    {

        public Curso(string nombre, string descripcion)
        {
            Nombre = nombre;
            Descripcion = descripcion;

        }
   
        public string Nombre { get; }
        public string Descripcion { get; }
        public void MostrarCurso()
        {
            Console.WriteLine($"Curso: {Nombre}");
            Console.WriteLine($"{Descripcion}");
        }

    }
}