using System.Collections.Generic;
namespace DSI_TP3 {

    public  class BaseDatosModel {
  
      //Podría ser declarado como interface, pero la librería para serializar y deserializar JSON no 
      // lo permitía

        public List<Alumno> Alumnos { get; set; }
        public List<Curso> Cursos { get; set; }
        public List<DictadoCurso> CursosDictados { get; set; }
        public List<Inscripcion> Inscripciones { get; set; }
        public List<Profesor> Profesores { get; set; }

    }

}