using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD8__MVC___DAO_en_C__.ViewLayer
{
    /// <summary>
    /// Displays the main menu and simple messages
    /// Contains ONLY Console I/O
    /// </summary>
    public class PrincipalView
    {
        public int AfficherMenuPrincipal()
        {
            Console.WriteLine("\n--- MENU PRINCIPAL: ---");
            Console.WriteLine("1. Gerer les etudiants");
            Console.WriteLine("2. Gerer les cours");
            Console.WriteLine("3. Gerer les inscriptions");
            Console.WriteLine("0. Quitter l'application");
            var s = Console.ReadLine();
            return int.TryParse(s, out var x) ? x : -1;
        }

        public void AfficherMessage(string message) => Console.WriteLine(message);
    }
}
