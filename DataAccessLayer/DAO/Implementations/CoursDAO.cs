using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Pkcs;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using TD8__MVC___DAO_en_C__.DataAccessLayer.DAO.Interfaces;
using TD8__MVC___DAO_en_C__.DataAccessLayer.DataAccess;
using TD8__MVC___DAO_en_C__.ModelLayer;

namespace TD8__MVC___DAO_en_C__.DataAccessLayer.DAO.Implementations
{
    /// <summary>
    /// ADO.NET CRUD for Cours table
    /// </summary>
    public class CoursDAO : ICoursDAO
    {
        public Cours GetById(int id)
        {
            using var cnx = Connection.GetOpenConnection();
            using var cmd = new SqlCommand(@"
                SELECT Id, Code, Titre FROM Cours WHERE Id=@id;", cnx);
            cmd.Parameters.AddWithValue("@id", id);

            using var rd = cmd.ExecuteReader();
            return rd.Read()
                ? new Cours(rd.GetInt32(0), rd.GetString(1), rd.GetString(2))
                : null!;
        }

        public List<Cours> GetAll()
        {
            var list = new List<Cours>();
            using var cnx = Connection.GetOpenConnection();
            using var cmd = new SqlCommand(
                "SELECT Id, Code, Titre FROM Cours;", cnx);

            using var rd = cmd.ExecuteReader();
            while (rd.Read())
                list.Add(new Cours(rd.GetInt32(0), rd.GetString(1), rd.GetString(2)));

            return list;
        }

        public void Ajouter(Cours c)
        {
            using var cnx = Connection.GetOpenConnection();
            using var cmd = new SqlCommand(@"
                INSERT INTO Cours (Code, Titre) VALUES (@c,@t);", cnx);
            cmd.Parameters.AddWithValue("@c", c.Code);
            cmd.Parameters.AddWithValue("@t", c.Titre);
            cmd.ExecuteNonQuery();
        }

        public void Modifier(Cours c)
        {
            using var cnx = Connection.GetOpenConnection();
            using var cmd = new SqlCommand(@"
                UPDATE Cours SET Code=@c, Titre=@t WHERE Id=@id;", cnx);
            cmd.Parameters.AddWithValue("@c", c.Code);
            cmd.Parameters.AddWithValue("@t", c.Titre);
            cmd.Parameters.AddWithValue("@id", c.Id);
            cmd.ExecuteNonQuery();
        }

        public void Supprimer(int id)
        {
            using var cnx = Connection.GetOpenConnection();
            using var cmd = new SqlCommand(@"
                DELETE FROM Cours WHERE Id=@id;", cnx);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
        }
    }
}
