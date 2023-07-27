using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EProjectSEMIII.Models
{
    public class UpdatePassword
    {
        [Required(ErrorMessage = "Password not null")]
        public string Password { get; set; }
        [Required(ErrorMessage = "NewPassword not null")]
        public string NewPassword { get; set; }
        [Required(ErrorMessage = "ReEnterNewPassword not null")]
        public string ReEnterNewPassword { get; set; }
    }
}
