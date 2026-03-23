using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TD8__MVC___DAO_en_C__.ModelLayer;

namespace TD8__MVC___DAO_en_C__.DataAccessLayer.DAO.Interfaces
{
    public interface IEtudiantDAO : IDAO<Etudiant> { }
    /// <summary>
    /// DAO contract for Etudiant with basic CRUD (create, read, update and delete)
    /// </summary>
}
