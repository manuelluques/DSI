using System;
using System.Collections.Generic;


namespace DSI_TP3
{
    public class RegistroDictadoCursos
    {
        public RegistroDictadoCursos()
        {
            CursosDictados= new List<DictadoCurso>(); 
        }
        public List<DictadoCurso> CursosDictados { get; }


        public void AgregarDictadoCurso(DictadoCurso dictadoCurso ){
         CursosDictados.Add(dictadoCurso); 
        }

        public void MostarCursosVigentes() {
         
         List<DictadoCurso> cursosVigentes = CursosDictados.FindAll(x => x.Vigente == true); 

          for (int i = 0; i < cursosVigentes.Count; i++)
            {
                Console.Write("\n"+(i + 1).ToString() + ". ");
                cursosVigentes[i].MostrarDictadoCurso();
            }
 

        }


        public bool VerificarCursosVigentes () {
            
             bool cursosVigentes = CursosDictados.Exists(x => x.Vigente == true);  

             return cursosVigentes; 

        }
    
    }
}