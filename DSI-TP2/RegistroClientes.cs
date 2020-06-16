using System;
using System.Collections.Generic;

namespace DSI_TP2
{
    class RegistroClientes
    {
        public List<Cliente> Clientes { get;  }
        public RegistroClientes()
        {
            Clientes = new List<Cliente>();

            
            Clientes.Add(new Cliente("Adolfo", "Bioy Cáseres"));
            Clientes.Add(new Cliente("Jorge Luis","Borges")); 
            Clientes.Add(new Cliente("Maria Amalia","Lacroze de Forbat")); 
        }

        public void MostrarClientes()
        {
            for (int i = 0; i < Clientes.Count; i++)
            {
                Console.Write((i + 1).ToString() + ". " );
                Clientes[i].MostrarCliente(); 
            }
        } 

        public void agregarCliente (Cliente cliente) 
        {
            Clientes.Add(cliente); 
        }
    }
}