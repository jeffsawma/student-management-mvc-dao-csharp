using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.Pkcs;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using TD8__MVC___DAO_en_C__.DataAccessLayer.DAO.Interfaces;
using TD8__MVC___DAO_en_C__.DataAccessLayer.DataAccess;
using TD8__MVC___DAO_en_C__.ModelLayer;

namespace TD8__MVC___DAO_en_C__.DataAccessLayer.DAO.Implementations
{
    ///<summary>
    /// ADO.NET CRUD for Etudiant table
    /// DAO only talks to SQL 
    ///</summary>
    public class EtudiantDAO : IEtudiantDAO // We are extending IEtudiantDAO here
    {
        public Etudiant GetById(int id) // Using T GetById(int id) here
        {
            using var cnx = Connection.GetOpenConnection(); // Establishing a cnx

            // Using an SqlCommand
            using var cmd = new SqlCommand(
                "SELECT Id, Prenom, Nom FROM Etudiants WHERE Id=@id;", cnx); // Closing the sqlCommand

            cmd.Parameters.AddWithValue("@id", id); // Adding the value of id to @id

            using var rd = cmd.ExecuteReader(); // Build an sql command reader
            return rd.Read() // Returns 3 parameters for each student
                ? new Etudiant(rd.GetInt32(0), rd.GetString(1), rd.GetString(2)) // Columns start with the index 0 
                : null!; // The return shouldn't be null
        }

        public List<Etudiant> GetAll() // Using List<T> GetAll()
        {
            var list = new List<Etudiant>(); // Creating a new list of the students here
            using var cnx = Connection.GetOpenConnection();
            using var cmd = new SqlCommand(
                "SELECT Id, Prenom, Nom FROM Etudiants;", cnx);

            using var rd = cmd.ExecuteReader();
            while (rd.Read())
                list.Add(new Etudiant(rd.GetInt32(0), rd.GetString(1), rd.GetString(2)));
            return list;
        }

        public void Ajouter(Etudiant e)
        {
            using var cnx = Connection.GetOpenConnection();
            using var cmd = new SqlCommand(@"
                Insert INTO Etudiants (Prenom, Nom) VALUES (@p,@n);", cnx);
            cmd.Parameters.AddWithValue("@p", e.Prenom); // Using @p for the parameter Prenom
            cmd.Parameters.AddWithValue("@n", e.Nom); // Using @n for the parameter Nom
            cmd.ExecuteNonQuery(); // Execution happens here
        }

        public void Modifier(Etudiant e)
        {
            using var cnx = Connection.GetOpenConnection();
            using var cmd = new SqlCommand(@"
                UPDATE Etudiants SET Prenom=@p, Nom=@n WHERE Id=@id;", cnx); // Using SET for updating // Using all parameters of the student
            cmd.Parameters.AddWithValue("@p", e.Prenom);
            cmd.Parameters.AddWithValue("@n", e.Nom);
            cmd.Parameters.AddWithValue("@id", e.Id);
            cmd.ExecuteNonQuery();
        }

        public void Supprimer(int id)
        {
            using var cnx = Connection.GetOpenConnection();
            using var cmd = new SqlCommand(@"
                DELETE FROM Etudiants WHERE Id=@id;", cnx); // Using ONLY the primary key id in the table to delete a student
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
        }
    }
}

// Les classes DAO (EtudiantDAO, CoursDAO, InscriptionDAO) doivent :
// • Implémenter les interfaces correspondantes.
// • Utiliser SqlConnection, SqlCommand, et SqlDataReader de ADO.NET.
// • Utiliser des requêtes SQL paramétrées pour éviter l’injection SQL.
// • Ne jamais faire d’affichage (Console.WriteLine) dans ces classes.
// • Utiliser la classe Connection.cs pour obtenir un objet SqlConnection.
