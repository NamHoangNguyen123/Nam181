using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EProjectSEMIII.Models
{
    [Table("Estimate")]
    public class Estimate
    {
        [Key]
        public int EstimateId { get; set; }
        [Required(ErrorMessage = "Please fill customer's Name!")]
        public string CustomerName { get; set; }
        [Required(ErrorMessage = "Please fill customer's phone!")]
        public string CustomerPhone { get; set; }
        [DisplayFormat(DataFormatString = "{0:C0}")]

        [Required(ErrorMessage = "Please fill estimate number!")]
        public double EstimateNumber { get; set; }
        [Required(ErrorMessage = "Please fill Vehicle's name!")]
        public string VehicleName { get; set; }
        [Required(ErrorMessage = "Please fill vehicle's model!")]
        public string VehicleModel { get; set; }
        [Required(ErrorMessage = "Please fill vehicle's rate!")]
        public int VehicleRate { get; set; }
        [Required(ErrorMessage = "Please fill vehicle's warranty!")]
        public string VehicleWarranty { get; set; }
        [Required(ErrorMessage = "Please choose vehicle policy type!")]
        public string VehiclePolicyType { get; set; } // cac loai bao hiem duoc ho tro, list insurenceType


        public int Status { get; set; } = 0;

        public int VehicleInfomationId { get; set; }
        public VehicleInfomation VehicleInfomation { get; set; }

        public int InsuranceTypeId { get; set; }
        public InsuranceType InsuranceType { get; set; }
    }
}
