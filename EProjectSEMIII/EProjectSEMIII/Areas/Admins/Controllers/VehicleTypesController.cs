using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EProjectSEMIII.Models;
using System.ComponentModel;
using X.PagedList;
using EProjectSEMIII.ActionFilter;

namespace EProjectSEMIII.Areas.Admins.Controllers
{
    [Area("Admins")]
    [ServiceFilter(typeof(LoginAdminFilter))]
    public class VehicleTypesController : Controller
    {
        private readonly AppDBContext _context;

        public VehicleTypesController(AppDBContext context)
        {
            _context = context;
        }

        // GET: Admins/VehicleTypes
        [HttpGet]
        public async Task<IActionResult> Index(string name, string sort, int page = 1)
        {
            int limit = 2; // mỗi trang hiển thị 6 bản ghi
            var vehicleType = await _context.VehicleType.ToListAsync();
            ViewBag.keySearch = name;
            ViewBag.sort = sort;
            ViewBag.page = page;
            // nếu không rỗng tham số name trên url

            if (!String.IsNullOrEmpty(sort))
            {
                if (sort == "a")
                {
                    vehicleType =await vehicleType.OrderBy(c => c.VehicleTypeId).ToListAsync();
                }
                else if (sort == "b")
                {
                    vehicleType = await vehicleType.OrderByDescending(c => c.VehicleTypeId).ToListAsync();
                }else if (sort == "c")
                {
                    vehicleType = await vehicleType.OrderBy(c => c.NameOfVehicleType).ToListAsync();
                }else if (sort == "d")
                {
                    vehicleType = await vehicleType.OrderByDescending(c => c.NameOfVehicleType).ToListAsync();
                }
            }
          
            if (String.IsNullOrEmpty(name))
            {
                
            }
            else
            {
                vehicleType = await vehicleType.Where(c => c.NameOfVehicleType.Contains(name)).ToListAsync();
                if (vehicleType.Count == 0)
                {
                    ViewBag.itemNotFound = name + " not found";
                }
            }

            return View(vehicleType.ToPagedList(page,limit));
        }

        // GET: Admins/VehicleTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicleType = await _context.VehicleType
                .FirstOrDefaultAsync(m => m.VehicleTypeId == id);
            if (vehicleType == null)
            {
                return NotFound();
            }

            return View(vehicleType);
        }

        // GET: Admins/VehicleTypes/Create
        public IActionResult Create()
        {
            
            return View();
        }

        // POST: Admins/VehicleTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VehicleTypeId,NameOfVehicleType,Status")] VehicleType vehicleType)
        {
            if (ModelState.IsValid)
            {
                var checkName = _context.VehicleType.FirstOrDefault(i => i.NameOfVehicleType == vehicleType.NameOfVehicleType);
                if (checkName != null)
                {
                    ViewBag.CheckName = "Name already exists";
                }
                else
                {
                    _context.Add(vehicleType);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                
            }
            return View(vehicleType);
        }

        // GET: Admins/VehicleTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicleType = await _context.VehicleType.FindAsync(id);
            if (vehicleType == null)
            {
                return NotFound();
            }
            return View(vehicleType);
        }

        // POST: Admins/VehicleTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("VehicleTypeId,NameOfVehicleType,Status")] VehicleType vehicleType)
        {
            if (id != vehicleType.VehicleTypeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {

                    var checkName = _context.VehicleType.FirstOrDefault(i => i.NameOfVehicleType.Equals(vehicleType.NameOfVehicleType) && i.VehicleTypeId.Equals(vehicleType.VehicleTypeId) == false);
                    if (checkName != null)
                    {
                        ViewBag.CheckName = "Name already exists";
                    }
                    else
                    {
                        _context.Update(vehicleType);
                        await _context.SaveChangesAsync();
                        return RedirectToAction(nameof(Index));
                    }

                   
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VehicleTypeExists(vehicleType.VehicleTypeId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
               
            }
            return View(vehicleType);
        }

        // GET: Admins/VehicleTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicleType = await _context.VehicleType
                .FirstOrDefaultAsync(m => m.VehicleTypeId == id);
            if (vehicleType == null)
            {
                return NotFound();
            }

            return View(vehicleType);
        }

        // POST: Admins/VehicleTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {

            if (_context.VehicleType == null)
            {
                ViewBag.Err = "Err ";
            }
            var vehicleType = await _context.VehicleType.FindAsync(id);
            var insideVehicleType =  _context.InsideVehicleType.FirstOrDefault(i => i.VehicleTypeId == id);
            if (insideVehicleType != null)
            {
                ViewBag.err = "have foreign key";
                return View();
            }
            else { 
            try
            {
                if (vehicleType != null)
                {
                    _context.VehicleType.Remove(vehicleType);

                }

                await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            catch (Exception )
            {
                ModelState.AddModelError("vehicleTypeErro", "Ko thể xóa danh mục này ");
                return View();
            }
            }

        }

        private bool VehicleTypeExists(int id)
        {
            return _context.VehicleType.Any(e => e.VehicleTypeId == id);
        }
    }
}
