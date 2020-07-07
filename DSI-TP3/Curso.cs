using System.Collections.Generic;

namespace DSI_TP3
{

    public class Curso
    {

        public Curso(string nombre, string descripcion)
        {
            Nombre = nombre;
            Descripcion = descripcion;
        }

        public string Nombre { get; }
        public string Descripcion { get; }
        public List<Profesor> Profesores { get; }


        public void AsignarProfesor (Profesor profesor ){
            
            

        }


       

    }
}