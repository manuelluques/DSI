using System.Collections.Generic;
namespace DSI_TP3 {

    public  class BaseDatosModel {
       
        //Funciona como una interface.
        //Inicialmente lo declaré así, pero no dejaba 

        public List<Alumno> Alumnos { get; set; }
        public List<Curso> Cursos { get; set; }
        public List<DictadoCurso> CursosDictados { get; set; }
        public List<Inscripcion> Inscripciones { get; set; }
        public List<Profesor> Profesores { get; set; }

    }

}