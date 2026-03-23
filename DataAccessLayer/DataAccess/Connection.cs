using Microsoft.Data.SqlClient;

namespace TD8__MVC___DAO_en_C__.DataAccessLayer.DataAccess
{
    // XML documentation tag for a brief explanation
    /// <summary>
    ///  Centralizes how we open SQL connections.
    ///  DAO classes will call Connection.GetOpenConnection().
    /// </summary>
    public static class Connection
    {
        // 1) Windows Authentication + SQL Express
        // Database name is TD8-Projet1
        private const string ConnString = "Server=localhost;Database=TD8-Projet1;Trusted_Connection=True;TrustServerCertificate=True;";

        /// <summary>
        /// Returns an OPEN SqlConnection
        /// </summary>
        public static SqlConnection GetOpenConnection() // GetOpenConnection returns an OPEN sql connection
        {
            var cnx = new SqlConnection(ConnString); // Creating a new SQL connection
            cnx.Open();
            return cnx;
        }              
    }
}
