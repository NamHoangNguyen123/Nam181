using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EProjectSEMIII.Models;
using EProjectSEMIII.ActionFilter;

namespace EProjectSEMIII.Areas.Admins.Controllers
{
    [Area("Admins")]
    [ServiceFilter(typeof(LoginAdminFilter))]
    public class CustomerSupportsController : Controller
    {
        private readonly AppDBContext _context;

        public CustomerSupportsController(AppDBContext context)
        {
            _context = context;
        }

        // GET: Admins/CustomerSupports
        public async Task<IActionResult> Index()
        {
            return View(await _context.CustomerSupports.ToListAsync());
        }

        // GET: Admins/CustomerSupports/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customerSupport = await _context.CustomerSupports
                .FirstOrDefaultAsync(m => m.CustomerSupportId == id);
            if (customerSupport == null)
            {
                return NotFound();
            }

            return View(customerSupport);
        }

        // GET: Admins/CustomerSupports/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admins/CustomerSupports/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CustomerSupportId,Question,Answer")] CustomerSupport customerSupport)
        {
            if (ModelState.IsValid)
            {
                _context.Add(customerSupport);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(customerSupport);
        }

        // GET: Admins/CustomerSupports/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customerSupport = await _context.CustomerSupports.FindAsync(id);
            if (customerSupport == null)
            {
                return NotFound();
            }
            return View(customerSupport);
        }

        // POST: Admins/CustomerSupports/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CustomerSupportId,Question,Answer")] CustomerSupport customerSupport)
        {
            if (id != customerSupport.CustomerSupportId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(customerSupport);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomerSupportExists(customerSupport.CustomerSupportId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(customerSupport);
        }

        // GET: Admins/CustomerSupports/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customerSupport = await _context.CustomerSupports
                .FirstOrDefaultAsync(m => m.CustomerSupportId == id);
            if (customerSupport == null)
            {
                return NotFound();
            }

            return View(customerSupport);
        }

        // POST: Admins/CustomerSupports/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var customerSupport = await _context.CustomerSupports.FindAsync(id);
            _context.CustomerSupports.Remove(customerSupport);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CustomerSupportExists(int id)
        {
            return _context.CustomerSupports.Any(e => e.CustomerSupportId == id);
        }
    }
}
