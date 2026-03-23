using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD8__MVC___DAO_en_C__.DataAccessLayer.DAO.Interfaces
{
    /// <summary>
    /// Generic CRUD contract for an int-keyed entity
    /// Using the operations required in the project
    /// </summary>
    public interface IDAO<T>
    {
        T GetById(int id); // Calling one type id at a time
        List<T> GetAll(); // Calling all the list for a certain type
        void Ajouter(T entity); // Add a certain type entity to the list
        void Modifier(T entity); // Update in the list
        void Supprimer(int id); // Delete in the list
    }
}
// Chaque interface DAO doit définir les opérations suivantes pour le type T :
// T GetById(int id);
// List<T> GetAll();
// void Ajouter(T entity);
// void Modifier(T entity);
// void Supprimer(int id);

