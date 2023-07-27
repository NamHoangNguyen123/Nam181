using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EProjectSEMIII.Models;

namespace EProjectSEMIII.Areas.Admins.Controllers
{
    [Area("Admins")]
    public class CustomerPoliciesController : Controller
    {
        private readonly AppDBContext _context;

        public CustomerPoliciesController(AppDBContext context)
        {
            _context = context;
        }

        // GET: Admins/CustomerPolicies
        public async Task<IActionResult> Index()
        {
            var appDBContext = _context.CustomerPolicy.Include(c => c.BillingInformation).Include(c => c.CustomerRecord).Include(c => c.InsuranceType);
            return View(await appDBContext.ToListAsync());
        }

        // GET: Admins/CustomerPolicies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customerPolicy = await _context.CustomerPolicy
                .Include(c => c.CustomerRecord)
                .Include(c => c.InsuranceType)
                .Include(c=> c.BillingInformation)
                .FirstOrDefaultAsync(m => m.CustomerPolicyId == id);
            if (customerPolicy == null)
            {
                return NotFound();
            }

            return View(customerPolicy);
        }

    }
}
