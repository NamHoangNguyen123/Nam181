using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EProjectSEMIII.Models
{
    [Table("CompanyExpense")]
    public class CompanyExpense
    {
        [Key]
        public int CompanyExpenseId { get; set; }
        public DateTime DateOfExpense { get; set; }
        public string TypeOfExpense { get; set; }
        public double AmoutOfExpense { get; set; }
        public int Status { get; set; } = 0;
    }
}
