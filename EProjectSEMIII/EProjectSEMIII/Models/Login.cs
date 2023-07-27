using System.ComponentModel.DataAnnotations;

namespace EProjectSEMIII.Models
{
    public class Login
    {
        [Required(ErrorMessage = "UserName not null")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Password not null")]
        public string Password { get; set; }
    }
}
