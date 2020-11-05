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
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace eMobile.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {

        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHostingEnvironment _hostingEnvironment;

        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork, IHostingEnvironment hostingEnvironment)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
            _hostingEnvironment = hostingEnvironment;
        }

        [HttpGet]
        public IActionResult Index(string searchProduct, string searchBrand, double searchMin = 0, double searchMax=0)
        {
            IEnumerable<Product> productList = _unitOfWork.Product.GetAll(includeProperties: ("OpSystem,Brand"));

            if (!string.IsNullOrEmpty(searchProduct) && !string.IsNullOrEmpty(searchBrand) && searchMin!=0
                                                                                           && searchMax !=0)
            {
                productList = productList.Where(s => s.Name.Contains(searchProduct) && s.Brand.Name.Contains(searchBrand) &&
                                                   s.Price>=searchMin && s.Price<=searchMax);
            }
            if (!string.IsNullOrEmpty(searchProduct) && !string.IsNullOrEmpty(searchBrand) || searchMin != 0 || searchMax !=0)
            {
                if (searchMin!=0 && !string.IsNullOrEmpty(searchProduct) && !string.IsNullOrEmpty(searchBrand))
                {
                    productList = productList.Where(s => s.Name.Contains(searchProduct) && s.Brand.Name.Contains(searchBrand) &&
                                                   s.Price >= searchMin);
                }
                if (searchMax != 0 && !string.IsNullOrEmpty(searchProduct) && !string.IsNullOrEmpty(searchBrand))
                {
                    productList = productList.Where(s => s.Name.Contains(searchProduct) && s.Brand.Name.Contains(searchBrand) &&
                                                   s.Price <= searchMax);
                }
            }
            if (!string.IsNullOrEmpty(searchProduct) && string.IsNullOrEmpty(searchBrand) || searchMin != 0 || searchMax != 0)
            {
                if (searchMin!=0 && string.IsNullOrEmpty(searchBrand) && !string.IsNullOrEmpty(searchProduct))
                {
                    productList = productList.Where(s => s.Name.Contains(searchProduct) &&
                                                   s.Price >= searchMin);
                }
                if (searchMax!=0 && string.IsNullOrEmpty(searchBrand) && !string.IsNullOrEmpty(searchProduct))
                {
                    productList = productList.Where(s => s.Name.Contains(searchProduct) &&
                                                   s.Price <= searchMax);
                }
                if (searchMax == 0 && searchMin == 0)
                {
                    productList = productList.Where(s => s.Name.Contains(searchProduct));
                }
            }
            if (string.IsNullOrEmpty(searchProduct) && !string.IsNullOrEmpty(searchBrand) || searchMin != 0 || searchMax != 0)
            {
                if (searchMin != 0 && string.IsNullOrEmpty(searchProduct) && !string.IsNullOrEmpty(searchBrand))
                {
                    productList = productList.Where(s => s.Brand.Name.Contains(searchBrand) &&
                                                   s.Price >= searchMin);
                }
                if (searchMax != 0 && string.IsNullOrEmpty(searchProduct) && !string.IsNullOrEmpty(searchBrand))
                {
                    productList = productList.Where(s => s.Brand.Name.Contains(searchBrand) &&
                                                   s.Price <= searchMax);
                }
                if (searchMax == 0 && searchMin == 0)
                {
                    productList = productList.Where(s => s.Brand.Name.Contains(searchBrand));
                };

            }
            if (string.IsNullOrEmpty(searchProduct) && string.IsNullOrEmpty(searchBrand) || searchMin != 0 || searchMax != 0)
            {
                if (searchMax != 0)
                {
                    productList = productList.Where(s => s.Price <= searchMax);
                }
                if (searchMin != 0)
                {
                    productList = productList.Where(s => s.Price >= searchMin);
                }
            }
            return View(productList);
        }




        public IActionResult Details(int id)
        {
            var productFromDb = _unitOfWork.Product.GetFirstOrDefalt(p => p.Id == id, includeProperties: ("OpSystem,Brand"));

            FileManagerModel model = new FileManagerModel();
            var userImagesPath = Path.Combine(_hostingEnvironment.WebRootPath, "images/photos");
            DirectoryInfo dir = new DirectoryInfo(userImagesPath);
            FileInfo[] files = dir.GetFiles();
            model.Files = files;
            var photoName = productFromDb.Id + productFromDb.Name;
            ViewBag.photoes = files.Where(i => i.Name.Contains(photoName));

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
