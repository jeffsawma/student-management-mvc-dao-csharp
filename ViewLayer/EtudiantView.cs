using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace TD8__MVC___DAO_en_C__.ViewLayer
{
    /// <summary>
    ///  All student-related display and input lives here
    /// </summary>
    public class EtudiantView
    {
        public int AfficherMenuEtudiant()
        {
            Console.WriteLine("\n--- GESTION DES ETUDIANTS: ---");
            Console.WriteLine("1. Lister les etudiants");
            Console.WriteLine("2. Ajouter un etudiant");
            Console.WriteLine("3. Supprimer un etudiant");
            Console.WriteLine("0. Retour");
            Console.WriteLine("Votre Choix?: ");
            var s = Console.ReadLine(); // Reading the line of the user's input
            return int.TryParse(s, out var x) ? x : -1; // Trying to parse the String respone to an integer then assign the value to the variable x // Or failing the process with '-1'
        }

        public (string prenom, string nom) SaisirInfosEtudiant() // Asking the user for inputs
        {
            Console.Write("Prenom: "); // Output for user to write his first-name
            var prenom = Console.ReadLine() ?? ""; // Reads the value and assign it to a variable named prenom
            Console.Write("Nom: "); // Output for user to write his last-name
            var nom = Console.ReadLine() ?? ""; // Reads the second valur for the second parameter and assign it to a variable named nom
            return (prenom, nom); // Returning the two values 
        }

        public int DemanderIdEtudiant() // Output for the user to enter his unique id
        {
            Console.Write("Id etudiant: ");
            var s = Console.ReadLine();
            return int.TryParse(s, out var id) ? id : -1;
        }

        public void AfficherListe(List<(int id, string prenom, string nom)> etudiants) // Output the whole list of a generic type based on its parameters
        {
            Console.WriteLine("\n--- LISTE ETUDIANTS ---"); // Output of a text message to the user before displaying the list
            foreach (var e in etudiants)
                Console.WriteLine($"{e.id} - {e.prenom} {e.nom}");
        }
        // We use this method 'AfficherMessage' for displaying the success of a procedur later on in the project
        public void AfficherMessage(string message) => Console.WriteLine(message);
    }
}
