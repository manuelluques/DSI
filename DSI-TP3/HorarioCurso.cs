
using System;

namespace DSI_TP3
{
    public class HorarioCurso
    {


        public HorarioCurso(string dia, DateTime horaInicio, DateTime horaFin)
        {
            HoraInicio = horaInicio;
            HoraFin = horaFin;
            Dia = dia;

        }

        public string Dia { get; }
        public DateTime HoraInicio { get; }
        public DateTime HoraFin { get; }


        public void MostrarHorarioCurso()
        {
            Console.WriteLine($"Día: {Dia} Horario: {HoraInicio.ToString("HH:mm")} - {HoraFin.ToString("HH:mm")}");
        }



    }
}