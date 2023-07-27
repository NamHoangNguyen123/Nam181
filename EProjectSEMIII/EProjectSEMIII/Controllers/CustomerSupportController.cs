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
    public class CustomerSupportController : Controller
    {
        private readonly AppDBContext _context;

        public CustomerSupportController(AppDBContext context)
        {
            _context = context;
        }

        // GET: CustomerSupports
        public async Task<IActionResult> Index()
        {
            return View(await _context.CustomerSupports.ToListAsync());
        }

    }
}
