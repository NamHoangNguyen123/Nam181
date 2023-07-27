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
    public class EstimatesController : Controller
    {
        private readonly AppDBContext _context;

        public EstimatesController(AppDBContext context)
        {
            _context = context;
        }

        // GET: Admins/Estimates
        public async Task<IActionResult> Index()
        {
            var appDBContext = _context.VehicleInfomation.Include(e => e.CustomerRecord).Include(e => e.InsideVehicleType);
            return View(await appDBContext.ToListAsync());
        }

        // GET: Admins/Estimates/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //vehicle infor
            var vehicleInfor = await _context.VehicleInfomation
                .Include(e => e.CustomerRecord)
                .Include(e => e.InsideVehicleType)
                .FirstOrDefaultAsync(m => m.VehicleInfomationId == id);
            ViewBag.vehicleInfor = vehicleInfor;

            var estimates = await _context.Estimate.Where(e => e.VehicleInfomationId == vehicleInfor.VehicleInfomationId).Include(e => e.VehicleInfomation).Include(e => e.InsuranceType).ToListAsync();
            if (estimates == null)
            {
                return NotFound();
            }
            return View(estimates);
        }

        // GET: Admins/Estimates/Create
        [Route("Admins/Estimates/Create/{vehicleId}")]
        public IActionResult Create(int vehicleId)
        {
            //find again vehicle by vehicle id;
            var vehicleInfor = _context.VehicleInfomation.FirstOrDefaultAsync(v => v.VehicleInfomationId == vehicleId).Result;
            if (vehicleInfor == null)
            {
                return NotFound("404");
            }

            //find customer
            var customer = _context.CustomerRecord.FirstOrDefault(c => c.CustomerRecordId == vehicleInfor.CustomerRecordId);

            //get all insurances;
            var insurances = _context.InsuranceType.ToListAsync();

            //push vehicle, customer and insurance into view
            ViewBag.customer = customer;
            ViewBag.vehicleInfor = vehicleInfor;
            ViewBag.insurances = insurances;

            ViewData["InsuranceTypeId"] = new SelectList(_context.InsuranceType, "InsurenceTypeId", "TypeOfInsurence", " - ", "Price");
            return View();
        }

        // POST: Admins/Estimates/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Admins/Estimates/Create/{vehicleId}")]
        public async Task<IActionResult> Create(int vehicleId, [Bind("CustomerName,CustomerPhone,EstimateNumber,VehicleName,VehicleModel,VehicleRate,VehicleWarranty,VehiclePolicyType,VehicleInfomationId,InsuranceTypeId")] Estimate estimate)
        {
            var vehicleInfor = _context.VehicleInfomation.FirstOrDefaultAsync(v => v.VehicleInfomationId == vehicleId).Result;

            //find customer
            var customer = _context.CustomerRecord.FirstOrDefault(c => c.CustomerRecordId == vehicleInfor.CustomerRecordId);

            //get all insurances;
            var insurances = _context.InsuranceType.ToListAsync();

            //push vehicle, customer and insurance into view
            ViewBag.customer = customer;
            ViewBag.vehicleInfor = vehicleInfor;
            ViewBag.insurances = insurances;
            if (ModelState.IsValid)
            {
                _context.Add(estimate);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["InsuranceTypeId"] = new SelectList(_context.InsuranceType, "InsurenceTypeId", "TypeOfInsurence", " - ", "Price");
            ViewData["VehicleInfomationId"] = new SelectList(_context.VehicleInfomation, "VehicleInfomationId", "VehicleInfomationId", estimate.VehicleInfomationId);
            return View(estimate);
        }

        // GET: Admins/Estimates/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var estimate = await _context.Estimate.FindAsync(id);
            if (estimate == null)
            {
                return NotFound("estimate is null");
            }

            //find again vehicle by estimate
            var vehicleInfor = _context.VehicleInfomation.FirstOrDefaultAsync(v => v.VehicleInfomationId == estimate.VehicleInfomationId).Result;

            //find customer
            var customer = _context.CustomerRecord.FirstOrDefault(c => c.CustomerRecordId == vehicleInfor.CustomerRecordId);

            //get all insurances;
            var insurances = _context.InsuranceType.ToListAsync();

            //push vehicle, customer and insurance into view
            ViewBag.customer = customer;
            ViewBag.vehicleInfor = vehicleInfor;
            ViewBag.insurances = insurances;

            ViewData["InsuranceTypeId"] = new SelectList(_context.InsuranceType, "InsurenceTypeId", "TypeOfInsurence", " - ", "Price");
            return View(estimate);
        }

        // POST: Admins/Estimates/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EstimateId,CustomerName,CustomerPhone,EstimateNumber,VehicleName,VehicleModel,VehicleRate,VehicleWarranty,VehiclePolicyType,Status,VehicleInfomationId,InsuranceTypeId")] Estimate estimate)
        {
            var vehicleInfor = _context.VehicleInfomation.FirstOrDefaultAsync(v => v.VehicleInfomationId == estimate.VehicleInfomationId).Result;

            //find customer
            var customer = _context.CustomerRecord.FirstOrDefault(c => c.CustomerRecordId == vehicleInfor.CustomerRecordId);

            //get all insurances;
            var insurances = _context.InsuranceType.ToListAsync();

            //push vehicle, customer and insurance into view
            ViewBag.customer = customer;
            ViewBag.vehicleInfor = vehicleInfor;
            ViewBag.insurances = insurances;
            if (id != estimate.EstimateId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(estimate);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EstimateExists(estimate.EstimateId))
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
            ViewData["InsuranceTypeId"] = new SelectList(_context.InsuranceType, "InsurenceTypeId", "InsurenceTypeId", estimate.InsuranceTypeId);
            ViewData["VehicleInfomationId"] = new SelectList(_context.VehicleInfomation, "VehicleInfomationId", "VehicleInfomationId", estimate.VehicleInfomationId);
            return View(estimate);
        }

        // GET: Admins/Estimates/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estimate = await _context.Estimate
                .Include(e => e.InsuranceType)
                .Include(e => e.VehicleInfomation)
                .FirstOrDefaultAsync(m => m.EstimateId == id);
            if (estimate == null)
            {
                return NotFound();
            }

            return View(estimate);
        }

        // POST: Admins/Estimates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var estimate = await _context.Estimate.FindAsync(id);
            _context.Estimate.Remove(estimate);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EstimateExists(int id)
        {
            return _context.Estimate.Any(e => e.EstimateId == id);
        }
    }
}
