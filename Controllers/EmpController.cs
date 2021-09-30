using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVCCrudApplication.Models;
using Microsoft.EntityFrameworkCore;
using MVCCrudApplication.ViewModels;
using System.IO;

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

        public async Task<IActionResult> Create(EmployeeCreateViewModel Emp)
        {
            if(ModelState.IsValid)
            {
                string uniqueFileName = null;
                if(Emp.Photo !=null)
                {
                    string UplaodFolder = @"D:\DOT NET REPOs\MVCCrudApplication\wwwroot\Image";
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + Emp.Photo.FileName;
                    string FilePath = Path.Combine(UplaodFolder, uniqueFileName);
                    Emp.Photo.CopyTo(new FileStream(FilePath, FileMode.Create));
                }

                NewEmpClass Em = new NewEmpClass
                {
                    EmpName = Emp.EmpName,
                    Email = Emp.Email,
                    Age = Emp.Age,
                    Salary = Emp.Salary,
                    Image = uniqueFileName
                };

                _db.Add(Em);
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");

            }
            return View(Emp);
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
