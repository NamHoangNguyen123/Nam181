using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EProjectSEMIII.Models
{
    [Table("Contact")]

    public class Contact
    {
        [Key]
        public int ContactId { get; set; }
        [Required(ErrorMessage = "CusName not null")]
        public string CusName { get; set; }
        [Required(ErrorMessage = "CusMail not null")]
        public string CusMail { get; set; }
        [Required(ErrorMessage = "Subject not null")]
        public string Subject { get; set; }
        [Required(ErrorMessage = "ContactNumber not null")]
        public string ContactNumber { get; set; }
        [Required(ErrorMessage = "Message not null")]
        public string Message { get; set; }
    }
}
