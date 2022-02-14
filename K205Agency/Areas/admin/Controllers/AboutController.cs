﻿using K205Agency.Data;
using K205Agency.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace K205Agency.Areas.admin.Controllers
{
    [Area("Admin")]
    public class AboutController : Controller
    {
        private readonly AgencyDbContext _context;
        private IWebHostEnvironment _environment;

        public AboutController(AgencyDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Abouts.ToListAsync());
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {

            var about = _context.Abouts.FirstOrDefault(x=>x.ID == id);
            if (about == null) return NotFound();


            return View(about);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(About about)
        {

            try
            {
                _context.Update(about);
                _context.SaveChanges();
                
            }
            catch (Exception)
            {

                return NotFound();
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Detail(int id)
        {
            var about = _context.Abouts.FirstOrDefault(x=>x.ID == id);
            if(about == null) return NotFound();
                
            return View(about);
        }

      
        public async Task<IActionResult> Delete(int id)
        {

            var about = await _context.Abouts.FindAsync(id);
            _context.Abouts.Remove(about);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(About about,IFormFile Image)
        {
            var path = Path.Combine(_environment.WebRootPath, "files");
            var photo = Image.FileName;
            using (var fs = new FileStream(Path.Combine(path, photo),
                FileMode.Create))
            {
                fs.CopyToAsync(fs);
            }
             about.CreatedDate = DateTime.Now;
            about.PhotoURL = photo;
            _context.Abouts.Add(about);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}
