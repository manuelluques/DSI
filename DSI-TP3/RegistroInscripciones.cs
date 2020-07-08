using System.Collections.Generic;

namespace DSI_TP3
{
    public class RegistroInscripciones {

        public RegistroInscripciones()
        {
            Inscripciones = new List<Inscripcion>(); 
        }
        public List<Inscripcion> Inscripciones {get; }


        public void AgregarInscripcion(Inscripcion inscripcion){
            Inscripciones.Add(inscripcion); 
        }

        

    }
    
}