using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ProjectManagement.Entities;
using ProjectManagementApp.DataAccess;
using ProjectManagementApp.Entities;
using ProjectManagementApp.Models;
using System.IO;
using System.Threading.Tasks;

namespace ProjectManagementApp.Controllers
{
    public class ProjectController : Controller
    {
        UserManager<User> _userManager;
        SignInManager<User> _signInManager;
        public ProjectController(ProjectManagementDbContext projectManagementDbContext, 
            UserManager<User> userMngr,
            SignInManager<User> signInMngr)
        {
            _projectManagementDbContext = projectManagementDbContext;
            _userManager = userMngr;
            _signInManager = signInMngr;
        }

        [HttpGet("/projects")]
        public IActionResult GetAllProjects()
        {
            var projects = _projectManagementDbContext.Projects
                    .Include(p => p.Employees)
                    .Include(p => p.Tasks)
                    .OrderByDescending(p => p.DateCreated)
                    .ToList();

            return View("Items", projects);
        }

        [HttpGet("/projects/{id}")]
        public IActionResult GetProjectById(int id)
        {
            var project = _projectManagementDbContext.Projects
                    .Include(p => p.Employees)
                    .Include(p => p.Tasks)
                    .Where(p => p.ProjectId == id)
                    .FirstOrDefault();

            ProjectDetails projectDetails = new ProjectDetails
            {
                Project = project,
                Ongoing = project.Tasks.Where(t => t.TaskStatus == TaskStatusOptions.InProgress).ToList(),
                Completed = project.Tasks.Where(t => t.TaskStatus == TaskStatusOptions.Completed).ToList(),
                Cancelled = project.Tasks.Where(t => t.TaskStatus == TaskStatusOptions.Cancelled).ToList()
            };

            if (project == null)
                return NotFound();

            // TODO: complete this action method

            return View("Details", projectDetails);
        }

        [HttpGet("/projects/add-request")]
        public IActionResult GetAddProjectRequest()
        {
            if (!_signInManager.IsSignedIn(User))
                return RedirectToAction("Login", "Account");

            return View("AddProject", new Project());
        }

        [HttpPost("/projects")]
        public IActionResult AddNewProject(Project project)
        {
            if (ModelState.IsValid)
            {
                _projectManagementDbContext.Projects.Add(project);
                _projectManagementDbContext.SaveChanges();

                TempData["LastActionMessage"] = $"The project \"{project.Name}\" was added.";

                return RedirectToAction("GetAllProjects", "Project");
            }
            else
            {
                return View("AddProject", project);
            }
        }

        [HttpGet("/projects/{id}/edit-request")]
        public IActionResult GetEditRequestById(int id)
        {
            if (!_signInManager.IsSignedIn(User))
                return RedirectToAction("Login", "Account");

            var project = _projectManagementDbContext.Projects.Find(id);
            return View("EditProject", project);
        }

        [HttpPost("/projects/edit-requests")]
        public IActionResult ProcessEditRequest(Project project)
        {
            if (ModelState.IsValid)
            {
                _projectManagementDbContext.Projects.Update(project);
                _projectManagementDbContext.SaveChanges();

                TempData["LastActionMessage"] = $"The project \"{project.Name}\" was updated.";

                return RedirectToAction("GetAllProjects", "Project");
            }
            else
            {
                return View("EditProject", project);
            }
        }

        [HttpGet("/projects/{id}/delete-request")]
        public IActionResult GetDeleteRequestById(int id)
        {
            // check to see if the user is Admin
            if (!User.IsInRole("Admin"))
                return RedirectToAction("AccessDenied", "Account");

            var project = _projectManagementDbContext.Projects.Find(id);
            return View("DeleteConfirmation", project);
        }

        [HttpPost("/projects/{id}/delete-requests")]
        public IActionResult ProcessDeleteRequestById(int id)
        {
            var project = _projectManagementDbContext.Projects.Find(id);

            // delete all the projects children first
            _projectManagementDbContext.Employees.RemoveRange(_projectManagementDbContext.Employees.Where(e=>e.ProjectId==id));
            _projectManagementDbContext.ProjectTasks.RemoveRange(_projectManagementDbContext.ProjectTasks.Where(t=>t.ProjectId==id));
            _projectManagementDbContext.Projects.Remove(project);

            _projectManagementDbContext.SaveChanges();

            TempData["LastActionMessage"] = $"The project \"{project.Name}\" was deleted.";

            return RedirectToAction("GetAllProjects", "Project");
        }

        public IActionResult CreateEmployee(Employee employee)
        {
            _projectManagementDbContext.Employees.Add(employee);
            _projectManagementDbContext.SaveChanges();

            // for some reason I couldn't redirect to the Details action
            var project = _projectManagementDbContext.Projects
                    .Include(p => p.Employees)
                    .Include(p => p.Tasks)
                    .Where(p => p.ProjectId == employee.ProjectId)
                    .FirstOrDefault();

            ProjectDetails projectDetails = new ProjectDetails
            {
                Project = project,
                Ongoing = project.Tasks.Where(t => t.TaskStatus == TaskStatusOptions.InProgress).ToList(),
                Completed = project.Tasks.Where(t => t.TaskStatus == TaskStatusOptions.Completed).ToList(),
                Cancelled = project.Tasks.Where(t => t.TaskStatus == TaskStatusOptions.Cancelled).ToList()
            };

            if (project == null)
                return NotFound();

            // TODO: complete this action method
            TempData["LastActionMessage"] = $"The employee \"{employee.FullName}\" was added.";

            return View("Details", projectDetails);
        }

        public IActionResult CreateTask(ProjectTask task)
        {
            _projectManagementDbContext.ProjectTasks.Add(task);
            _projectManagementDbContext.SaveChanges();


            // for some reason I couldn't redirect to the Details action
            var project = _projectManagementDbContext.Projects
                    .Include(p => p.Employees)
                    .Include(p => p.Tasks)
                    .Where(p => p.ProjectId == task.ProjectId)
                    .FirstOrDefault();

            ProjectDetails projectDetails = new ProjectDetails
            {
                Project = project,
                Ongoing = project.Tasks.Where(t => t.TaskStatus == TaskStatusOptions.InProgress).ToList(),
                Completed = project.Tasks.Where(t => t.TaskStatus == TaskStatusOptions.Completed).ToList(),
                Cancelled = project.Tasks.Where(t => t.TaskStatus == TaskStatusOptions.Cancelled).ToList()
            };

            if (project == null)
                return NotFound();

            // TODO: complete this action method

            TempData["LastActionMessage"] = $"A new task was created";
            return View("Details", projectDetails);
        }

        private ProjectManagementDbContext _projectManagementDbContext;
    }
}
