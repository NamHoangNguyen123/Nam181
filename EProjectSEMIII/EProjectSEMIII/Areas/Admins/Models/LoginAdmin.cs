using System.ComponentModel.DataAnnotations;

namespace EProjectSEMIII.Areas.Admins.Models
{
    public class LoginAdmin
    {
        [Required(ErrorMessage = "UserName Not null")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Password Not null")]
        public string Password { get; set; }
    }
}
