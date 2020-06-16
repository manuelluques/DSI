using System;

namespace DSI_TP2
{
    class MetodoAplicacion
    {

        public decimal Precio { get; }
        public string Descripcion { get; }
        public double Espesor { get; }

        public double RendimientoBolsa { get; }
        public MetodoAplicacion(string descripcion, double espesor, decimal precio)
        {
            Descripcion = descripcion;
            Precio = precio;
            Espesor = espesor;
            RendimientoBolsa = espesor * 4.5 / 100;
        }

        public void MostrarMetodoAplicacion () {
            Console.WriteLine($"{Descripcion} ${Precio} Espesor: {Espesor}mm"); 
        }

    }

}