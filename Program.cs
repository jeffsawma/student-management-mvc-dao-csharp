using TD8__MVC___DAO_en_C__.ControlLayer;
using TD8__MVC___DAO_en_C__.DataAccessLayer.DAO.Implementations;
using TD8__MVC___DAO_en_C__.DataAccessLayer.DAO.Interfaces;
using TD8__MVC___DAO_en_C__.ViewLayer;

namespace TD8__MVC___DAO_en_C__
{
    internal class Program
    {
        static void Main()
        {
            try
            {
                // DAOs
                IEtudiantDAO etuDao = new EtudiantDAO();
                ICoursDAO coursDao = new CoursDAO();
                IInscriptionDAO insDao = new InscriptionDAO();

                // Views
                var principalView = new PrincipalView();
                var etudiantView = new EtudiantView();
                var coursView = new CoursView();
                var inscriptionView = new InscriptionView();

                // Controllers
                var etuCtrl = new EtudiantControlleur(etuDao, etudiantView);
                var coursCtrl = new CoursController(coursDao, coursView);
                var insCtrl = new InscriptionControlleur(insDao, etuDao, coursDao, inscriptionView);

                // Run app
                new ApplicationControlleur(principalView, etuCtrl, coursCtrl, insCtrl).Run();
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR:");
                Console.WriteLine(ex.ToString());
            }

            Console.WriteLine("\nPress ENTER to exit...");
            Console.ReadLine();
        }
    }
}
