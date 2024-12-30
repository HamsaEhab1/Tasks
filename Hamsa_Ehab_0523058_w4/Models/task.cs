
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hamsa_Ehab_0523058_w4.Models
{
    public class task
    {

        [Key]
        public int TaskID { get; set; }

        [MaxLength(100)]
        public string Title { get; set; }

        [MaxLength(500)]    
        public string Description { get; set; }

        public string Status { get; set; }  
        public string Priority { get; set; }    
        public DateTime Deadline { get; set; }  
        public int ProjectID { get; set; }
        [ForeignKey("ProjectID")]
        public Project Project { get; set; }

        public int TeamMemberID { get; set; }
        [ForeignKey("TeamMemberID")]

        public TeamMember TeamMember { get; set; }

    }
}
