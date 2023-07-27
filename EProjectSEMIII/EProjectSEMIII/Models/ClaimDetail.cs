using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EProjectSEMIII.Models
{
    [Table("ClaimDetail")]
    public class ClaimDetail
    {
        [Key]
        public int ClaimDetailId { get; set; }
        [Required(ErrorMessage = "PolicyNumber not null")]
        public string PolicyNumber { get; set; }
        [Required(ErrorMessage = "PolicyStartDate not null")]
        public DateTime PolicyStartDate { get; set; }
        [Required(ErrorMessage = "PolicyEndDate not null")]
        public DateTime PolicyEndDate { get; set; }
        [Required(ErrorMessage = "CustomerName not null")]
        public string CustomerName { get; set; }
        [Required(ErrorMessage = "PlaceOfAccident not null")]
        public string PlaceOfAccident { get; set; }
        [Required(ErrorMessage = "DateOfAccident not null")]
        public DateTime DateOfAccident { get; set; }
        [Required(ErrorMessage = "InsuredAmout not null")]
        public double? InsuredAmout { get; set; }
        [Required(ErrorMessage = "ClaimableAmout not null")]
        public double? ClaimableAmout { get; set; }
        public int Status { get; set; } = 0;
        [Required(ErrorMessage = "CustomerPolicyId not null")]
        public int CustomerPolicyId { get; set; }
        public CustomerPolicy CustomerPolicy { get; set; }
        public int? AdminId { get; set; }
        public Admin Admin { get; set; }
    }
}
