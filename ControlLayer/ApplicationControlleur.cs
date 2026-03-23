using TD8__MVC___DAO_en_C__.ViewLayer;

namespace TD8__MVC___DAO_en_C__.ControlLayer
{
    // Controller shell that routes to sub-controllers. No Console/DB here.
    public class ApplicationControlleur
    {
        private readonly PrincipalView _principal;
        private readonly EtudiantControlleur _etuCtrl;
        private readonly CoursController _coursCtrl;
        private readonly InscriptionControlleur _insCtrl;

        public ApplicationControlleur(
            PrincipalView principal,
            EtudiantControlleur etuCtrl,
            CoursController coursCtrl,
            InscriptionControlleur insCtrl)
        {
            _principal = principal;
            _etuCtrl = etuCtrl;
            _coursCtrl = coursCtrl;
            _insCtrl = insCtrl;
        }

        public void Run()
        {
            while (true)
            {
                switch (_principal.AfficherMenuPrincipal())
                {
                    case 1: _etuCtrl.GererMenu(); break;
                    case 2: _coursCtrl.GererMenu(); break;
                    case 3: _insCtrl.GererMenu(); break;
                    case 0: _principal.AfficherMessage("Au revoir!"); return;
                    default: _principal.AfficherMessage("Choix invalide."); break;
                }
            }
        }
    }
}
