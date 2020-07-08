using System;
using System.Collections.Generic;

namespace DSI_TP3
{
    public class RegistroAlumnos
    {

        public RegistroAlumnos()
        {
            Alumnos = new List<Alumno>();

            Alumnos.Add(new Alumno("Manuel", "Luques", 42695483, "mlques33@gmail.com", 3564608319)); 
           
        }
        public List<Alumno> Alumnos { get; }


        public void AgregarAlumno(Alumno alumno)
        {
            Alumnos.Add(alumno);
        }

        public void MostrarAlumnos()
        {
            for (int i = 0; i < Alumnos.Count; i++)
            {
                Console.Write("\n"+(i + 1).ToString() + ". ");
                Alumnos[i].MostrarAlumno();
            }
        }


    }
}