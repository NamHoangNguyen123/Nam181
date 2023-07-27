using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EProjectSEMIII.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using X.PagedList;
using EProjectSEMIII.ActionFilter;

namespace EProjectSEMIII.Controllers
{
    [ServiceFilter(typeof(LoginFilter))]
    public class InsideVehicleTypesController : Controller
    {
        private readonly AppDBContext _context;

        public InsideVehicleTypesController(AppDBContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(int? vehicleTypeId)
        {

            ViewBag.VehicleType = await _context.VehicleType.ToListAsync();
            if (vehicleTypeId != null)
            {
                ViewBag.InsideVehicleType = await _context.InsideVehicleType.Where(x => x.VehicleTypeId == vehicleTypeId).ToListAsync();
            }
            else
            {
                ViewBag.InsideVehicleType = await _context.InsideVehicleType.ToListAsync();
            }
            ViewBag.UserIdLogin= HttpContext.Session.GetInt32("UserIdLogin");
            ViewData["InsideVehicleTypeId"] = new SelectList(_context.InsideVehicleType, "InsideVehicleTypeId", "Name");

            return View();

        }

   
    } 
    }