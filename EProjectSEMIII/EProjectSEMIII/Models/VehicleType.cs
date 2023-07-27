using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EProjectSEMIII.Models
{
    [Table("VehicleType")]
    public class VehicleType
    {
        [Key]
        [DisplayName("VehicleTypeId")]
        public int VehicleTypeId { get; set; }
        [DisplayName("NameOfVehicleType")]
        [Required(ErrorMessage = "Name not null")]
        public string NameOfVehicleType { get; set; }
        [DisplayName("Status")]
        [Required(ErrorMessage = "Status not null")]
        public int Status { get; set; } = 0;

        public ICollection<InsideVehicleType> InsideVehicleTypes { get; set; }
    }
}
