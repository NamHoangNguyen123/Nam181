using System.ComponentModel.DataAnnotations;

namespace EProjectSEMIII.Models
{
    public class Register
    {
        [Required(ErrorMessage = "UserName not null")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Password not null")]
        public string Password { get; set; }
        [Required(ErrorMessage = "RePassword not null")]
        public string RePassword { get; set; }
        [Required(ErrorMessage = "CustomerName not null")]
        public string CustomerName { get; set; }
        [Required(ErrorMessage = "CustomerAdd not null")]
        public string CustomerAdd { get; set; }
        [Required(ErrorMessage = "CustomerPhone not null")]
        public string CustomerPhone { get; set; }
    }
}
