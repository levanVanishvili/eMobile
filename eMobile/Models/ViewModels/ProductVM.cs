using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eMobile.Models.ViewModels
{
    public class ProductVM
    {
        public Product Product { get; set; }

        public IEnumerable<SelectListItem> BrandList { get; set; }

        public IEnumerable<SelectListItem> OpSystemList { get; set; }
    }
}
