using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using eMobile.Models;
using eMobile.Data.Repository.IRepository;
using eMobile.Models.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace eMobile.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }


        [HttpGet]
        public IActionResult Index(string searchProduct, string searchBrand, double searchMin, double searchMax)
        {
            IEnumerable<Product> productList = _unitOfWork.Product.GetAll(includeProperties: ("OpSystem,Brand"));

            if (!string.IsNullOrEmpty(searchProduct) && !string.IsNullOrEmpty(searchBrand) && searchMin!=0
                                                                                           && searchMax !=0)
            {
                productList = productList.Where(s => s.Name.Contains(searchProduct) && s.Brand.Name.Contains(searchBrand) &&
                                                   s.Price>=searchMin && s.Price<=searchMax);
            }
            if (!string.IsNullOrEmpty(searchProduct) && string.IsNullOrEmpty(searchBrand))
            {
                productList = productList.Where(s => s.Name.Contains(searchProduct));
            }
            if (string.IsNullOrEmpty(searchProduct) && !string.IsNullOrEmpty(searchBrand))
            {
                productList = productList.Where(s => s.Brand.Name.Contains(searchBrand));
            }
            return View(productList);
        }









        public IActionResult Details(int id)
        {
            var productFromDb = _unitOfWork.Product.GetFirstOrDefalt(p => p.Id == id, includeProperties: ("OpSystem,Brand"));
            return View(productFromDb);
        }



        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
