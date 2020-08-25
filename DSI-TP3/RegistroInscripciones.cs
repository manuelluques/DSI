using System.Collections.Generic;

namespace DSI_TP3 {
    public class RegistroInscripciones {

        public void AgregarInscripcion (Inscripcion inscripcion) {
            var db = GestorBD.ObtenerRegistros ();
            db.Inscripciones.Add (inscripcion);
            GestorBD.SobrescribirRegistros (db);
        }

    }

}