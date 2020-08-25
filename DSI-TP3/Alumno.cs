using System; 


namespace DSI_TP3
{
   public class Alumno {
    

     public Alumno(string nombre, string apellido, double dni, string email, double telefono)
     {
        Nombre = nombre;
        Apellido = apellido; 
        Dni= dni; 
        Email = email; 
        Telefono = telefono;
     }
   

     public string Nombre {get;}
     public string Apellido {get; } 
     public double Dni {get;}
     public string Email {get;}
     public double Telefono {get;}
     
       public void MostrarAlumno()
        {
          Console.WriteLine($"{Apellido}, {Nombre} ({Dni})"); 
          Console.WriteLine($"Teléfono:{Telefono.ToString()} E-mail: {Email}");
        }


   }    
    
}