using System;
using System.Collections.Generic;

namespace DSI_TP2
{
    class RegistroMaterial
    {

        public List<Material> Materiales { get; }
        public RegistroMaterial()
        {
            Materiales = new List<Material>();
            Materiales.Add(new Material("Estándar", 200.00m));
            Materiales.Add(new Material("Premium", 250.00m));
        }

        public void MostrarMateriales()
        {
            for (int i = 0; i < Materiales.Count; i++)
            {
                Console.Write((i + 1).ToString() + ". ");
                Materiales[i].MostrarMaterial(); 
            }
        }
    }
}