using AuthSystem.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sustainable_Gardening_Community.Dtos;
using Sustainable_Gardening_Community.Models;

namespace Sustainable_Gardening_Community.Controllers
{
    public class TipsController : Controller
    {
        private readonly AuthDbContext _context;
        private readonly IWebHostEnvironment _he;
        public TipsController(AuthDbContext context, IWebHostEnvironment he)
        {
            this._context = context;
            this._he = he;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Tips.ToListAsync());
        }

        [Authorize]
        public async Task<IActionResult> ManageTips()
        {
            return View(await _context.Tips.ToListAsync());
        }
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TipsDto tipsDto)
        {
            if (ModelState.IsValid)
            {
                Tips tips = new Tips()
                {
                    Title = tipsDto.Title,
                    Description = tipsDto.Description
                };

                //image
                var file = tipsDto.ImagePath;
                string webroot = _he.WebRootPath;
                string folder = "img";
                string imgFileName = Path.GetFileName(tipsDto.ImagePath.FileName);
                string fileToSave = Path.Combine(webroot, folder, imgFileName);

                if (file != null)
                {
                    using (var stream = new FileStream(fileToSave, FileMode.Create))
                    {
                        tipsDto.ImagePath.CopyTo(stream);
                        tips.Image = "/" + folder + "/" + imgFileName;
                    }
                }


                _context.Tips.Add(tips);

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(ManageTips));
            }
            return View();
        }

        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            var tips = await _context.Tips.FirstOrDefaultAsync(x => x.Id == id);
            TipsDto tipsDto = new TipsDto()
            {
                Id = tips.Id,
                Title = tips.Title,
                Description = tips.Description,
                Image = tips.Image,
            };


            return View(tipsDto);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Edit(TipsDto tipsDto)
        {
            if (ModelState.IsValid)
            {
                Tips tips = new Tips()
                {
                    Id = tipsDto.Id,
                    Title = tipsDto.Title,
                    Description = tipsDto.Description,
                    Image = tipsDto.Image
                };

                //for image
                var file = tipsDto.ImagePath;
                if (file != null)
                {
                    string webroot = _he.WebRootPath;
                    string folder = "img";
                    string imgFileName = Path.GetFileName(tipsDto.ImagePath.FileName);
                    string fileToSave = Path.Combine(webroot, folder, imgFileName);
                    using (var stream = new FileStream(fileToSave, FileMode.Create))
                    {
                        tipsDto.ImagePath.CopyTo(stream);
                        tipsDto.Image = "/" + folder + "/" + imgFileName;
                    }
                }

                _context.Update(tips);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(ManageTips));
            }
            return View();
        }

        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            var tips = await _context.Tips.FirstOrDefaultAsync(x => x.Id == id);
            TipsDto tipsDto = new TipsDto()
            {
                Id = tips.Id,
                Title = tips.Title,
                Description = tips.Description,
                Image = tips.Image,
            };


            return View(tipsDto);
        }

        [Authorize]
        [HttpPost]
        public IActionResult Delete(int id)
        {
            Tips tips = _context.Tips.Find(id);

            if (tips == null)
            {
                return NotFound();
            }
            _context.Entry(tips).State = EntityState.Deleted;
            _context.SaveChanges();

            return RedirectToAction(nameof(ManageTips));
        }
    }
}
