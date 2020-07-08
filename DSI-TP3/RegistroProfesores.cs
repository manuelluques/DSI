using System;
using System.Collections.Generic;

namespace DSI_TP3
{
    public class RegistroProfesores
    {

        public RegistroProfesores()
        {
            Profesores = new List<Profesor>();

            //Precarga
            Profesores.Add(new Profesor("Jorge Luis","Borges",3564608319, 6326967, "jl@gmail.com")); 
            Profesores.Add(new Profesor("Adolfo","Bioy Casáres",3564698545, 7326967, "abc@gmail.com")); 

        }
        public List<Profesor> Profesores { get; }


        public void AgregarProfesor(Profesor profesor)
        {
            Profesores.Add(profesor);
        }

            public void   MostrarProfesores()
        {
            for (int i = 0; i < Profesores.Count; i++)
            {
                Console.Write("\n"+(i + 1).ToString() + ". ");
                Profesores[i].MostarProfesor();
            }
        }

    }
}