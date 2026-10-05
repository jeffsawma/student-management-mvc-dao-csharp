using System.Linq;
using TD8__MVC___DAO_en_C__.DataAccessLayer.DAO.Interfaces;
using TD8__MVC___DAO_en_C__.ModelLayer;
using TD8__MVC___DAO_en_C__.ViewLayer;

namespace TD8__MVC___DAO_en_C__.ControlLayer
{
    /// <summary>
    /// Coordinates course menu actions with CoursView and ICoursDAO
    /// </summary>
    public class CoursController
    {
        private readonly ICoursDAO _dao;
        private readonly CoursView _view;

        public CoursController(ICoursDAO dao, CoursView view)
        {
            _dao = dao;
            _view = view;
        }

        public void GererMenu()
        {
            while (true)
            {
                switch (_view.AfficherMenuCours())
                {
                    case 1:
                        _view.AfficherListe(
                            _dao.GetAll().Select(c => (c.Id, c.Code, c.Titre)).ToList());
                        break;

                    case 2:
                        var add = _view.SaisirInfosCours();
                        _dao.Ajouter(new Cours(0, add.code, add.titre));
                        _view.AfficherMessage("Ajout effectué.");
                        break;

                    case 3:
                        var idm = _view.DemanderIdCours();
                        var c = _dao.GetById(idm);
                        if (c == null) { _view.AfficherMessage("Introuvable."); break; }
                        var mod = _view.SaisirInfosCours();
                        c.Code = mod.code; c.Titre = mod.titre;
                        _dao.Modifier(c);
                        _view.AfficherMessage("Modification effectuée.");
                        break;

                    case 4:
                        var ids = _view.DemanderIdCours();
                        _dao.Supprimer(ids);
                        _view.AfficherMessage("Suppression effectuée.");
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
