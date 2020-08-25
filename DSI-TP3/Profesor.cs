using System; 
namespace DSI_TP3
{
    public class Profesor
    {

        public Profesor(string nombre, string apellido, double telefono, double dni, string email)
        {
            Nombre = nombre;
            Apellido = apellido;
            Telefono = telefono;
            Dni = dni;
            Email = email;
        }
       
        public string Nombre { get; }
        public string Apellido { get; }
        public double Telefono { get; }
        public double Dni { get; }
        public string Email { get; }


        public void MostarProfesor()
        {
          Console.WriteLine($"Profesor: {Apellido}, {Nombre} ({Dni})"); 
          Console.WriteLine($"Teléfono: {Telefono} E-mail: {Email}");
        }

    }
}