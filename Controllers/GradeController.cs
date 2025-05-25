using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore; 
using KTGK.Models; 

namespace KTGK.Controllers
{
    public class GradeController : Controller
    {
        
        private readonly ApplicationDbContext _context;

      
        public GradeController(ApplicationDbContext context)
        {
            _context = context;
        }

        
      
        public async Task<IActionResult> Index()
        {
            
            List<Grade> listGrade = await _context.Grades.ToListAsync();

           
            return View(listGrade);
        }

       
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
               
                return NotFound();
            }

           
            var grade = await _context.Grades
                .FirstOrDefaultAsync(m => m.GradeId == id);

            if (grade == null)
            {
                
                return NotFound();
            }

            
            return View(grade);
        }

      
        public IActionResult Create()
        {
            return View();
        }

       
        [HttpPost] 
        [ValidateAntiForgeryToken] 
        public async Task<IActionResult> Create([Bind("GradeId,GradeName,ImagePath")] Grade grade)
        {
           
            if (ModelState.IsValid)
            {
               
                _context.Add(grade);
              
                await _context.SaveChangesAsync();
               
                return RedirectToAction(nameof(Index));
            }
           
            return View(grade);
        }

        
      
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

           
            var grade = await _context.Grades.FindAsync(id);

            if (grade == null)
            {
                return NotFound();
            }
           
            return View(grade);
        }

       
        [HttpPost] 
        [ValidateAntiForgeryToken] 
        public async Task<IActionResult> Edit(int id, [Bind("GradeId,GradeName,ImagePath")] Grade grade)
        {
           
            if (id != grade.GradeId)
            {
                return NotFound();
            }

           
            if (ModelState.IsValid)
            {
                try
                {
                    
                    _context.Update(grade);
                    
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    
                    if (!GradeExists(grade.GradeId))
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
           
            return View(grade);
        }

       
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

           
            var grade = await _context.Grades
                .FirstOrDefaultAsync(m => m.GradeId == id);

            if (grade == null)
            {
                return NotFound();
            }

            
            return View(grade);
        }

      
        [HttpPost, ActionName("Delete")] 
        [ValidateAntiForgeryToken] 
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            // Tìm lớp học cần xóa
            var grade = await _context.Grades.FindAsync(id);
            if (grade != null)
            {
              
                _context.Grades.Remove(grade);
            }

           
            await _context.SaveChangesAsync();
           
            return RedirectToAction(nameof(Index));
        }

       
        private bool GradeExists(int id)
        {
            return _context.Grades.Any(e => e.GradeId == id);
        }
    }
}
