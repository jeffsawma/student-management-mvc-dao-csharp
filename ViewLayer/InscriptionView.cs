using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace TD8__MVC___DAO_en_C__.ViewLayer
{
    /// <summary>
    /// All enrollment-related display and input lives here
    /// </summary>
    public class InscriptionView
    {
        public int AfficherMenuInscription()
        {
            Console.WriteLine("\n--- GESTION DES INSCRIPTIONS ---");
            Console.WriteLine("1. Lister les inscriptions par etudiant ---");
            Console.WriteLine("2. Lister les inscriptions par cours ---");
            Console.WriteLine("3. Ajouter une inscription");
            Console.WriteLine("4. Supprimer une inscription");
            Console.WriteLine("0. Retour");
            var s = Console.ReadLine();
            return int.TryParse(s, out var x) ? x : -1;
        }

        public (int etudiantId, int coursId, string session, decimal? note) SaisirInfosInscription()
        {
            Console.Write("Etudiant Id: ");
            int.TryParse(Console.ReadLine(), out var eId);

            Console.Write("Cours Id: ");
            int.TryParse(Console.ReadLine(), out var cId);

            Console.Write("Session (ex: H25, A24): ");
            var session = Console.ReadLine() ?? "";

            Console.WriteLine("Note (vide = N/A): ");
            var ns = Console.ReadLine();
            decimal? note = decimal.TryParse(ns, out var n) ? n : null;

            return (eId, cId, session, note);
        }

        public (int etudiantId, int coursId, string session) DemanderCleInscription()
        {
            Console.Write("Etudiant Id: ");
            int.TryParse(Console.ReadLine(), out var eId);
            Console.Write("Cours Id: ");
            int.TryParse(Console.ReadLine(), out var cId);
            Console.Write("Session: ");
            var sess = Console.ReadLine() ?? "";
            return (eId, cId, sess);
        }

        public void AfficherListeParEtudiant(
           int etudiantId,
           List<(string code, string titre, string session, decimal? note)> inscription)
        {
            Console.WriteLine($"\n--- Inscriptions de l'etudiant {etudiantId} ---");
            foreach (var item in inscription)
                Console.WriteLine($"{item.code} - {item.titre} - {item.session} - " +
                                  $"Note: {(item.note.HasValue ? item.note.Value.ToString("0.##") : "N/A")}");
        }

        public void AfficherListeParCours(
            int coursId,
            List<(string prenom, string nom, string session, decimal? note)> inscriptions)
        {
            Console.WriteLine($"\n--- Inscriptions au cours {coursId} ---");
            foreach (var item in inscriptions)
                Console.WriteLine($"{item.prenom} - {item.nom} - {item.session} - " +
                                  $"Note: {(item.note.HasValue ? item.note.Value.ToString("0.##") : "N/A")}");
        }

        public void AfficherMessage(string message) => Console.WriteLine(message);
    }
}
