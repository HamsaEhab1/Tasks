using ServiceStack.DataAnnotations;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace Hamsa_Ehab_0523058_w4.Models
{
    public class TeamMember
    {
        [Key] 
        public int TeamMemberID { get; set; }

        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(100)]
        [Unique]
        public string Email  { get; set; }
       
        [MaxLength(50)]
        public string Role { get; set; }

        public ICollection<task> Tasks { get; set; }
    }
}
