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
    public class EstimateController : Controller
    {
        private readonly AppDBContext _context;

        public EstimateController(AppDBContext context)
        {
            _context = context;
        }

        // GET: Estimate
        public async Task<IActionResult> Index(string vehicleNumber)
        {
            var appDBContext = _context.Estimate.Include(e => e.InsuranceType).Include(e => e.VehicleInfomation).Where(e=>e.Status==0 && e.VehicleInfomation.VehicleNumber == vehicleNumber);
            return View(await appDBContext.ToListAsync());
        }

        public async Task<IActionResult> Buy(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estimate = await _context.Estimate.Include(e=>e.VehicleInfomation).Include(e=>e.VehicleInfomation.CustomerRecord).Include(e=>e.InsuranceType).FirstOrDefaultAsync(e=>e.EstimateId==id);
            if (estimate == null)
            {
                return NotFound();
            }
            estimate.Status = 1;
            _context.Update(estimate);
            var test = estimate.VehicleInfomation.CustomerRecord.CustomerAdd;
            CustomerPolicy customerPolicy = new CustomerPolicy();
            customerPolicy.CustomerName = estimate.CustomerName;
            customerPolicy.CustomerPhone = estimate.CustomerPhone;
            customerPolicy.CustomerAdd = estimate.VehicleInfomation.CustomerRecord.CustomerAdd;
            customerPolicy.PolicyNumber = DateTime.Today.ToString("ddmmyyyy")+estimate.EstimateId.ToString();
            customerPolicy.PolicyDate = DateTime.Now;
            customerPolicy.PolicyDuration = 12;
            customerPolicy.VehicleName = estimate.VehicleInfomation.VehicleName;
            customerPolicy.VehicleNumber = estimate.VehicleInfomation.VehicleNumber;
            customerPolicy.VehicleModel = estimate.VehicleInfomation.VehicleModel;
            customerPolicy.VehicleVersion = estimate.VehicleInfomation.VehicleVersion;
            customerPolicy.VehicleRate = estimate.VehicleInfomation.VehicleRate;
            customerPolicy.VehicleBodyNumber = estimate.VehicleInfomation.VehicleBodyNumber;
            customerPolicy.VehicleEngineNumber = estimate.VehicleInfomation.VehicleEngine;
            customerPolicy.CustomerRecordId = estimate.VehicleInfomation.CustomerRecordId;
            customerPolicy.InsuranceTypeId = estimate.InsuranceTypeId;
            customerPolicy.EstimateNumber = estimate.EstimateNumber;
            _context.Add(customerPolicy);

            BillingInformation billingInformation = new BillingInformation(estimate.VehicleInfomation.CustomerRecordId,customerPolicy.CustomerName,customerPolicy.CustomerPhone,customerPolicy.PolicyNumber,customerPolicy.VehicleName,customerPolicy.VehicleModel,customerPolicy.VehicleRate,customerPolicy.VehicleBodyNumber,customerPolicy.VehicleEngineNumber,estimate.InsuranceType.Price,customerPolicy.CustomerPolicyId );
            _context.Add(billingInformation);
            await _context.SaveChangesAsync();
            return RedirectToAction("index", new { vehicleNumber = customerPolicy.VehicleNumber });
        }
    }
}
