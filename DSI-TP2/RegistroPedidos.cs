using System.Collections.Generic;
using System;

namespace DSI_TP2
{
     class RegistroPedidos
    {

        public List<Pedido> Pedidos { get; }

        public RegistroPedidos()
        {
            Pedidos = new List<Pedido>();
        }

        public void MostrarPedidos()
        {

            var hayPedidos = false;

            for (int i = 0; i < Pedidos.Count; i++)
            {
                Console.Write((i + 1).ToString() + ". ");
                Pedidos[i].MostrarPedido();
                hayPedidos = true;
            }

            if (!hayPedidos) Console.WriteLine("No hay pedidos registrados al mometo");
        }

         public void AgregarPedido(Pedido pedido)
        {
           Pedidos.Add(pedido); 
        }
    }
}