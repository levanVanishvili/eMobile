using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace eMobile.Models
{
    public class FileManagerModel
    {
        [NotMapped]
        public FileInfo[] Files { get; set; }
        [NotMapped]
        public IFormFile IFormFile { get; set; }
        [NotMapped]
        public List<IFormFile> IFormFiles { get; set; }
    }
}
