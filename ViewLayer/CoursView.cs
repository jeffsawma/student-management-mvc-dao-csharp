using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD8__MVC___DAO_en_C__.ViewLayer
{
    /// <summary>
    /// All course-related display and input lives here
    /// </summary>
    public class CoursView
    {
        public int AfficherMenuCours()
        {
            Console.WriteLine("\n--- GESTION DES COURS ---");
            Console.WriteLine("1. Lister les cours");
            Console.WriteLine("2. Ajouter un cours");
            Console.WriteLine("3. Modifier un cours");
            Console.WriteLine("4. Suprrimer un cours");
            Console.WriteLine("0. Retour");
            Console.Write("Votre choix: ");
            var s = Console.ReadLine();
            return int.TryParse(s, out var x) ? x : -1;
        }

        public (string code, string titre) SaisirInfosCours()
        {
            Console.Write("Code: ");
            var code = Console.ReadLine() ?? "";
            Console.Write("Titre: ");
            var titre = Console.ReadLine() ?? "";
            return (code, titre);
        }

        public int DemanderIdCours()
        {
            Console.Write("Id cours: ");
            var s = Console.ReadLine();
            return int.TryParse(s, out var x) ? x : -1;
        }

        public void AfficherListe(List<(int id, string code, string titre)> Cours)
        {
            Console.WriteLine("\n--- LISTE COURS ---");
            foreach (var c in Cours)
                Console.WriteLine($"{c.id} - {c.code} - {c.titre}");
        }
        
        public void AfficherMessage(string message) => Console.WriteLine(message);
    }
}
