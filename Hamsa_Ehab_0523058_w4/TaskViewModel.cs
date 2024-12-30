using Hamsa_Ehab_0523058_w4.Models;
using System.ComponentModel.DataAnnotations;

namespace Hamsa_Ehab_0523058_w4
{
    public class TaskViewModel
    {
        public int TaskID { get; set; }
        [MaxLength(100)]
        public string Title { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }
        public string Status { get; set; }
        public string Priority { get; set; }
        public DateTime Deadline { get; set; }
        public int ProjectID { get; set; }
       
        public ICollection<Project> Projects { get; set; }  
        public int TeamMemberID { get; set; }

        public ICollection<TeamMember> TeamMembers { get; set; }    
       
    }
}
