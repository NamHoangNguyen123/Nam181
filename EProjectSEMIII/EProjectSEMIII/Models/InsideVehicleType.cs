using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EProjectSEMIII.Models
{
    [Table("InsideVehicleType")]
    //insurence type
    public class InsideVehicleType
    {
        [Key]
        [DisplayName("Inside Vehicle Type Id")]
        public int InsideVehicleTypeId { get; set; }
        [DisplayName("Name")]
        [Required(ErrorMessage = "Name not null")]
        public string Name { get;set; }
        [DisplayName("Status")]
        [Required(ErrorMessage = "Status not null")]
        public int Status { get; set; } = 0;

        public int VehicleTypeId { get; set; }
        public VehicleType VehicleType { get; set; }

        public ICollection<VehicleInfomation> VehicleInfomations { get; set; }

    }
}
