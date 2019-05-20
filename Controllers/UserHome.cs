using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TerminologyDemo.Models;


namespace TerminologyDemo.Controllers
{
    public class UserHome : Controller
    {
      
       private OurDBContext _context;
        public UserHome(OurDBContext Context)
        {
             _context = Context;

        }

       /* 
         public IActionResult Addnewsurl()
         {
             return View();
         }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
         public IActionResult Addnewsurl(ProjectUpload project)
        {
            if(ModelState.IsValid)
            {
                _context.ProjectUpload.Add(project);
                _context.SaveChanges();
                ModelState.Clear();
                ViewBag.Message=project.Contributer+ " " +project.ProjectTitle + " Is successfully Added";
                
            
            }
            return View();
        }
*/

        public IActionResult Addnewsurl()
         {
             return View();
         }
        

       [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Addnewsurl([Bind("PId,Contributer,ProjectTitle,NewsTitle,urlName")] ProjectUpload ProjectUpload)
        {
           if (ModelState.IsValid)
            {
                _context.Add(ProjectUpload);
                await _context.SaveChangesAsync();
               
                return RedirectToAction(nameof(Addnewsurl));
                
            }
           
           return View(ProjectUpload);
          // return RedirectToAction("Addnewsurl");
            
        }


     public IActionResult EditProfile()
     {
         return View();
     }


        public IActionResult AddTerminology()
        {
           
            return View();
        }
       

         public IActionResult Welcome()
        {
            
           // if(HttpContext.Session.GetString(UserAccount user)!=null)
           if (HttpContext.Session.GetString("UserId") != null)
            
            {
                ViewBag.UserName=HttpContext.Session.GetString("UserName");
                return View();

            }
            else
            {
                return RedirectToAction("Login","Home");
            }
            
        }

   public IActionResult DeleteUrl()
   {
       return View();
   } 


         [HttpPost] 
        public  async Task<IActionResult> DeleteUrl(int? PId)
        {   
            var ProjectUpload = await _context.ProjectUpload
                .FirstOrDefaultAsync(m => m.PId == PId);
       
             if (ProjectUpload == null)
          
             {
                return NotFound();
             }
            return View(ProjectUpload);

        }
        
         [HttpPost, ActionName("DeleteUrl")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int PId)
        {

             var ProjectUpload = await _context.ProjectUpload.FindAsync(PId);
            _context.ProjectUpload.Remove(ProjectUpload);
            await _context.SaveChangesAsync();
           
          
           return RedirectToAction("DeleteUrl");
         // return View(ProjectUpload);
    
           
        }
      
     public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Welcome");
        }

    }
}