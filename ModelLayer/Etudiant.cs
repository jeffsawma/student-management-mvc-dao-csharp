using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD8__MVC___DAO_en_C__.ModelLayer
{
    /// <summary>
    /// Etudiant: Id (IDENTITY), Prenom, Nom, + liste de cours suivis
    /// Only data + properties
    /// </summary>
    public class Etudiant
    {
        // Private fields (encapsulation)
        private int _id;
        private string _prenom;
        private string _nom;

        // Public properties (getters/setters)
        public int Id { get => _id; set => _id = value; }
        public string Prenom { get => _prenom; set => _prenom = value; }
        public string Nom { get => _nom; set => _nom = value; }

        // Navigation collection for business logic
        public List<Cours> CoursSuivis { get; set; } = new();

        // Constructor for initialisation
        public Etudiant(int id, string prenom, string nom)
        {
            _id = id;
            _prenom = prenom;
            _nom = nom;
        }

        // ToString() for visual output
        public override string ToString() => $"{Id} - {Prenom} {Nom}";
    }
}

// To do:
// 1. Classe Etudiant
// Créez une classe Etudiant qui représente un étudiant. Cette classe doit contenir :
// •	Un identifiant(Id) de type int, généré automatiquement par la base de données (champ IDENTITY).
// •	Le prénom de l’étudiant.
// •	Le nom de l’étudiant.
// •	Une liste de cours suivis par l’étudiant (List<Cours>).
// Les attributs doivent être private et accessibles via des propriétés publiques.
// Ajoutez un constructeur permettant d’initialiser l’identifiant, le nom et le prénom.
// La liste de cours peut être initialisée à une liste vide.
