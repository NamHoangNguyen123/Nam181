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
using Microsoft.AspNetCore.Http;

namespace EProjectSEMIII.Areas.Admins.Controllers
{
    [Area("Admins")]
    [ServiceFilter(typeof(LoginAdminFilter))]
    public class ClaimDetailsController : Controller
    {
        private readonly AppDBContext _context;

        public ClaimDetailsController(AppDBContext context)
        {
            _context = context;
        }

        // GET: Admins/ClaimDetails
        public async Task<IActionResult> Index(string key, string sort, int page = 1)
        {
            int limit = 6; // mỗi trang hiển thị 6 bản ghi
            var claimDetail = await _context.ClaimDetail.Include(c=>c.CustomerPolicy).Include(c=>c.Admin).ToListAsync();
            ViewBag.key = key;
            ViewBag.sort = sort;
            ViewBag.page = page;
            // nếu không rỗng tham số name trên url

            if (!String.IsNullOrEmpty(sort))
            {
                if (sort == "idASC")
                {
                    claimDetail = await claimDetail.OrderBy(c => c.ClaimDetailId).ToListAsync();
                }
                else if (sort == "idDESC")
                {
                    claimDetail = await claimDetail.OrderByDescending(c => c.ClaimDetailId).ToListAsync();
                }
                else if (sort == "nameASC")
                {
                    claimDetail = await claimDetail.OrderBy(c => c.CustomerName).ToListAsync();
                }
                else if (sort == "nameDESC")
                {
                    claimDetail = await claimDetail.OrderByDescending(c => c.CustomerName).ToListAsync();
                }
            }

            if (String.IsNullOrEmpty(key))
            {

            }
            else
            {
                claimDetail = await claimDetail.Where(c => c.CustomerName.Contains(key)||c.PolicyNumber.Contains(key)).ToListAsync();
                if (claimDetail.Count == 0)
                {
                    ViewBag.itemNotFound = " No record found for this key!";
                }
            }

            return View(claimDetail.ToPagedList(page, limit));
        }

        // GET: Admins/ClaimDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var claimDetail = await _context.ClaimDetail.Include(c => c.Admin).Include(c => c.CustomerPolicy).FirstOrDefaultAsync(c=>c.ClaimDetailId==id);
            if (claimDetail == null)
            {
                return NotFound();
            }
            return View(claimDetail);
        }

        // POST: Admins/ClaimDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, int Status)
        {
            ClaimDetail claimDetail = await _context.ClaimDetail.FindAsync(id);
            if (claimDetail == null)
            {
                return NotFound();
            }
            try
            {
                if (claimDetail.AdminId == null)
                {
                    claimDetail.AdminId = HttpContext.Session.GetInt32("AdminIdLogin");
                }
                else
                {
                    if(claimDetail.AdminId!= HttpContext.Session.GetInt32("AdminIdLogin"))
                    {
                        ViewBag.ErrCustom = "No Access";
                        return View(claimDetail);
                    }
                }
                if (claimDetail.Status > Status)
                {
                    ViewBag.ErrCustom = "Unreasonable progress";
                    return View(claimDetail);
                }
                if (Status == 2 && claimDetail.Status < 2)
                {
                    CustomerPolicy customerPolicy = await _context.CustomerPolicy.FirstOrDefaultAsync(c => c.CustomerPolicyId == claimDetail.CustomerPolicyId);
                    customerPolicy.EstimateNumber -= claimDetail.ClaimableAmout.Value;
                    if (customerPolicy.EstimateNumber < 0)
                    {
                        ViewBag.ErrCustom = "The amount of compensation exceeds the limit!";
                        return View(claimDetail);
                    }
                }
                claimDetail.Status = Status;
                _context.Update(claimDetail);
                
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClaimDetailExists(claimDetail.ClaimDetailId))
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

        // GET: Admins/ClaimDetails/Delete/5
       

        private bool ClaimDetailExists(int id)
        {
            return _context.ClaimDetail.Any(e => e.ClaimDetailId == id);
        }
    }
}
