using Microsoft.AspNetCore.Mvc;
using PortfolioApp.Data.Context;
using PortfolioApp.Data.Entities;
using Microsoft.EntityFrameworkCore;


namespace PortfolioApp.Controllers
{
    public class ProjectController : Controller
    {
        private readonly AppDBContext _context;


        public ProjectController(AppDBContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var projects = _context.Projects.Include(p => p.ProjectTexhStacks).ThenInclude(ts => ts.TechStack).ToList();
            return View(projects);
        }

        public IActionResult Create()
        {
            ViewBag.TechStacks = _context.TechStacks.ToList();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Project project, IFormFile? imageFile, List<int> techStackIds)
        {
            ModelState.Remove("ImageUrl");  

            if (imageFile == null || imageFile.Length == 0)
            {
                ModelState.AddModelError("ImageUrl", "Görsel Url boş bırakılamaz");
            }

            if (!ModelState.IsValid)
            {
                ViewBag.TechStacks = _context.TechStacks.ToList();
                return View(project);
            }

            var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images");
            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);

            var fileName = Guid.NewGuid() + Path.GetExtension(imageFile!.FileName);
            var path = Path.Combine(folderPath, fileName);

            using var stream = new FileStream(path, FileMode.Create);
            await imageFile.CopyToAsync(stream);
            project.ImageUrl = "/Images/" + fileName;

            _context.Projects.Add(project);
            _context.SaveChanges();

            if(techStackIds != null)
            {// Seçilen yada işaretlenen kutucukları, yeni oluşturulan projeye bağladık ve 
                foreach (var techStackId in techStackIds)
                {
                    _context.ProjectTechStacks.Add(new ProjectTechStack
                    {
                        ProjectId = project.Id,
                        TechStackId = techStackId
                    });
                }//kaydettik
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }


        public IActionResult Update(int id)
        {
            var project = _context.Projects.Find(id);
            if (project == null)
            {
                return NotFound();
            }

            ViewBag.TechStacks = _context.TechStacks.ToList();
            ViewBag.SelectedTechStackIds = _context.ProjectTechStacks.Where(x => x.ProjectId == id).Select(x => x.TechStackId).ToList();

            return View(project);
        }

        [HttpPost]
        public async Task<IActionResult> Update(Project project, IFormFile? imageFile, List<int> techStackIds )
        {
            var projects = _context.Projects.Find(project.Id);
            if (projects == null)
            {
                return NotFound();
            }

            projects.Name = project.Name;
            projects.Description = project.Description;
            projects.GithupUrl = project.GithupUrl;

            if (imageFile != null && imageFile.Length > 0)
            {
                var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images");
                if (!Directory.Exists(folderPath))
                    Directory.CreateDirectory(folderPath);

                var fileName = Guid.NewGuid() + Path.GetExtension(imageFile.FileName);
                var path = Path.Combine(folderPath, fileName);

                using var stream = new FileStream(path, FileMode.Create);
                await imageFile.CopyToAsync(stream);
                projects.ImageUrl = "/Images/" + fileName;
            }
            var existing = _context.ProjectTechStacks.Where(z => z.ProjectId == projects.Id).ToList();
            _context.ProjectTechStacks.RemoveRange(existing);

            if(techStackIds != null)
            {
                foreach (var item in techStackIds)
                {
                    _context.ProjectTechStacks.Add(new ProjectTechStack
                    {
                        ProjectId = projects.Id,
                        TechStackId = item

                    });
                }
            }

            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var project = _context.Projects.Find(id);
            if (project != null)
            {
                _context.Projects.Remove(project);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
