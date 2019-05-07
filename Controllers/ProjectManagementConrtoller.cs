using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TerminologyDemo.Models;


namespace TerminologyDemo.Controllers
{
    public class ProjectManagementController : Controller
    {
        private OurDBContext _context;
        public ProjectManagementController(OurDBContext Context)
        {
             _context = Context;

        }
         public IActionResult Create()
        {
           
           return View();
        } 
       
       [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProjectId,ProjectName")] ProjectManagementModel ProjectManagement)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ProjectManagement);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Create));
            }
            return View(ProjectManagement);
        }

        public IActionResult ProjectAdd()
        {
           
            return View();
        }

        public IActionResult ProjectView()
        {
           
            return View();
        }


        public IActionResult ProjectManagementHome()
        {
           ViewBag.UserName=HttpContext.Session.GetString("UserName");
                return View();
        
        }

        public IActionResult ProjectDelete()
        {
           
            return View();
        }



        









    }
}    


