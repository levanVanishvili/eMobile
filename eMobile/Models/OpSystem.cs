using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eMobile.Models
{
    public class OpSystem
    {
        [Key]
        public int Id { get; set; }

        [Display(Name="Operating System Name")] 
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}
