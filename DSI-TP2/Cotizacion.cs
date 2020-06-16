using System;

namespace DSI_TP2
{
    class Cotizacion
    {
        decimal Precio { get; set; }
        DateTime FechaRealizacion { get; set; }
        DateTime FechaVencimiento { get; set; }

        public Cotizacion(decimal precio)
        {
            Precio=precio;
            FechaRealizacion = DateTime.Now; 
            FechaVencimiento= DateTime.Now.AddDays(30); 
        }

        public void MostarCotizacion(){
            Console.WriteLine($"{FechaRealizacion.ToShortDateString()} ${Precio} Vence: {FechaVencimiento.ToShortDateString()}"); 
        }
    }


}

