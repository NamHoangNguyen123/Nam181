using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EProjectSEMIII.Models;
using X.PagedList;
using EProjectSEMIII.ActionFilter;

namespace EProjectSEMIII.Areas.Admins.Controllers
{
    [Area("Admins")]
    [ServiceFilter(typeof(LoginAdminFilter))]
    public class InsuranceTypesController : Controller
    {
        private readonly AppDBContext _context;

        public InsuranceTypesController(AppDBContext context)
        {
            _context = context;
        }

        // GET: Admins/InsuranceTypes
        public async Task<IActionResult> Index(string name, string sort, int page = 1)
        {
            int limit = 2; // mỗi trang hiển thị 6 bản ghi
            var insuranceType = await _context.InsuranceType.ToListAsync();
            ViewBag.keySearch = name;
            ViewBag.sort = sort;
            ViewBag.page = page;
            // nếu không rỗng tham số name trên url

            if (!String.IsNullOrEmpty(sort))
            {
                if (sort == "a")
                {
                    insuranceType = await insuranceType.OrderBy(c => c.InsurenceTypeId).ToListAsync();
                }
                else if (sort == "b")
                {
                    insuranceType = await insuranceType.OrderByDescending(c => c.InsurenceTypeId).ToListAsync();
                }
                else if (sort == "c")
                {
                    insuranceType = await insuranceType.OrderBy(c => c.TypeOfInsurence).ToListAsync();
                }
                else if (sort == "d")
                {
                    insuranceType = await insuranceType.OrderByDescending(c => c.TypeOfInsurence).ToListAsync();
                }
            }

            if (String.IsNullOrEmpty(name))
            {

            }
            else
            {
                insuranceType = await insuranceType.Where(c => c.TypeOfInsurence.Contains(name)).ToListAsync();
                if (insuranceType.Count == 0)
                {
                    ViewBag.itemNotFound = name + " not found";
                }
            }

            return View(insuranceType.ToPagedList(page, limit));

        }

        // GET: Admins/InsuranceTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var insuranceType = await _context.InsuranceType
                .FirstOrDefaultAsync(m => m.InsurenceTypeId == id);
            if (insuranceType == null)
            {
                return NotFound();
            }

            return View(insuranceType);
        }

        // GET: Admins/InsuranceTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admins/InsuranceTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("InsurenceTypeId,TypeOfInsurence,Price,Status")] InsuranceType insuranceType)
        {




            if (ModelState.IsValid)
            {

                var checkName = _context.InsuranceType.FirstOrDefault(i => i.TypeOfInsurence == insuranceType.TypeOfInsurence);
                if (checkName != null)
                {
                    ViewBag.CheckName = "Name already exists";
                }
                else
                {
                    _context.Add(insuranceType);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                
            }
            return View(insuranceType);
        }

        // GET: Admins/InsuranceTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var insuranceType = await _context.InsuranceType.FindAsync(id);
            if (insuranceType == null)
            {
                return NotFound();
            }
            return View(insuranceType);
        }

        // POST: Admins/InsuranceTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("InsurenceTypeId,TypeOfInsurence,Price,Status")] InsuranceType insuranceType)
        {
            if (id != insuranceType.InsurenceTypeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var checkName = _context.InsuranceType.FirstOrDefault(i => i.TypeOfInsurence.Equals(insuranceType.TypeOfInsurence) && i.InsurenceTypeId.Equals(insuranceType.InsurenceTypeId) == false);
                    if (checkName != null)
                    {
                        ViewBag.CheckName = "Name already exists";
                    }
                    else
                    {
                        _context.Update(insuranceType);
                        await _context.SaveChangesAsync();
                        return RedirectToAction(nameof(Index));
                    }
                 
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InsuranceTypeExists(insuranceType.InsurenceTypeId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
               
            }
            return View(insuranceType);
        }

        // GET: Admins/InsuranceTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var insuranceType = await _context.InsuranceType
                .FirstOrDefaultAsync(m => m.InsurenceTypeId == id);
            if (insuranceType == null)
            {
                return NotFound();
            }

            return View(insuranceType);
        }

        // POST: Admins/InsuranceTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var insuranceType = await _context.InsuranceType.FindAsync(id);
            _context.InsuranceType.Remove(insuranceType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InsuranceTypeExists(int id)
        {
            return _context.InsuranceType.Any(e => e.InsurenceTypeId == id);
        }
    }
}
