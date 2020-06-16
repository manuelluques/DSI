using System;
using System.Collections.Generic;

namespace DSI_TP2
{
    class Pedido
    {
        public List<Cotizacion> Cotizaciones { get; }
        public Cliente Cliente { get; }
        public Material Material { get; }
        public string DireccionObra { get; }
        public double Superficie { get; }
      
        public int CantidadBolsas{get; }
        public MetodoAplicacion MetodoAplicacion { get; }

        public Pedido(Material material, double superficie, string direccionObra, Cliente cliente, MetodoAplicacion metodoAplicacion)
        {
            Material = material;
            Superficie = superficie;
            DireccionObra = direccionObra;
            Cliente = cliente;
            MetodoAplicacion = metodoAplicacion;
            CantidadBolsas = (int)Math.Ceiling(Superficie / MetodoAplicacion.RendimientoBolsa); 
            Cotizaciones = new List<Cotizacion>();
            CotizarPedido();
        }


        public void CotizarPedido()
        {
            var costoMaterial = (decimal)CantidadBolsas* Material.PrecioBolsa;
            var costoAplicacion = (decimal)Superficie * MetodoAplicacion.Precio;
            var costoTotal = costoMaterial + costoAplicacion;
            var cotizacion = new Cotizacion(costoTotal);
            Cotizaciones.Add(cotizacion);
        }

        public void MostrarPedido()
        {
            Console.WriteLine("\n-----------PEDIDO--------------");
            Cliente.MostrarCliente();
            Material.MostrarMaterial();
            Console.WriteLine($"Cantidad de bolsas requeridas: {CantidadBolsas}"); 
            MetodoAplicacion.MostrarMetodoAplicacion();
            Console.WriteLine($"Direccion: {DireccionObra}");
            Console.WriteLine($"Superficie: {Superficie} m2");
            Console.WriteLine("\nCotizaciones:\n");
            foreach (var cotizacion in Cotizaciones)
            {
                cotizacion.MostarCotizacion();
            }
        }



    }
}