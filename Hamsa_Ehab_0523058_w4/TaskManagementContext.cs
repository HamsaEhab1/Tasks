using Hamsa_Ehab_0523058_w4.Models;
using Microsoft.EntityFrameworkCore;

namespace Hamsa_Ehab_0523058_w4
{
    public class TaskManagementContext : DbContext
    {
        public TaskManagementContext(DbContextOptions<TaskManagementContext> options) : base(options)
        {
        }
        public DbSet<task> tasks { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<TeamMember> TeamMembers { get; set; }

        
    }
}
