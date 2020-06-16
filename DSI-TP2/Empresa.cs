using System; 
namespace DSI_TP2
{
   public class Empresa {
       public string Nombre {get; }
       
       public Empresa(string nombre)
       {
           Nombre= nombre; 
       }
       
       public void MostrarEmpresa() {
          Console.WriteLine($"Empresa: {Nombre}"); 
       }

   }
}