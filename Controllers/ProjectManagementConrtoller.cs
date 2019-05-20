using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
       
       

        public IActionResult ProjectAdd()
        {
           
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ProjectAdd([Bind("ProjectId,ProjectName")] ProjectManagement ProjectManagement)
        {
           if (ModelState.IsValid)
            {
                _context.Add(ProjectManagement);
                await _context.SaveChangesAsync();
               
                return RedirectToAction(nameof(ProjectAdd));
                
            }
           
            return View(ProjectManagement);
            
        }


        public IActionResult ProjectView()
        {
           /* List<ProjectManagementModel>project=new List<ProjectManagementModel>();
           project= (from P in _context.ProjectManagement .FirstOrDefaultAsync(
                    select P .ProjectName)). tolist();

          ViewBag.listofProjectName = project;
           return View();
          */
          return View(_context.ProjectManagement.ToList());
        


        }
        

        public IActionResult ProjectManagementHome()
        {
        
                return View(_context.UserAccount.ToList());
        
        }

        [HttpPost] 
        public  async Task<IActionResult> ProjectDeleteById(int? ProjectId)
        {   
            var employees = await _context.ProjectManagement
                .FirstOrDefaultAsync(m => m.ProjectId == ProjectId);
       
             if (ProjectId == null)
          
             {
                return NotFound();
             }

             var ProjectManagement = await _context.ProjectManagement.FindAsync(ProjectId);
            _context.ProjectManagement.Remove(ProjectManagement);
            await _context.SaveChangesAsync();
           
          
           return RedirectToAction("ProjectDelete");
    
           
        }

     
           
          
 public IActionResult ProjectDelete()
 {
     return View(_context.ProjectManagement.ToList() );
 }
       

     public IActionResult Logout()
        {
              
            HttpContext.Session.Clear();
            return RedirectToAction("Login"," Home");
    
            
        }

       
      [HttpPost]
        public IActionResult Deactivate(int? id)
        {
            var result = ( from p  in _context.UserAccount where p.UserId == id select p).FirstOrDefault();
             
                result.IsActive =false; 
                  _context.SaveChanges();

                  return RedirectToAction("ProjectManagementHome");
         }
   


    }
}