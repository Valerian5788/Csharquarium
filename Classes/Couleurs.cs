using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharquarium.Classes
{
    internal class Couleurs
    {
        public void FormatCouleur(string couleur)
        {
            switch (couleur)
            {
                case "Death":
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor= ConsoleColor.Red;
                    return;
                case "Blue":
                    Console.ForegroundColor= ConsoleColor.Blue;
                    return;
                case "Yellow":
                    Console.ForegroundColor= ConsoleColor.Yellow;
                    return;
                case "Green":
                    Console.ForegroundColor=ConsoleColor.Green;
                    return;
                case "Red":
                    Console.ForegroundColor = ConsoleColor.Red;
                    return;
                default:
                    Console.ForegroundColor= ConsoleColor.White;
                    return;
            }
        }
    }
}
