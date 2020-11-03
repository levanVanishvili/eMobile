using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eMobile.Models.ViewModels
{
    public class SearchVM
    {
        public Product Products { get; set; }

        public IEnumerable<SelectListItem> BrandList { get; set; }

        public string  SearchBrand { get; set; }

        public string SearchString { get; set; }

    }
}
