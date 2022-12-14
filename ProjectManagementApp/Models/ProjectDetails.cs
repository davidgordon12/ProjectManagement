using ProjectManagement.Entities;

namespace ProjectManagementApp.Models
{
    public class ProjectDetails
    {
        public Project? Project { get; set; }
        public List<ProjectTask>? Ongoing { get; set; } = Enumerable.Empty<ProjectTask>().ToList();
        public List<ProjectTask>? Completed { get; set; } = Enumerable.Empty<ProjectTask>().ToList();
        public List<ProjectTask>? Cancelled { get; set; } = Enumerable.Empty<ProjectTask>().ToList();

        public Employee? Employee { get; set; }
        public ProjectTask? Task { get; set; }
    }
}
