using System;
using System.Collections.Generic;

namespace DSI_TP3 {
    public class RegistroCursos {

        public void AgregarCurso (Curso curso) {
            var db = GestorBD.ObtenerRegistros ();
            db.Cursos.Add (curso);
            GestorBD.SobrescribirRegistros (db);
        }

        public void MostrarCursos () {
            var db = GestorBD.ObtenerRegistros ();
            for (int i = 0; i < db.Cursos.Count; i++) {
                Console.Write ("\n" + (i + 1).ToString () + ". ");
                db.Cursos[i].MostrarCurso ();
            }
        }

        public Curso ObtenerCurso (int index) {
            var db = GestorBD.ObtenerRegistros ();
            return db.Cursos[index];
        }

      
    }

}