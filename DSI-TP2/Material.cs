using System;

namespace DSI_TP2
{
     class Material
    {
        public string Nombre { get; }
        public decimal PrecioBolsa { get; }
        

        public Material(string nombre, decimal precioBolsa)
        {
            Nombre = nombre;
            PrecioBolsa = precioBolsa;

        }


        public void MostrarMaterial() {
            Console.WriteLine($"Material: {Nombre}  $ {PrecioBolsa}"); 
        }


    }
}

