using System;
using System.Collections.Generic;

namespace DSI_TP3
{
    public class DictadoCurso
    {

        public DictadoCurso(Curso curso, int aulaId, DateTime fechaLimiteInscripcion, int cupoMaximo, int cupoMinimo)
        {
            HorariosCurso = new List<HorarioCurso>();
            AulaId = aulaId;
            FechaLimiteInscripcion = fechaLimiteInscripcion;
            CupoMaximo = cupoMaximo;
            CupoMinimo = cupoMinimo;
            Curso = curso;
            Profesores = new List<Profesor>();
            Vigente = true;

        }

        public Curso Curso { get; }
        public List<HorarioCurso> HorariosCurso { get; }
        public int AulaId { get; }
        public DateTime FechaLimiteInscripcion { get; }
        public int CupoMinimo { get; }
        public int CupoMaximo { get; }
        public bool Vigente { get; set; }

        public List<Profesor> Profesores { get; set; }


        public void MostrarDictadoCurso()
        {
          
            Curso.MostrarCurso();
            Console.WriteLine($"Cupo mínimo: {CupoMinimo} Cupo máximo: {CupoMaximo} Aula: {AulaId} ");
            Console.WriteLine($"Límite inscripcion: {FechaLimiteInscripcion.ToShortDateString()} ");

            Console.WriteLine("\nHorarios: ");

            foreach (HorarioCurso horarioCurso in HorariosCurso)
            {
                horarioCurso.MostrarHorarioCurso();
            }

            Console.WriteLine("\nProfesores: ");

            foreach (Profesor profesor in Profesores)
            {
                profesor.MostarProfesor(); 
            }
        }


        public void CancelarCurso () {
            Vigente = false;
        }


        public void AgregarProfesor(Profesor profesor)
        {
            Profesores.Add(profesor);
        }

        public void AgregarHorarios()
        {

            string[] dias = { "Lunes", "Martes", "Miércoles", "Jueves", "Viernes" };

            var seguirAgregandoHorarios = false;

            do
            {
                Console.WriteLine("Seleccione el día: ");

                for (int i = 0; i < dias.Length; i++)
                {
                    Console.Write((i + 1).ToString() + ". ");
                    Console.WriteLine(dias[i]);
                }

                var diaIndice = int.Parse(Console.ReadLine());
                string dia = dias[diaIndice];
                Console.Clear();

                Console.WriteLine("Ingrese hora de comienzo del curso (HH:mm) : ");
                var horaInicioString = Console.ReadLine();
                var horaInicio = DateTime.ParseExact(horaInicioString, "HH:mm", System.Globalization.CultureInfo.InvariantCulture);

                Console.WriteLine("Ingrese hora de fin del curso (HH:mm) : ");
                var horaFinString = Console.ReadLine();
                var horaFin = DateTime.ParseExact(horaFinString, "HH:mm", System.Globalization.CultureInfo.InvariantCulture);

                Console.Clear();

                var horarioCurso = new HorarioCurso(dia, horaInicio, horaFin);

                horarioCurso.MostrarHorarioCurso();
                Console.WriteLine("\n¿Guardar? \n1.Si \n2.No");

                var guardar = int.Parse(Console.ReadLine());
                if (guardar == 1) HorariosCurso.Add(horarioCurso);
                Console.Clear();

                Console.WriteLine("\n¿Desea agregar otro horario? \n1.Si \n2.No");

                var seguir = int.Parse(Console.ReadLine());
                if (seguir == 1) seguirAgregandoHorarios = true;
                Console.Clear();

            } while (seguirAgregandoHorarios); 

        }

       
    }
}