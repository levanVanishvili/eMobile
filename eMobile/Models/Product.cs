using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace eMobile.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; }

        [Required]
        public string Dimensions { get; set; }

        [Required]
        public string Weight { get; set; }

        [Required]
        public string DisplaySize { get; set; }

        [Required]
        public string Resolution { get; set; }

        [Required]
        public string CPU { get; set; }

        [Required]
        public string RomMemory { get; set; }

        [Required]
        [Range(1,15000,ErrorMessage ="Please enter a value between 1 and 15000")]
        public double Price { get; set; }

        public string FileUrl { get; set; }

        [NotMapped]
        public List<string> Fieles { get; set; }

        [Required]
        public int OpSystemId { get; set; }
        [ForeignKey("OpSystemId")]
        public OpSystem OpSystem { get; set; }

        [Required]
        public int BrandId { get; set; }
        [ForeignKey("BrandId")]
        public Brand Brand { get; set; } 
    }
}
