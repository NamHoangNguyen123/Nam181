using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EProjectSEMIII.Models;
using EProjectSEMIII.ActionFilter;

namespace EProjectSEMIII.Controllers
{
    [ServiceFilter(typeof(LoginFilter))]
    public class CustomerPolicyController : Controller
    {
        private readonly AppDBContext _context;

        public CustomerPolicyController(AppDBContext context)
        {
            _context = context;
        }

        // GET: CustomerPolicy
        public async Task<IActionResult> Index(string vehicleNumber)
        {
            var appDBContext = _context.CustomerPolicy.Include(c => c.CustomerRecord).Include(c => c.InsuranceType).Where(c=>c.VehicleNumber== vehicleNumber && c.Status==1);
            return View(await appDBContext.ToListAsync());
        }

        // GET: CustomerPolicy/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customerPolicy = await _context.CustomerPolicy
                .Include(c => c.CustomerRecord)
                .Include(c => c.InsuranceType)
                .Include(c=>c.BillingInformation)
                .FirstOrDefaultAsync(m => m.CustomerPolicyId == id);
            if (customerPolicy == null)
            {
                return NotFound();
            }

            return View(customerPolicy);
        }
    }
}
