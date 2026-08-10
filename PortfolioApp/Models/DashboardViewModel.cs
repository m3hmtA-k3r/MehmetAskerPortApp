using PortfolioApp.Data.Entities;

namespace PortfolioApp.Models
{
    public class DashboardViewModel
    {
        public int MessageCount { get; set; }
        public int UnreadMessageCount { get; set; }
        public int ExperienceCount { get; set; }
        public int ProjectCount { get; set; }
        public List<Project> RecentProjects { get; set; } = new List<Project>();
    }
}
