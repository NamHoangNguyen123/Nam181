using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EProjectSEMIII.Models
{
    [Table("Sitemap")]
    public class Sitemap
    {
        [Key]
        public int SiteMapId { get; set; }

        [DisplayName("Position")]
        [Required(ErrorMessage = "Please fill Position")]
        public int Position { get; set; } // set important position for map;

        [Required(ErrorMessage = "Please fill your address")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Please fill your linked map")]
        public string LinkedMap { get; set; }
    }
}
