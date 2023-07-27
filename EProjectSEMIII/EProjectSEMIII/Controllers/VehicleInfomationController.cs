using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EProjectSEMIII.Models;
using Microsoft.AspNetCore.Http;
using EProjectSEMIII.ActionFilter;

namespace EProjectSEMIII.Controllers
{
    [ServiceFilter(typeof(LoginFilter))]
    public class VehicleInfomationController : Controller
    {
        private readonly AppDBContext _context;

        public VehicleInfomationController(AppDBContext context)
        {
            _context = context;
        }

        // GET: VehicleInfomation
        public async Task<IActionResult> Index()
        {
            var userIdLogin = HttpContext.Session.GetInt32("UserIdLogin");
            var appDBContext = _context.VehicleInfomation.Where(c=>c.CustomerRecordId==userIdLogin).Include(v => v.CustomerRecord).Include(v => v.InsideVehicleType);
            return View(await appDBContext.ToListAsync());
        }

        // GET: VehicleInfomation/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicleInfomation = await _context.VehicleInfomation
                .Include(v => v.CustomerRecord)
                .Include(v => v.InsideVehicleType)
                .FirstOrDefaultAsync(m => m.VehicleInfomationId == id);
            if (vehicleInfomation == null)
            {
                return NotFound();
            }

            return View(vehicleInfomation);
        }

        // POST: VehicleInfomation/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VehicleInfomationId,VehicleName,OwnerOfVehicle,VehicleModel,VehicleVersion,VehicleRate,VehicleBodyNumber,VehicleEngine,VehicleNumber,Status,CustomerRecordId,InsideVehicleTypeId")] VehicleInfomation vehicleInfomation)
        {
            if (ModelState.IsValid)
            {
                var checkName = _context.VehicleInfomation.FirstOrDefault(i => i.VehicleBodyNumber == vehicleInfomation.VehicleBodyNumber);
                if (checkName != null)
                {
                    ViewBag.CheckName = "VehicleBodyNumber already exists";
                }
                else
                {
                    _context.Add(vehicleInfomation);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }

            }
            ViewBag.VehicleType = await _context.VehicleType.ToListAsync();

            ViewBag.InsideVehicleType = await _context.InsideVehicleType.ToListAsync();
            ViewData["CustomerRecordId"] = new SelectList(_context.CustomerRecord, "CustomerRecordId", "CustomerRecordId", vehicleInfomation.CustomerRecordId);
            ViewData["InsideVehicleTypeId"] = new SelectList(_context.InsideVehicleType, "InsideVehicleTypeId", "Name", vehicleInfomation.InsideVehicleTypeId);
            return View("~/Views/InsideVehicleTypes/Index.cshtml", vehicleInfomation);
        }
        // POST: VehicleInfomation/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("VehicleInfomationId,VehicleName,OwnerOfVehicle,VehicleModel,VehicleVersion,VehicleRate,VehicleBodyNumber,VehicleEngine,VehicleNumber,Status,CustomerRecordId,InsideVehicleTypeId")] VehicleInfomation vehicleInfomation)
        {
            if (id != vehicleInfomation.VehicleInfomationId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vehicleInfomation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VehicleInfomationExists(vehicleInfomation.VehicleInfomationId))
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
            ViewData["CustomerRecordId"] = new SelectList(_context.CustomerRecord, "CustomerRecordId", "CustomerRecordId", vehicleInfomation.CustomerRecordId);
            ViewData["InsideVehicleTypeId"] = new SelectList(_context.InsideVehicleType, "InsideVehicleTypeId", "InsideVehicleTypeId", vehicleInfomation.InsideVehicleTypeId);
            return View(vehicleInfomation);
        }

        // GET: VehicleInfomation/Delete/5
        

        private bool VehicleInfomationExists(int id)
        {
            return _context.VehicleInfomation.Any(e => e.VehicleInfomationId == id);
        }
    }
}
