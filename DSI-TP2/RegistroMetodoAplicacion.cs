using System;
using System.Collections.Generic;

namespace DSI_TP2
{
    class RegistroMetodoAplicacion
    {

        public List<MetodoAplicacion> MetodosAplicacion { get; }
        public RegistroMetodoAplicacion()
        {
            MetodosAplicacion = new List<MetodoAplicacion>();

            MetodosAplicacion.Add(new MetodoAplicacion("Aplicado en Pared", 50, 53.60m));
            MetodosAplicacion.Add(new MetodoAplicacion("Aplicado en Pared", 70, 87.00m));
            MetodosAplicacion.Add(new MetodoAplicacion("Aplicado en Pared", 100, 117.49m));
            MetodosAplicacion.Add(new MetodoAplicacion("Aplicado en Pared", 120, 128.48m));
            MetodosAplicacion.Add(new MetodoAplicacion("Aplicado en Pared", 160, 143.05m));
            MetodosAplicacion.Add(new MetodoAplicacion("Aplicado en Pared", 200, 180.19m));
        }


        public void MostrarMetodosAplicacion()
        {
            for (int i = 0; i < MetodosAplicacion.Count; i++)
            {
                Console.Write((i + 1).ToString() + ". ");
                MetodosAplicacion[i].MostrarMetodoAplicacion();
            }

        }
    }
}