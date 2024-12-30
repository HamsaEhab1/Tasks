using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hamsa_Ehab_0523058_w4.Controllers
{
    public class TasksController : Controller
    {
        private readonly TaskManagementContext context;

        public TasksController(TaskManagementContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var task = await context.tasks.FindAsync(id);
            if (task == null) 
            { 
             return NotFound("Not Found"); 
            }
            var projects = await context.Projects.ToListAsync();
            var member = await context.TeamMembers.ToListAsync();
            TaskViewModel model = new TaskViewModel()
            {
                TaskID = id,    
              Title=task.Title,
              Description=task.Description, 
              Status=task.Status,
              Priority=task.Priority,
              Deadline=task.Deadline,
              Projects=projects,    
              TeamMembers=member    
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(TaskViewModel view)
        {

            var Old_task = await context.tasks.FindAsync(view.TaskID);
            if (Old_task == null) 
            {
                return NotFound("Not found");
            }
            Old_task.Title= view.Title;
            Old_task.Description= view.Description; 
            Old_task.Status= view.Status;   
            Old_task.Priority= view.Priority;   
            Old_task.Deadline= view.Deadline;
            Old_task.ProjectID= view.ProjectID;
            Old_task.TeamMemberID=view.TeamMemberID;
            context.tasks.Update(Old_task);
            await context.SaveChangesAsync();
            return RedirectToAction("AllProjects","Project");
        }
    }
}
