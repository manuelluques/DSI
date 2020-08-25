using System;
using System.Collections.Generic;

namespace DSI_TP3 {
    public class RegistroAlumnos {

        public void AgregarAlumno (Alumno alumno) {
            var db = GestorBD.ObtenerRegistros ();
            db.Alumnos.Add(alumno);
            GestorBD.SobrescribirRegistros (db);
        }

        public void MostrarAlumnos () {

            var db = GestorBD.ObtenerRegistros ();
            for (int i = 0; i < db.Alumnos.Count; i++) {
                Console.Write ("\n" + (i + 1).ToString () + ". ");
                db.Alumnos[i].MostrarAlumno ();
            }
        }

           public Alumno ObtenerAlumno(int index ) {
             var db = GestorBD.ObtenerRegistros ();
             return db.Alumnos[index]; 
        }

    }
}