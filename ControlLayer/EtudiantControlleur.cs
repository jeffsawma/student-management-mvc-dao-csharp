using System.Linq;
using TD8__MVC___DAO_en_C__.DataAccessLayer.DAO.Interfaces;
using TD8__MVC___DAO_en_C__.ModelLayer;
using TD8__MVC___DAO_en_C__.ViewLayer;

namespace TD8__MVC___DAO_en_C__.ControlLayer
{
    /// <summary>
    /// Student submenu coordination (uses view for I/O, DAO for data).
    /// </summary>
    public class EtudiantControlleur
    {
        private readonly IEtudiantDAO _dao;
        private readonly EtudiantView _view;

        public EtudiantControlleur(IEtudiantDAO dao, EtudiantView view)
        {
            _dao = dao;
            _view = view;
        }

        public void GererMenu()
        {
            while (true)
            {
                switch (_view.AfficherMenuEtudiant())
                {
                    case 1:
                        _view.AfficherListe(
                            _dao.GetAll().Select(e => (e.Id, e.Prenom, e.Nom)).ToList());
                        break;

                    case 2:
                        var add = _view.SaisirInfosEtudiant();
                        _dao.Ajouter(new Etudiant(0, add.prenom, add.nom)); // Id auto by DB
                        _view.AfficherMessage("Ajout effectué.");
                        break;

                    case 3:
                        var idm = _view.DemanderIdEtudiant();
                        var e = _dao.GetById(idm);
                        if (e == null) { _view.AfficherMessage("Introuvable."); break; }
                        var mod = _view.SaisirInfosEtudiant();
                        e.Prenom = mod.prenom; e.Nom = mod.nom;
                        _dao.Modifier(e);
                        _view.AfficherMessage("Modification effectuée.");
                        break;

                    case 4:
                        var ids = _view.DemanderIdEtudiant();
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
