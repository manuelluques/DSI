using System;
using System.Collections.Generic;

namespace DSI_TP2
{
    public class RegistroEmpresas
    {
        public List<Empresa> Empresas { get; }

        public RegistroEmpresas()
        {
            Empresas = new List<Empresa>();

            Empresas.Add(new Empresa("Globant"));
            Empresas.Add(new Empresa("Accenture"));
            Empresas.Add(new Empresa("Olapic"));

        }

        public void MostrarEmpresas()
        {
            for (int i = 0; i < Empresas.Count; i++)
            {
                Console.Write((i + 1).ToString() + ". ");
                Empresas[i].MostrarEmpresa();
            }
        }

        public void AgregarEmpresa( Empresa empresa) {
            Empresas.Add(empresa); 
        }

    }
}