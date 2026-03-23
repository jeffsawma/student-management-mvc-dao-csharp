using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TD8__MVC___DAO_en_C__.DataAccessLayer.DAO.Interfaces;
using TD8__MVC___DAO_en_C__.ModelLayer;
using TD8__MVC___DAO_en_C__.ViewLayer;

namespace TD8__MVC___DAO_en_C__.ControlLayer
{
    /// <summary>
    /// Coordinates enrollment menu with InscriptionView and DAOs
    /// </summary>
    public class InscriptionControlleur
    {
        private readonly IInscriptionDAO _insDAO;
        private readonly IEtudiantDAO _etuDAO;
        private readonly ICoursDAO _coursDAO;
        private readonly InscriptionView _view;

        public InscriptionControlleur(IInscriptionDAO insDAO, IEtudiantDAO etuDAO, ICoursDAO coursDAO, InscriptionView view)
        {
            _insDAO = insDAO;
            _etuDAO = etuDAO;
            _coursDAO = coursDAO;
            _view = view;
        }

        public void GererMenu()
        {
            while (true)
            {
                switch (_view.AfficherMenuInscription())
                {
                    case 1:
                        // Ask for student id via its view (I/O kept in views)
                        var idE = new EtudiantView().DemanderIdEtudiant();
                        var listE = _insDAO.GetInscriptionsParEtudiant(idE)
                            .Select(i => (i.Cours.Code, i.Cours.Titre, i.Session, i.Note))
                            .ToList();
                        _view.AfficherListeParEtudiant(idE, listE);
                        break;

                    case 2:
                        // Ask for course id via its view (I/O kept in views)
                        var idC = new CoursView().DemanderIdCours();
                        var listC = _insDAO.GetInscriptionsParCours(idC)
                            .Select(i => (i.Etudiant.Prenom, i.Etudiant.Nom, i.Session, i.Note))
                            .ToList();
                        _view.AfficherListeParCours(idC, listC);
                        break;

                    case 3:
                        // Add a new inscription
                        var data = _view.SaisirInfosInscription();
                        var e = _etuDAO.GetById(data.etudiantId);
                        var c = _coursDAO.GetById(data.coursId);
                        if (e == null || c == null)
                        {
                            _view.AfficherMessage("Étudiant ou cours introuvable.");
                            break;
                        }
                        _insDAO.Ajouter(new Inscription(e, c, data.session, data.note));
                        _view.AfficherMessage("Inscription ajoutée.");
                        break;

                    case 4:
                        // Delete an inscription by composite key
                        var key = _view.DemanderCleInscription();
                        _insDAO.Supprimer(key.etudiantId, key.coursId, key.session);
                        _view.AfficherMessage("Inscription supprimée.");
                        break;

                    case 0:
                        return;

                    default:
                        _view.AfficherMessage("Choix invalide.");
                        break;
                }
            }
        }
    }
}
