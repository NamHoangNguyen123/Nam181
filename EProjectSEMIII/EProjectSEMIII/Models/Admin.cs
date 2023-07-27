using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EProjectSEMIII.Models
{
    [Table("Admin")]
    public class Admin
    {
        [Key]
        public int AdminId { get; set; }
        [Required(ErrorMessage = "AdminName not null")]
        public string AdminName { get; set; }
        [Required(ErrorMessage = "UserName not null")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Password not null")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Email not null")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Phone not null")]
        public string Phone { get; set; }
        public int Status { get; set; } = 0;
        
        public ICollection<ClaimDetail> ClaimDetails { get; set; }

    }
}
