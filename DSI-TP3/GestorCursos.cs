using System;


namespace DSI_TP3
{
    class GestorCursos
    {

        static RegistroCursos RegistroCursos = new RegistroCursos();
        static RegistroDictadoCursos RegistroDictadoCursos = new RegistroDictadoCursos();
        static RegistroProfesores RegistroProfesores = new RegistroProfesores();
        static RegistroAlumnos RegistroAlumnos = new RegistroAlumnos();
        static RegistroInscripciones RegistroInscripciones = new RegistroInscripciones();



        static void Main(string[] args)
        {
            while (true)
            {
                var finalizado = Operando();

                if (finalizado)
                {
                    break;
                }
            }
        }

        static bool Operando()
        {
            Console.WriteLine("----------------MENU---------------");
            Console.WriteLine("1.Crear un curso");
            Console.WriteLine("2.Abrir el dictado de un curso ");
            Console.WriteLine("3.Inscribir un alumno a un curso");
            Console.WriteLine("4.Asignar un profesor a un curso");
            Console.WriteLine("5.Cancelar un curso");




            string opcionMenu = Console.ReadLine();
            Console.Clear();

            switch (int.Parse(opcionMenu))
            {
                case 1:
                    {
                        CrearUnCurso();
                        break;
                    }
                case 2:
                    {
                        AbrirDictadoCurso();
                        break;
                    }
                case 3:
                    {
                        InscribirAlumno();
                        break;
                    }
                case 4:
                    {
                        AsignarNuevoProfesor();
                        break;
                    }
                case 5:
                    {
                        CancelarCurso();
                        break;
                    }
                default:
                    {
                        Console.WriteLine("La opción ingresada no es válida\n");
                        Console.WriteLine("Presione una tecla para continuar");
                        Console.ReadKey();
                        break;
                    }

            }

            var continuar = MostrarMenuContinuar();
            return continuar;

        }

        static bool MostrarMenuContinuar()
        {
            Console.Clear();
            Console.WriteLine("\n¿Desea continuar operando?   \n1.Sí \n2.No");
            var opcionOperar = int.Parse(Console.ReadLine());
            Console.Clear();
            if (opcionOperar == 1) return false;
            else return true;
        }

        static void CrearUnCurso()
        {
            Console.WriteLine("------Nuevo turno-------");
            Console.WriteLine("\nIngrese el nombre del curso: ");
            var nombre = Console.ReadLine();

            Console.WriteLine("\nIngrese la descripción del curso: ");
            var descripcion = Console.ReadLine();

            Console.Clear();

            var curso = new Curso(nombre, descripcion);

            curso.MostrarCurso();
            Console.WriteLine(" \n ¿Guardar? \n1.Si \n2.No");

            var guardar = int.Parse(Console.ReadLine());
            if (guardar == 1) RegistroCursos.AgregarCurso(curso);

            Console.Clear();
            Console.WriteLine("Curso guardado!");

        }

        static void AbrirDictadoCurso()
        {
            Console.WriteLine("------Abrir dictado de un curso-------");

            RegistroCursos.MostrarCursos();
            Console.WriteLine("\nIngresar curso: ");
            var cursoIndice = int.Parse(Console.ReadLine()) - 1;
            Curso curso = RegistroCursos.Cursos[cursoIndice];
            Console.Clear();

            Console.WriteLine("Ingresar número de aula: ");
            var aula = int.Parse(Console.ReadLine());
            Console.Clear();

            Console.WriteLine("Ingresar la fecha límite de inscripción (dd/MM/yyyy):");

            var fechaLimiteString = Console.ReadLine();
            var fechaLimite = DateTime.ParseExact(fechaLimiteString, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            Console.Clear();

            Console.WriteLine("Ingresar el cupo máximo: ");
            var cupoMax = int.Parse(Console.ReadLine());
            Console.Clear();

            Console.WriteLine("Ingresar el cupo mínimo: ");
            var cupoMin = int.Parse(Console.ReadLine());
            Console.Clear();


            var dictadoCurso = new DictadoCurso(curso, aula, fechaLimite, cupoMax, cupoMin);

            dictadoCurso.AgregarHorarios();
            Console.Clear();

            bool seguirAgregandoProfesores = false;

            do
            {
                RegistroProfesores.MostrarProfesores();
                Console.WriteLine("\nIngresar profesor: ");
                var profesorIndice = int.Parse(Console.ReadLine()) - 1;
                Profesor profesor = RegistroProfesores.Profesores[profesorIndice];
                Console.Clear();

                dictadoCurso.AgregarProfesor(profesor);

                Console.WriteLine("\n¿Agregar otro profesor? \n1.Si \n2.No");

                var seguir = int.Parse(Console.ReadLine());
                if (seguir == 1) seguirAgregandoProfesores = true;

            } while (seguirAgregandoProfesores);

            Console.Clear();

            dictadoCurso.MostrarDictadoCurso();

            Console.WriteLine("\n¿Guardar?\n1.Si\n2.No");

            var guardar = int.Parse(Console.ReadLine());
            if (guardar == 1) RegistroDictadoCursos.AgregarDictadoCurso(dictadoCurso);

        }


        static void InscribirAlumno()
        {

            bool existenCursosVigentes = RegistroDictadoCursos.VerificarCursosVigentes();

            if (!existenCursosVigentes)
            {
                Console.WriteLine("\nNo hay cursos vigentes");
                Console.WriteLine("Presione una tecla para continuar");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("---------Inscripción---------");
            Alumno alumno = obtenerAlumno();
            Console.Clear();

            Console.WriteLine("Cursos vigentes: ");
            RegistroDictadoCursos.MostarCursosVigentes();
            Console.WriteLine("\nElegir un curso: ");
            var cursoIndice = int.Parse(Console.ReadLine()) - 1;
            DictadoCurso dictadoCurso = RegistroDictadoCursos.CursosDictados[cursoIndice];
            Console.Clear();

            var inscripcion = new Inscripcion();
            inscripcion.Alumno = alumno;
            inscripcion.DictadoCurso = dictadoCurso;
            inscripcion.MostrarInscripcion();

            Console.WriteLine("\n¿Guardar?\n1.Si\n2.No");
            var guardar = int.Parse(Console.ReadLine());
            if (guardar == 1) RegistroInscripciones.AgregarInscripcion(inscripcion);
            Console.Clear();
        }





        static Alumno obtenerAlumno()
        {
            Console.WriteLine("1.Registrar un nuevo alumno");
            Console.WriteLine("2.Elegir un alumno existente");
            var opcionMenu = int.Parse(Console.ReadLine());

            if (opcionMenu == 1)
            {
                Console.WriteLine("Ingrese el nombre:");
                string nombre = Console.ReadLine();
                Console.Clear();

                Console.WriteLine("Ingrese el apellido: ");
                string apellido = Console.ReadLine();
                Console.Clear();

                Console.WriteLine("Ingrese el dni: ");
                double dni = double.Parse(Console.ReadLine());
                Console.Clear();

                Console.WriteLine("Ingrese el e-mail:");
                string email = Console.ReadLine();
                Console.Clear();

                Console.WriteLine("Ingrese el teléfono: ");
                double telefono = double.Parse(Console.ReadLine());
                Console.Clear();

                Alumno alumno = new Alumno(nombre, apellido, dni, email, telefono);

                RegistroAlumnos.AgregarAlumno(alumno);

                return alumno;
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Alumnos: ");
                RegistroAlumnos.MostrarAlumnos();
                Console.WriteLine("\nElegir alumno: ");
                var alumnoIndice = int.Parse(Console.ReadLine()) - 1;
                Alumno alumno = RegistroAlumnos.Alumnos[alumnoIndice];
                return alumno;
            }

        }

        static void CancelarCurso()
        {

            var cursosVigentes = RegistroDictadoCursos.VerificarCursosVigentes();

            if (!cursosVigentes)
            {
                Console.WriteLine("\nNo hay cursos vigentes");
                Console.WriteLine("Presione una tecla para continuar");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("Cursos vigentes: ");
            RegistroDictadoCursos.MostarCursosVigentes();

            Console.WriteLine("\nIndique el curso que desea cancelar: ");
            var cursoIndice = int.Parse(Console.ReadLine()) - 1;
            RegistroDictadoCursos.CursosDictados[cursoIndice].Vigente = false;

            Console.WriteLine("Cancelado exitósamente");

        }


        static void AsignarNuevoProfesor()
        {

            var cursosVigentes = RegistroDictadoCursos.VerificarCursosVigentes();

            if (!cursosVigentes)
            {
                Console.WriteLine("\nNo hay cursos vigentes");
                Console.WriteLine("Presione una tecla para continuar");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("Cursos vigentes: ");
            RegistroDictadoCursos.MostarCursosVigentes();

            Console.WriteLine("\nIndique el curso al que desea agregar un profesor: ");
            var cursoIndice = int.Parse(Console.ReadLine()) - 1;
            Console.Clear();

            Console.WriteLine("Ingrese el profesor que desea agradar: ");
            RegistroProfesores.MostrarProfesores();
            var profesorIndice = int.Parse(Console.ReadLine());
            var profesor = RegistroProfesores.Profesores[profesorIndice];
            Console.Clear();

            RegistroDictadoCursos.CursosDictados[cursoIndice].AgregarProfesor(profesor);
            Console.WriteLine("Profesor agregado exitósamente");

        }



    }





}




