using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EProjectSEMIII.Models
{
    [Table("CustomerPolicy")]
    public class CustomerPolicy
    {
        [Key]
        public int CustomerPolicyId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerPhone { get; set; }
        public string CustomerAdd { get; set; }
        //Admin chấp nhận
        public string CustomerAddProve { get; set; }


        public string PolicyNumber { get; set; }
        public DateTime PolicyDate { get; set; }
        public int PolicyDuration { get; set; }

        public double EstimateNumber { get; set; }

        public string VehicleName { get; set; }
        public string VehicleModel { get; set; }
        public string VehicleVersion { get; set; }
        public int VehicleRate { get; set; }
        public string VehicleBodyNumber { get; set; }
        public string VehicleNumber { get; set; }
        public string VehicleEngineNumber { get; set; }
        public int Status { get; set; } = 0;


        public int CustomerRecordId { get; set; }
        public CustomerRecord CustomerRecord { get; set; }

        public int InsuranceTypeId { get; set; }
        public InsuranceType InsuranceType { get; set; }

        public int? BillingInformationId { get; set; }
        public BillingInformation BillingInformation { get; set; }

        public ICollection<ClaimDetail> ClaimDetails { get; set; }

    }
}
