using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EProjectSEMIII.Models
{
    [Table("BillingInformation")]
    public class BillingInformation
    {
        public BillingInformation()
        {

        }

        public BillingInformation(int customerId, string customerName, string customerPhone, string policyNumber, string vehicleName, string vehicleModel, int vehicleRate, string vehicleBodyNumber, string vehicleEngineNumber, double amount, int customerPolicyId)
        {
            CustomerId = customerId;
            CustomerName = customerName;
            CustomerPhone = customerPhone;
            PolicyNumber = policyNumber;
            VehicleName = vehicleName;
            VehicleModel = vehicleModel;
            VehicleRate = vehicleRate;
            VehicleBodyNumber = vehicleBodyNumber;
            VehicleEngineNumber = vehicleEngineNumber;
            Amount = amount;
            CustomerPolicyId = customerPolicyId;
        }

        [ForeignKey("CustomerPolicy")]
        public int BillingInformationId { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerPhone { get; set; }
        public string CustomerAddProve { get; set; }
        public string PolicyNumber { get; set; }
        public string VehicleName { get; set; }
        public string VehicleModel { get; set; }
        public int VehicleRate { get; set; }
        public string VehicleBodyNumber { get; set; }
        public string VehicleEngineNumber { get; set; }
        public DateTime Date { get; set; }
        public double Amount { get; set; }
        public int Status { get; set; } = 0;

        public int? CustomerPolicyId { get; set; }
        public CustomerPolicy CustomerPolicy { get; set; }
    }
}
