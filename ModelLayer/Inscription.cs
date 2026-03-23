namespace TD8__MVC___DAO_en_C__.ModelLayer
{
    /// <summary>
    /// Enrollment of a student in a course for a session; Note is optional.
    /// </summary>
    public class Inscription
    {
        public Etudiant Etudiant { get; set; }
        public Cours Cours { get; set; }
        public string Session { get; set; }

        // <-- This must exist (nullable decimal), name exactly "Note"
        public decimal? Note { get; set; }

        public Inscription(Etudiant etudiant, Cours cours, string session, decimal? note = null)
        {
            Etudiant = etudiant;
            Cours = cours;
            Session = session;
            Note = note;
        }
    }
}
