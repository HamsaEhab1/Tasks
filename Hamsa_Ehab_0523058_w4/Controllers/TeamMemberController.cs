using Hamsa_Ehab_0523058_w4.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hamsa_Ehab_0523058_w4.Controllers
{
    public class TeamMemberController : Controller
    {

        private readonly TaskManagementContext context;

        public TeamMemberController(TaskManagementContext context)
        {
            this.context = context;
        }
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var member = await context.TeamMembers.Include(t=>t.Tasks).ThenInclude(x=>x.Project)
             .FirstOrDefaultAsync(x => x.TeamMemberID == id);

            return View(member);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var member = await context.TeamMembers.Include(x=>x.Tasks).FirstOrDefaultAsync(x => x.TeamMemberID == id);
            return View(member);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(TeamMember member)
        {
            context.TeamMembers.Remove(member);
            await context.SaveChangesAsync();
            return RedirectToAction("AllProjects", "Project");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var member = await context.TeamMembers.Include(x => x.Tasks).FirstOrDefaultAsync(x => x.TeamMemberID == id);
            return View(member);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(TeamMember member)
        {

            var Old_Member = await context.TeamMembers.Include(x => x.Tasks).
              FirstOrDefaultAsync(x => x.TeamMemberID == member.TeamMemberID);

            Old_Member.Name= member.Name;   
            Old_Member.Role=member.Role;
            Old_Member.Email=member.Email;
           
            context.TeamMembers.Update(Old_Member);
            await context.SaveChangesAsync();
            return RedirectToAction("AllProjects", "Project");
        }


    }
}
