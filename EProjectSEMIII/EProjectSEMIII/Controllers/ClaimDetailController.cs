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
    public class ClaimDetailController : Controller
    {
        private readonly AppDBContext _context;

        public ClaimDetailController(AppDBContext context)
        {
            _context = context;
        }

        // GET: ClaimDetail
        public async Task<IActionResult> Index(int idCustomerPolicy)
        {
            var appDBContext = _context.ClaimDetail.Include(c => c.Admin).Include(c => c.CustomerPolicy).Where(c=>c.CustomerPolicyId== idCustomerPolicy);
            return View(await appDBContext.ToListAsync());
        }

        // GET: ClaimDetail/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var claimDetail = await _context.ClaimDetail
                .Include(c => c.Admin)
                .Include(c => c.CustomerPolicy)
                .FirstOrDefaultAsync(m => m.ClaimDetailId == id);
            if (claimDetail == null)
            {
                return NotFound();
            }

            return View(claimDetail);
        }

        // GET: ClaimDetail/Create
        public IActionResult Create(int? idCustomerPolicy)
        {
            if (idCustomerPolicy == null)
            {
                return NotFound();
            }
            ViewData["AdminId"] = new SelectList(_context.Admin, "AdminId", "AdminId");
            ViewData["CustomerPolicyId"] = new SelectList(_context.CustomerPolicy, "CustomerPolicyId", "CustomerPolicyId");
            ClaimDetail claimDetail = new ClaimDetail();
            CustomerPolicy customerPolicy = _context.CustomerPolicy
                .Include(c => c.CustomerRecord)
                .Include(c => c.InsuranceType)
                .FirstOrDefault(m => m.CustomerPolicyId == idCustomerPolicy);
            claimDetail.PolicyNumber = customerPolicy.PolicyNumber;
            claimDetail.PolicyStartDate = customerPolicy.PolicyDate;
            claimDetail.PolicyEndDate = customerPolicy.PolicyDate.AddMonths(customerPolicy.PolicyDuration);
            claimDetail.CustomerName = customerPolicy.CustomerName;
            claimDetail.CustomerPolicyId = customerPolicy.CustomerPolicyId;
            claimDetail.DateOfAccident = DateTime.Today;
            ViewBag.InsuredAmout = customerPolicy.EstimateNumber;
            return View(claimDetail);
        }

        // POST: ClaimDetail/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ClaimDetailId,PolicyNumber,PolicyStartDate,PolicyEndDate,CustomerName,PlaceOfAccident,DateOfAccident,InsuredAmout,ClaimableAmout,Status,CustomerPolicyId,AdminId")] ClaimDetail claimDetail)
        {
            if (ModelState.IsValid)
            {
                _context.Add(claimDetail);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "ClaimDetail", new { idCustomerPolicy = claimDetail.CustomerPolicyId });
            }
            ViewBag.InsuredAmout = claimDetail.InsuredAmout;
            return View(claimDetail);
        }

        // GET: ClaimDetail/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var claimDetail = await _context.ClaimDetail.FindAsync(id);
            if (claimDetail == null)
            {
                return NotFound();
            }
            ViewData["AdminId"] = new SelectList(_context.Admin, "AdminId", "AdminId", claimDetail.AdminId);
            ViewData["CustomerPolicyId"] = new SelectList(_context.CustomerPolicy, "CustomerPolicyId", "CustomerPolicyId", claimDetail.CustomerPolicyId);
            return View(claimDetail);
        }

       
    }
}
