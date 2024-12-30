using Hamsa_Ehab_0523058_w4.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hamsa_Ehab_0523058_w4.Controllers
{
    public class ProjectController : Controller
    {
        private readonly TaskManagementContext context;

        public ProjectController(TaskManagementContext context)
        {
            this.context = context;
        }
        public async Task<IActionResult> AllProjects()
        {
            var projects = await context.Projects.ToListAsync();
            return View(projects);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Project project)
        { 
          context.Projects.Add(project);    
            await context.SaveChangesAsync();
            return RedirectToAction("AllProjects");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var project = await context.Projects.FindAsync(id);
            return View(project);   
        }
        [HttpPost]

        public async Task<IActionResult> Edit(Project project)
        {
        
          var Old_project = await context.Projects.FirstOrDefaultAsync(x=>x.ProjectID==project.ProjectID);

            Old_project.Name = project.Name;
            Old_project.Description = project.Description;
            Old_project.StartDate=project.StartDate;
            Old_project.EndDate=project.EndDate;

            context.Projects.Update(Old_project);
            await context.SaveChangesAsync();
            return RedirectToAction("AllProjects");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var project = await context.Projects.FindAsync(id);
            return View(project);   
        }
        [HttpPost]
        public async Task<IActionResult> Delete(Project project)
        {
            context.Projects.Remove(project);
            await context.SaveChangesAsync();
            return RedirectToAction("AllProjects");
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var project = await context.Projects.Include(m => m.Tasks).ThenInclude(x=>x.TeamMember)
                .FirstOrDefaultAsync(x => x.ProjectID == id);

            return View(project);   
        }

    }
}
