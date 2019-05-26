using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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

       

        public IActionResult Addnewsurl()
         {
             return View();
         }
        

       [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Addnewsurl([Bind("UserId,PId,Contributer,ProjectTitle,NewsTitle,urlName")] ProjectUpload ProjectUpload)
        {
           if (ModelState.IsValid && HttpContext.Session.GetString("UserId")!=null)
            {
                
                ProjectUpload.UserId=Convert.ToInt32(HttpContext.Session.GetString("UserId"));
                _context.Add(ProjectUpload);
                await _context.SaveChangesAsync();
               
                return RedirectToAction(nameof(Addnewsurl));
                
            }
           
           return View(ProjectUpload);
            
        }


    [HttpGet]
     public async Task<IActionResult> EditProfile(int UserId)
    {
         var userAccounts= new UserAccount(); 
        
        userAccounts = await _context.UserAccount.Where(x => x.UserId == UserId).FirstOrDefaultAsync();
        return View(userAccounts);
    }
    

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task <IActionResult> EditProfile([Bind("UserId,firstName,LastName,EmailId,UserName,Password,ConformPassword")]UserAccount userAccount )
        {

           if (userAccount.UserId < 0)
            {
               return NotFound(); 
            }

           if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userAccount);
                    await _context.SaveChangesAsync();
                }
                 catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(userAccount.UserId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }

                }}
             else
             {
              var y= ModelState.Select(x=>x.Value.Errors).ToList();  
             }
                
                   
       
            
           return View(userAccount);
        }


         private bool UserExists(int id)
        {
            return _context.UserAccount.Any(e => e.UserId == id);
        }

     public IActionResult AddNewTerminology()
     {
         return View();
     }

       

         public IActionResult Welcome(int UserId)
        {
           if (HttpContext.Session.GetString("UserId") != null)
            
            {
                ViewBag.UserName=HttpContext.Session.GetString("UserName");
                ViewBag.UserId =HttpContext.Session.GetString("UserId"); 
            
               
                return View();

            }
            else
            {
                return RedirectToAction("Login","Home");
            }
            
        }
        


      [HttpPost, ActionName("DeleteUrl")]
         [ValidateAntiForgeryToken]
      [HttpPost] 
        public  async Task<IActionResult> ProjectDeleteById(int? PId)
        {   
            var uploads = await _context.ProjectUpload
                .FirstOrDefaultAsync(m => m.PId == PId);
       
             if (PId == null)
          
             {
                return NotFound();
             }

             var ProjectUpload = await _context.ProjectUpload.FindAsync(PId);
            _context.ProjectUpload.Remove(ProjectUpload);
            await _context.SaveChangesAsync();
           
          
           return RedirectToAction("DeleteUrl");
    
           
        }

   
      [HttpGet]
         public IActionResult DeleteUrl(int UserId)
           { 
                ViewBag.UserId =HttpContext.Session.GetString("UserId"); 
                 ViewBag.PId =HttpContext.Session.GetString("PId"); 
            var ProjectUpload = _context.ProjectUpload.Where(m => m.UserId == UserId).ToList();
              if (HttpContext.Session.GetString("UserId") != null)
          
             {
                return View(ProjectUpload);
             }
           else{
               return NotFound();
           }

        } 
     
     public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Welcome");
        }

    }
}