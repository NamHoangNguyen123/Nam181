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
    public class InsideVehicleTypesController : Controller
    {
        private readonly AppDBContext _context;

        public InsideVehicleTypesController(AppDBContext context)
        {
            _context = context;
        }

        // GET: Admins/InsideVehicleTypes
        public async Task<IActionResult> Index(string name,string sort, int page = 1)
        {
            int limit = 2; // mỗi trang hiển thị 6 bản ghi
            var insideVehicleType = await _context.InsideVehicleType.Include(i=>i.VehicleType).ToListAsync();
            ViewBag.keySearch = name;
            ViewBag.sort = sort;
            ViewBag.page = page;
            // nếu không rỗng tham số name trên url

            if (!String.IsNullOrEmpty(sort))
            {
                if (sort == "a")
                {
                    insideVehicleType = await insideVehicleType.OrderBy(c => c.InsideVehicleTypeId).ToListAsync();
                }
                else if (sort == "b")
                {
                    insideVehicleType = await insideVehicleType.OrderByDescending(c => c.InsideVehicleTypeId).ToListAsync();
                }
                else if (sort == "c")
                {
                    insideVehicleType = await insideVehicleType.OrderBy(c => c.Name).ToListAsync();
                }
                else if (sort == "d")
                {
                    insideVehicleType = await insideVehicleType.OrderByDescending(c => c.Name).ToListAsync();
                }
            }

            if (String.IsNullOrEmpty(name))
            {

            }
            else
            {
                insideVehicleType = await insideVehicleType.Where(c => c.Name.ToUpper().Contains(name.ToUpper())).ToListAsync();
                if (insideVehicleType.Count == 0)
                {
                    ViewBag.itemNotFound = name + " not found";
                }
            }

            return View(insideVehicleType.ToPagedList(page, limit));

        
        }

        // GET: Admins/InsideVehicleTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var insideVehicleType = await _context.InsideVehicleType
                .Include(i => i.VehicleType)
                .FirstOrDefaultAsync(m => m.InsideVehicleTypeId == id);
            if (insideVehicleType == null)
            {
                return NotFound();
            }

            return View(insideVehicleType);
        }

        // GET: Admins/InsideVehicleTypes/Create
        public IActionResult Create()
        {
            ViewData["VehicleTypeId"] = new SelectList(_context.VehicleType, "VehicleTypeId", "NameOfVehicleType");
            return View();
        }

        // POST: Admins/InsideVehicleTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("InsideVehicleTypeId,Name,Status,VehicleTypeId")] InsideVehicleType insideVehicleType)
        {
            if (ModelState.IsValid)
            {
                var checkName = _context.InsideVehicleType.FirstOrDefault(i => i.Name == insideVehicleType.Name);
                if (checkName != null)
                {
                    ViewBag.CheckName = "Name already exists";
                }
                else
                {
                    _context.Add(insideVehicleType);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                
            }
            ViewData["VehicleTypeId"] = new SelectList(_context.VehicleType, "VehicleTypeId", "VehicleTypeId", insideVehicleType.VehicleTypeId);
            return View(insideVehicleType);
        }

        // GET: Admins/InsideVehicleTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var insideVehicleType = await _context.InsideVehicleType.FindAsync(id);
            if (insideVehicleType == null)
            {
                return NotFound();
            }

            ViewData["VehicleTypeId"] = new SelectList(_context.VehicleType, "VehicleTypeId", "NameOfVehicleType", insideVehicleType.VehicleTypeId);
            return View(insideVehicleType);
        }

        // POST: Admins/InsideVehicleTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("InsideVehicleTypeId,Name,Status,VehicleTypeId")] InsideVehicleType insideVehicleType)
        {
            if (id != insideVehicleType.InsideVehicleTypeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var checkName = _context.InsideVehicleType.FirstOrDefault(i => i.Name.Equals(insideVehicleType.Name) && i.InsideVehicleTypeId.Equals(insideVehicleType.InsideVehicleTypeId) == false);
                    if (checkName != null)
                    {
                        ViewBag.CheckName = "Name already exists";
                    }
                    else
                    {
                        _context.Update(insideVehicleType);
                        await _context.SaveChangesAsync();
                        return RedirectToAction(nameof(Index));
                    }

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InsideVehicleTypeExists(insideVehicleType.InsideVehicleTypeId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                
            }
            ViewData["VehicleTypeId"] = new SelectList(_context.VehicleType, "VehicleTypeId", "VehicleTypeId", insideVehicleType.VehicleTypeId);
            return View(insideVehicleType);
        }

        // GET: Admins/InsideVehicleTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var insideVehicleType = await _context.InsideVehicleType
                .Include(i => i.VehicleType)
                .FirstOrDefaultAsync(m => m.InsideVehicleTypeId == id);
            if (insideVehicleType == null)
            {
                return NotFound();
            }

            return View(insideVehicleType);
        }

        // POST: Admins/InsideVehicleTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var insideVehicleType = await _context.InsideVehicleType.FindAsync(id);
            _context.InsideVehicleType.Remove(insideVehicleType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InsideVehicleTypeExists(int id)
        {
            return _context.InsideVehicleType.Any(e => e.InsideVehicleTypeId == id);
        }
    }
}
