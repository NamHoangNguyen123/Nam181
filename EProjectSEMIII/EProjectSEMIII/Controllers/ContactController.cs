using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EProjectSEMIII.Models;

namespace EProjectSEMIII.Controllers
{
    public class ContactController : Controller
    {
        private readonly AppDBContext _context;

        public ContactController(AppDBContext context)
        {
            _context = context;
        }

        // GET: Contact
        public async Task<IActionResult> Index()
        {

            ViewBag.sitemap = await _context.Sitemaps.OrderBy(s => s.Position).FirstOrDefaultAsync();
            return View();
        }
        public async Task<IActionResult> Create()
        {

            ViewBag.sitemap = await _context.Sitemaps.OrderBy(s => s.Position).FirstOrDefaultAsync();
            return View("Index");
        }
        // POST: Contact/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ContactId,CusName,CusMail,Subject,ContactNumber,Message")] Contact contact)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contact);
                await _context.SaveChangesAsync();
                TempData["submitSuccess"] = "Thank for your request, we will contact again for you earliest!!!";
                return RedirectToAction(nameof(Index));
            }
            ViewBag.sitemap = await _context.Sitemaps.OrderBy(s => s.Position).FirstOrDefaultAsync();
            return View("Index", contact);
        }
        
        private bool ContactExists(int id)
        {
            return _context.Contacts.Any(e => e.ContactId == id);
        }
    }
}
