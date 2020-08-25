using System;
using System.Collections.Generic;

namespace DSI_TP3 {

    public class RegistroDictadoCursos {


        public void AgregarDictadoCurso (DictadoCurso dictadoCurso) {
            var db = GestorBD.ObtenerRegistros ();
            db.CursosDictados.Add (dictadoCurso);
            GestorBD.SobrescribirRegistros (db);
        }

        public void MostarCursosVigentes () {
            var db = GestorBD.ObtenerRegistros ();
            List<DictadoCurso> cursosVigentes = db.CursosDictados.FindAll (x => x.Vigente == true);

            for (int i = 0; i < cursosVigentes.Count; i++) {
                Console.Write ("\n" + (i + 1).ToString () + ". ");
                cursosVigentes[i].MostrarDictadoCurso ();
            }

        }

        public bool VerificarCursosVigentes () {

            var db = GestorBD.ObtenerRegistros ();
            bool cursosVigentes = db.CursosDictados.Exists (x => x.Vigente == true);
            return cursosVigentes;

        }

        public DictadoCurso ObtenerCursoDictado (int index) {
            var db = GestorBD.ObtenerRegistros ();
            return db.CursosDictados[index];
        }
        
          public void CancelarCurso (int index) {
            var db = GestorBD.ObtenerRegistros ();
            db.CursosDictados[index].CancelarCurso();
            GestorBD.SobrescribirRegistros (db);
        }


        public void AgregarProfesorCurso (int index, Profesor profesor){
            var db  = GestorBD.ObtenerRegistros(); 
            Console.Write("El indice es "+ index); 
            Console.Write("El largo es "+ db.CursosDictados.Count);
            db.CursosDictados[index].AgregarProfesor(profesor); 
            GestorBD.SobrescribirRegistros(db); 
        }

        

    }
}