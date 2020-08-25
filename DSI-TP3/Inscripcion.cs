using System;
namespace DSI_TP3
{

    public class Inscripcion
    {

        public Alumno Alumno { get; set;  }
        public DictadoCurso DictadoCurso { get; set; }

        public void MostrarInscripcion()
        {
            Console.WriteLine("-------INSCRIPCIÓN------"); 
            DictadoCurso.MostrarDictadoCurso(); 
            Console.WriteLine("\nInscripto:");
            Alumno.MostrarAlumno(); 
        }


    }

}