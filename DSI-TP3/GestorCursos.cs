using System;

namespace DSI_TP3
{
    class GestorCursos
    {
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
         


            string opcionMenu = Console.ReadLine();
            Console.Clear();

            switch (int.Parse(opcionMenu))
            {
                case 1:
                    {
                       
                        break;
                    }
                case 2:
                    {
                
                        break;
                    }
                case 3:
                    {
                        
                        break;
                    }
                case 4:
                    {
                    
                        break;
                    }
                case 5:
                    {
                        
                        break;
                    }
                default:
                    {
                         Console.WriteLine("La opción ingresada no es válida\n");
                        break;
                    }

            }

            var continuar = MostrarMenuContinuar();
            return continuar;

        }

        static bool MostrarMenuContinuar()
        {
            Console.WriteLine("\nDesea continuar operando?   \n 1.Sí \n 2.No");
            var opcionOperar = int.Parse(Console.ReadLine());
            Console.Clear();
            if (opcionOperar == 1) return false;
            else return true;
        }
    }
}
