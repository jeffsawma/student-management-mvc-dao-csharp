using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using TD8__MVC___DAO_en_C__.DataAccessLayer.DAO.Interfaces;
using TD8__MVC___DAO_en_C__.DataAccessLayer.DataAccess;
using TD8__MVC___DAO_en_C__.ModelLayer;

namespace TD8__MVC___DAO_en_C__.DataAccessLayer.DAO.Implementations
{
    public class InscriptionDAO : IInscriptionDAO
    {
        // CREATE
        public void Ajouter(Inscription ins)
        {
            using var cnx = Connection.GetOpenConnection();
            using var cmd = new SqlCommand(
                "INSERT INTO Inscriptions (EtudiantId, CoursId, Session, Note) VALUES (@e,@c,@s,@n);", cnx);
            cmd.Parameters.AddWithValue("@e", ins.Etudiant.Id);
            cmd.Parameters.AddWithValue("@c", ins.Cours.Id);
            cmd.Parameters.AddWithValue("@s", ins.Session);
            // pass DBNull.Value when Note is null
            cmd.Parameters.AddWithValue("@n", (object?)ins.Note ?? DBNull.Value);
            cmd.ExecuteNonQuery();
        }

        // UPDATE (typically the Note)
        public void Modifier(Inscription ins)
        {
            using var cnx = Connection.GetOpenConnection();
            using var cmd = new SqlCommand(
                "UPDATE Inscriptions SET Note=@n WHERE EtudiantId=@e AND CoursId=@c AND Session=@s;", cnx);
            cmd.Parameters.AddWithValue("@n", (object?)ins.Note ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@e", ins.Etudiant.Id);
            cmd.Parameters.AddWithValue("@c", ins.Cours.Id);
            cmd.Parameters.AddWithValue("@s", ins.Session);
            cmd.ExecuteNonQuery();
        }

        // DELETE by composite key
        public void Supprimer(int etudiantId, int coursId, string session)
        {
            using var cnx = Connection.GetOpenConnection();
            using var cmd = new SqlCommand(
                "DELETE FROM Inscriptions WHERE EtudiantId=@e AND CoursId=@c AND Session=@s;", cnx);
            cmd.Parameters.AddWithValue("@e", etudiantId);
            cmd.Parameters.AddWithValue("@c", coursId);
            cmd.Parameters.AddWithValue("@s", session);
            cmd.ExecuteNonQuery();
        }

        // QUERY: by student
        public List<Inscription> GetInscriptionsParEtudiant(int etudiantId)
        {
            var list = new List<Inscription>();
            using var cnx = Connection.GetOpenConnection();
            using var cmd = new SqlCommand(
                "SELECT i.CoursId, i.Session, i.Note, c.Code, c.Titre FROM Inscriptions i JOIN Cours c ON c.Id = i.CoursId WHERE i.EtudiantId = @e;",
                cnx);
            cmd.Parameters.AddWithValue("@e", etudiantId);

            using var rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                var etu = new Etudiant(etudiantId, "", "");
                var crs = new Cours(rd.GetInt32(0), rd.GetString(3), rd.GetString(4));
                var sess = rd.GetString(1);
                decimal? note = rd.IsDBNull(2) ? null : rd.GetDecimal(2);
                list.Add(new Inscription(etu, crs, sess, note));
            }
            return list;
        }

        // QUERY: by course
        public List<Inscription> GetInscriptionsParCours(int coursId)
        {
            var list = new List<Inscription>();
            using var cnx = Connection.GetOpenConnection();
            using var cmd = new SqlCommand(
                "SELECT i.EtudiantId, i.Session, i.Note, e.Prenom, e.Nom FROM Inscriptions i JOIN Etudiants e ON e.Id = i.EtudiantId WHERE i.CoursId = @c;",
                cnx);
            cmd.Parameters.AddWithValue("@c", coursId);

            using var rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                var etu = new Etudiant(rd.GetInt32(0), rd.GetString(3), rd.GetString(4));
                var crs = new Cours(coursId, "", "");
                var sess = rd.GetString(1);
                decimal? note = rd.IsDBNull(2) ? null : rd.GetDecimal(2);
                list.Add(new Inscription(etu, crs, sess, note));
            }
            return list;
        }
    }
}
