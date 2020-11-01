using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eMobile.Data.Repository.IRepository;
using eMobile.Models;
using Microsoft.AspNetCore.Mvc;

namespace eMobile.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class OpSystemController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public OpSystemController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Upsert(int? id)
        {
            OpSystem opSystem = new OpSystem();
            if (id == null)
            {
                //this is for create
                return View(opSystem);
            }
            //this is for edit
            opSystem = _unitOfWork.OpSystem.Get(id.GetValueOrDefault());
            if (opSystem==null)
            {
                return NotFound();
            }
            return View(opSystem);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(OpSystem opSystem)
        {
            if (ModelState.IsValid)
            {
                if (opSystem.Id == 0)
                {
                    _unitOfWork.OpSystem.Add(opSystem);
                }
                else
                {
                    _unitOfWork.OpSystem.Update(opSystem);
                }
                _unitOfWork.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(opSystem);
        }

        #region API CALLS

        [HttpGet]
        public IActionResult GetAll()
        {
            var allObj = _unitOfWork.OpSystem.GetAll();
            return Json(new { data = allObj });
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var objFromDb = _unitOfWork.OpSystem.Get(id);
            if (objFromDb == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }
            _unitOfWork.OpSystem.Remove(objFromDb);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Delete Successful" });
        }

        #endregion


    }
}
