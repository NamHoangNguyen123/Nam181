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
    public class SitemapsController : Controller
    {
        private readonly AppDBContext _context;

        public SitemapsController(AppDBContext context)
        {
            _context = context;
        }

        // GET: Admins/Sitemaps
        public async Task<IActionResult> Index()
        {
            return View(await _context.Sitemaps.ToListAsync());
        }

        // GET: Admins/Sitemaps/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sitemap = await _context.Sitemaps
                .FirstOrDefaultAsync(m => m.SiteMapId == id);
            if (sitemap == null)
            {
                return NotFound();
            }

            return View(sitemap);
        }

        // GET: Admins/Sitemaps/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admins/Sitemaps/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SiteMapId,Position,Address,LinkedMap")] Sitemap sitemap)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sitemap);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sitemap);
        }

        // GET: Admins/Sitemaps/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sitemap = await _context.Sitemaps.FindAsync(id);
            if (sitemap == null)
            {
                return NotFound();
            }
            return View(sitemap);
        }

        // POST: Admins/Sitemaps/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SiteMapId,Position,Address,LinkedMap")] Sitemap sitemap)
        {
            if (id != sitemap.SiteMapId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sitemap);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SitemapExists(sitemap.SiteMapId))
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
            return View(sitemap);
        }

        // GET: Admins/Sitemaps/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sitemap = await _context.Sitemaps
                .FirstOrDefaultAsync(m => m.SiteMapId == id);
            if (sitemap == null)
            {
                return NotFound();
            }

            return View(sitemap);
        }

        // POST: Admins/Sitemaps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sitemap = await _context.Sitemaps.FindAsync(id);
            _context.Sitemaps.Remove(sitemap);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SitemapExists(int id)
        {
            return _context.Sitemaps.Any(e => e.SiteMapId == id);
        }
    }
}
