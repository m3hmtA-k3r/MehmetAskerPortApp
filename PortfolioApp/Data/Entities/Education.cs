namespace PortfolioApp.Data.Entities
{
    public class Education
    {
        public int Id { get; set; }
        public string SchoolName { get; set; }
        public string Departman { get; set; }
        public double GPA { get; set; }
        public int StartYear { get; set; }
        public string? GradeationYear { get; set; }
        public string Description { get; set; }
    }
}
