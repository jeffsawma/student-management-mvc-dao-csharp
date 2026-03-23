using System.Collections.Generic;
using TD8__MVC___DAO_en_C__.ModelLayer;

namespace TD8__MVC___DAO_en_C__.DataAccessLayer.DAO.Interfaces
{
    // Contract for CRUD + queries on Inscription (composite key)
    public interface IInscriptionDAO
    {
        void Ajouter(Inscription inscription);
        void Modifier(Inscription inscription);
        void Supprimer(int etudiantId, int coursId, string session);

        List<Inscription> GetInscriptionsParEtudiant(int etudiantId);
        List<Inscription> GetInscriptionsParCours(int coursId);
    }
}
