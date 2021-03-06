using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVCCrudApplication.Models;
using Microsoft.EntityFrameworkCore;




namespace MVCCrudApplication.Controllers
{
    public class EmpController : Controller
    {
        private readonly ApplicationDbContext _db;

        public EmpController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var displaydata = _db.EmpTable.ToList();
            return View(displaydata);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> Create(NewEmpClass nec)
        {
            if(ModelState.IsValid)
            {
                _db.Add(nec);
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");

            }
            return View(nec);
        }


        public async Task <IActionResult>Edit(int?id)
        {
            if(id==null)
            {
                return RedirectToAction("index");
            }

            var getempdetail = await _db.EmpTable.FindAsync(id);
            return View(getempdetail);
        }
        [HttpPost]

        public async Task<IActionResult> Edit (NewEmpClass nc)
        {
            if(ModelState.IsValid)
            {
                _db.Update(nc);
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(nc);
        }



        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("index");
            }

            var getempdetail = await _db.EmpTable.FindAsync(id);
            return View(getempdetail);
        }


        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("index");
            }

            var getempdetail = await _db.EmpTable.FindAsync(id);
            return View(getempdetail);
        }

        [HttpPost]

        public async Task<IActionResult> Delete(int id)
        {
            var getempdetail = await _db.EmpTable.FindAsync(id);
            _db.EmpTable.Remove(getempdetail);
            await _db.SaveChangesAsync();

            return RedirectToAction("Index");
        }

    }
}
