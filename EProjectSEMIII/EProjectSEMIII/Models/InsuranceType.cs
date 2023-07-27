using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EProjectSEMIII.Models
{
    [Table("InsuranceType")]
    public class InsuranceType
    {
        [Key]
        [DisplayName("InsurenceTypeId")]
        public int InsurenceTypeId { get; set; }
        [DisplayName("Type Of Insurence")]
        [Required(ErrorMessage = "Type of insurence not null")]
        public string TypeOfInsurence { get; set; } // loaji bao hiem: than xe, dau xe,...
        [DisplayName("Price")]
        [Required(ErrorMessage = "Price not null")]
        [DisplayFormat(DataFormatString = "{0:C0}")]
        public double Price { get; set; }
        [DisplayName("Status")]
        [Required(ErrorMessage = "Status not null")]
        public int Status { get; set; } = 0;

        public ICollection<Estimate> Estimates { get; set; }
        public ICollection<CustomerPolicy> CustomerPolicies { get; set; }
    }
}
