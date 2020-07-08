using System.Collections.Generic;
using System;

namespace DSI_TP3
{
    public class RegistroCursos
    {
        public RegistroCursos()
        {
            Cursos = new List<Curso>();

            //Precarga 
            Cursos.Add(new Curso("Literatura Inglesa 101", "Se explora la obra del autor William Shakespeare"));
            Cursos.Add(new Curso("Literatura Catellana", "Se explora la obra del autor Miguel de Cervantes"));

        }
        public List<Curso> Cursos { get; }


        public void AgregarCurso(Curso curso)
        {
            Cursos.Add(curso);
        }


        public void MostrarCursos()
        {

            for (int i = 0; i < Cursos.Count; i++)
            {
                Console.Write("\n"+(i + 1).ToString() + ". ");
                Cursos[i].MostrarCurso();
            }
        }

    }

}
