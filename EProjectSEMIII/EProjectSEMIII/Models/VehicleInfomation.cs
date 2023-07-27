using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EProjectSEMIII.Models
{
    [Table("VehicleInfomation")]
    public class VehicleInfomation
    {
        [Key]
        [DisplayName("VehicleInfomationId")]
        public int VehicleInfomationId { get; set; }
        [DisplayName("VehicleName")]
        [Required(ErrorMessage = "VehicleName not null")]
        public string VehicleName { get; set; }
        [DisplayName("OwnerOfVehicle")]
        [Required(ErrorMessage = "OwnerOfVehicle not null")]
        public string OwnerOfVehicle { get; set; }
        [DisplayName("VehicleModel")]
        [Required(ErrorMessage = "VehicleModel not null")]
        public string VehicleModel { get; set; }
        [DisplayName("VehicleVersion")]
        [Required(ErrorMessage = "VehicleVersion not null")]
        public string VehicleVersion { get; set; }
        [DisplayName("VehicleRate")]
        [Required(ErrorMessage = "VehicleRate not null")]
        public int VehicleRate { get; set; }
        [DisplayName("VehicleBodyNumber")]
        [Required(ErrorMessage = "VehicleBodyNumber not null")]
        public string VehicleBodyNumber { get; set; }
        [DisplayName("VehicleEngine")]
        [Required(ErrorMessage = "VehicleEngine not null")]
        public string VehicleEngine { get; set; }
        [DisplayName("VehicleNumber")]
        [Required(ErrorMessage = "VehicleNumber not null")]
        public string VehicleNumber { get; set; }
        [DisplayName("Status")]
        public int Status { get; set; } = 0;

        public int CustomerRecordId { get; set; }
        public CustomerRecord CustomerRecord { get; set; }

        public ICollection<Estimate> Estimates { get; set; }

        public int InsideVehicleTypeId { get; set; }
        public InsideVehicleType InsideVehicleType { get; set; }

    }
}
