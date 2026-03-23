using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD8__MVC___DAO_en_C__.ModelLayer
{
    /// <summary>
    /// Cours (Id identity, Code, Titre)
    /// </summary>
    public class Cours
    {
        // Private fields (encapsulation)
        private int _id;
        private string _code;
        private string _titre;

        // Public properties (getters/setters)
        public int Id { get => _id; set => _id = value; }
        public string Code { get => _code; set => _code = value; }
        public string Titre { get => _titre; set => _titre = value; }

        // Navigation collection for business logic
        public List<Etudiant> Etudiants { get; set; } = new();

        // Constructor for initialisation
        public Cours(int id, string code, string titre)
        {
            _id = id;
            _code = code;
            _titre = titre;
        }

        // ToString() for visual output
        public override string ToString() => $"{Id} - {Code} - {Titre}";
    }
}
