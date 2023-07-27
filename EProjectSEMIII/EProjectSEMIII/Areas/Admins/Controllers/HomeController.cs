using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EProjectSEMIII.ActionFilter;
using Microsoft.AspNetCore.Mvc;
using EProjectSEMIII.Models;

namespace EProjectSEMIII.Areas.Admins
{
    [Area("Admins")]
    [ServiceFilter(typeof(LoginAdminFilter))]
    public class HomeController : Controller
    {
        private readonly AppDBContext _context;
        public HomeController(AppDBContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            //total earning

            //getAllBill;
            //company expensive
            var company_expensive = _context.CompanyExpense.ToList();
            ViewBag.company_expensive = company_expensive;
            var billingInformation = _context.BillingInformation.Where(b => b.Status == 1).ToList();
            double amount = 0;
            billingInformation.ForEach(x =>
            {
                double am = 0;
                am += x.Amount;
                amount += am;
            });
            ViewBag.Amount = amount;

            //Revenue
            //Total Order;
            var total_orders = billingInformation.Count();
            ViewBag.total_orders = total_orders;

            //Earnings == Amount

            //total customer
            var total_customers = _context.CustomerRecord.ToList().Count();
            ViewBag.total_customers = total_customers;

            return View();
        }
    }
}