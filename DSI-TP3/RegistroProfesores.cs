using System;
using System.Collections.Generic;

namespace DSI_TP3 {
    public class RegistroProfesores {

        // public RegistroProfesores () {

        //     AgregarProfesor (new Profesor ("Jorge Luis", "Borges", 3564608319, 6326967, "jl@gmail.com"));
        //     AgregarProfesor (new Profesor ("Adolfo", "Bioy Casáres", 3564698545, 7326967, "abc@gmail.com"));

        // }
        // public List<Profesor> Profesores { get; }

        public void AgregarProfesor (Profesor profesor) {
            var db = GestorBD.ObtenerRegistros ();
            db.Profesores.Add (profesor);
            GestorBD.SobrescribirRegistros (db);

        }

        public void MostrarProfesores () {
             var db = GestorBD.ObtenerRegistros ();

            for (int i = 0; i < db.Profesores.Count; i++) {
                Console.Write ("\n" + (i + 1).ToString () + ". ");
                db.Profesores[i].MostarProfesor ();
            }
        }


           public Profesor ObtenerProfesor(int index ) {
             var db = GestorBD.ObtenerRegistros ();
             return db.Profesores[index]; 
        }

    }
}