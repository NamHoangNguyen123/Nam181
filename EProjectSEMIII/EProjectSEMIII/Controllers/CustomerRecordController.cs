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
    public class CustomerRecordController : Controller
    {
        private readonly AppDBContext _context;

        public CustomerRecordController(AppDBContext context)
        {
            _context = context;
        }
        // GET: CustomerRecord/Edit/5
        public async Task<IActionResult> Edit()
        {
            var id = HttpContext.Session.GetInt32("UserIdLogin");

            var customerRecord = await _context.CustomerRecord.FindAsync(id);
            if (customerRecord == null)
            {
                return NotFound();
            }
            return View(customerRecord);
        }

        // POST: CustomerRecord/ChangePassword/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("CustomerRecordId,CustomerName,CustomerAdd,CustomerPhone,UserName,Password,Status")] CustomerRecord customerRecord)
        {

            var id = HttpContext.Session.GetInt32("UserIdLogin");
            if (ModelState.IsValid)
            {
                if (customerRecord.CustomerRecordId != HttpContext.Session.GetInt32("UserIdLogin"))
                {
                    ViewBag.error = "Authentication error!";
                    return View();
                }
                try
                {
                    CustomerRecord customerRecordBase =await _context.CustomerRecord.FirstOrDefaultAsync(c => c.CustomerRecordId == customerRecord.CustomerRecordId);
                    customerRecordBase.CustomerName = customerRecord.CustomerName;
                    customerRecordBase.CustomerAdd = customerRecord.CustomerAdd;
                    customerRecordBase.CustomerPhone = customerRecord.CustomerPhone;
                    _context.Entry(customerRecordBase).CurrentValues.SetValues(customerRecordBase);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomerRecordExists(customerRecord.CustomerRecordId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Edit));
            }
            return View(customerRecord);
        }
        public IActionResult UpdatePassword()
        {
            return View();
        }

        // POST: CustomerRecord/ChangePassword/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdatePassword([Bind("Password,NewPassword,ReEnterNewPassword")] UpdatePassword updatePassword)
        {

            var id = HttpContext.Session.GetInt32("UserIdLogin");
            CustomerRecord customerRecord =await _context.CustomerRecord.FindAsync(id);

            if (customerRecord==null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                if (customerRecord.Password != Encoding.EncryptData(updatePassword.Password))
                {
                    ViewBag.errorPassword = "Incorrect password!";
                    return View();
                }
                if (updatePassword.NewPassword != updatePassword.ReEnterNewPassword)
                {
                    ViewBag.errorRePass = "Incorrect Re-enter new password!";
                    return View();
                }
                try
                {
                    customerRecord.Password = Encoding.EncryptData(updatePassword.NewPassword);
                    _context.Entry(customerRecord).CurrentValues.SetValues(customerRecord);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomerRecordExists(customerRecord.CustomerRecordId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Edit", "CustomerRecord", new { id=customerRecord.CustomerRecordId});
            }
            return View(updatePassword);
        }

        private bool CustomerRecordExists(int id)
        {
            return _context.CustomerRecord.Any(e => e.CustomerRecordId == id);
        }
    }
}
