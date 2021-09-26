using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YearFive.Contracts;
using YearFive.Data;
using YearFive.Models;

namespace YearFive.Controllers
{
    public class YearFiveTypesController : Controller
    {
        private readonly IYearFiveRepository _repo;
        // private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public YearFiveTypesController(IYearFiveRepository repo, IMapper mapper)
        {
            _repo = repo;
            // _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        // GET: YearFiveTypesController
        public ActionResult Index()
        {
            var relationshiptypes = _repo.FindAll();
            var model = _mapper.Map<List<YearFiveType>, List<YearFiveTypeVM>>(relationshiptypes.ToList());
            return View(model);
        }

        // GET: YearFiveTypesController/Details/5
        public ActionResult Details(int id)
        {
            if (!_repo.isExists(id))
            {
                return NotFound();
            }
            var leavetype = _repo.FindById(id);
            var model = _mapper.Map<YearFiveTypeVM>(leavetype);
            return View(model);
        }

        // GET: YearFiveTypesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: YearFiveTypesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(YearFiveTypeVM model)
        {
            try
            {
                if (ModelState.IsValid == false)
                {
                    return View(model);
                }

                var leaveType = _mapper.Map<YearFiveType>(model);
                //leaveType.DateCreated = DateTime.Now;

                var isSuccess = _repo.Create(leaveType);
                if (isSuccess == false)
                {
                    ModelState.AddModelError("", "Something Went Wrong...");
                    return View(model);
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError("", "Something Went Wrong...");
                return View(model);
            }
        }

        // GET: YearFiveTypesController/Edit/5
        public ActionResult Edit(int id)
        {
            if (!_repo.isExists(id))
            {
                return NotFound();
            }
            var leavetype = _repo.FindById(id);
            var model = _mapper.Map<YearFiveTypeVM>(leavetype);
            return View(model);
        }

        // POST: YearFiveTypesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(YearFiveTypeVM model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                var leaveType = _mapper.Map<YearFiveType>(model);
                var isSuccess = _repo.Update(leaveType);
                if (!isSuccess)
                {
                    ModelState.AddModelError("", "Something Went Wrong...");
                    return View(model);
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError("", "Something Went Wrong...");
                return View(model);
            }
        }

        // GET: YearFiveTypesController/Delete/5
        public ActionResult Delete(int id)
        {
            var leavetype = _repo.FindById(id);
            if (leavetype == null)
            {
                return NotFound();
            }
            var isSuccess = _repo.Delete(leavetype);
            if (!isSuccess)
            {
                return BadRequest();
            }
            return RedirectToAction(nameof(Index));
        }

        // POST: YearFiveTypesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
