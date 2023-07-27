using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EProjectSEMIII.Models
{
    [Table("CustomerRecord")]
    public class CustomerRecord
    {
        [Key]
        public int CustomerRecordId { get; set; }
        [Required(ErrorMessage = "CustomerName not null")]
        public string CustomerName { get; set; }
        [Required(ErrorMessage = "CustomerAdd not null")]
        public string CustomerAdd { get; set; }
        [Required(ErrorMessage = "CustomerPhone not null")]
        public string CustomerPhone { get; set; }
        [Required(ErrorMessage = "UserName not null")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Password not null")]
        public string Password { get; set; }
        public int Status { get; set; } = 0;
        public ICollection<CustomerPolicy> CustomerPolicies { get; set; }
        public ICollection<VehicleInfomation> VehicleInfomations { get; set; }
    }
}
