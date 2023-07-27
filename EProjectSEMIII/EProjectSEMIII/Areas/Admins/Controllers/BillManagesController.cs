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
    public class BillManagesController : Controller
    {
        private readonly AppDBContext _context;

        public BillManagesController(AppDBContext context)
        {
            _context = context;
        }

        // GET: Admins/BillManages
        public async Task<IActionResult> Index()
        {
            var appDBContext = _context.BillingInformation.Include(b => b.CustomerPolicy);
            return View(await appDBContext.ToListAsync());
        }

        // GET: Admins/BillManages/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var billingInformation = await _context.BillingInformation
                .Include(b => b.CustomerPolicy)
                .FirstOrDefaultAsync(m => m.BillingInformationId == id);
            if (billingInformation == null)
            {
                return NotFound();
            }

            return View(billingInformation);
        }


        // GET: Admins/BillManages/DetailsPost/5
        public async Task<IActionResult> DetailsPost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var billingInformation = await _context.BillingInformation
                .Include(b => b.CustomerPolicy)
                .FirstOrDefaultAsync(m => m.BillingInformationId == id);
            var customerPolicy = _context.CustomerPolicy.FirstOrDefault(c => c.BillingInformation.BillingInformationId == id);
            customerPolicy.Status = 1;
            billingInformation.Status = 1;
            try
            {
                _context.Update(billingInformation);
                _context.Update(customerPolicy);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BillingInformationExists(billingInformation.BillingInformationId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            ViewBag.success = "Activate insurance success";
            ViewBag.id = id;
            return View();
        }

        // GET: Admins/BillManages/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var billingInformation = await _context.BillingInformation
                .Include(b => b.CustomerPolicy)
                .FirstOrDefaultAsync(m => m.BillingInformationId == id);
            if (billingInformation == null)
            {
                return NotFound();
            }

            return View(billingInformation);
        }

        // POST: Admins/BillManages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var billingInformation = await _context.BillingInformation.FindAsync(id);
            _context.BillingInformation.Remove(billingInformation);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BillingInformationExists(int id)
        {
            return _context.BillingInformation.Any(e => e.BillingInformationId == id);
        }
    }
}
