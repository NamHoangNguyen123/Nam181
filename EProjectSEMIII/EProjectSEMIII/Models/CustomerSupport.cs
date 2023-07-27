using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EProjectSEMIII.Models
{
    [Table("CustomerSupport")]
    public class CustomerSupport
    {
        [Key]
        public int CustomerSupportId { get; set; }

        [Required(ErrorMessage = "Please fill your question!")]
        public string Question { get; set; }

        [Required(ErrorMessage = "Please fill your answer!")]
        public string Answer { get; set; }
    }
}
