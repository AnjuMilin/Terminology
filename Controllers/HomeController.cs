using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TerminologyDemo.Models;
using System.Collections.Generic;


namespace TerminologyDemo.Controllers
{
    public class HomeController : Controller
    {
        private OurDBContext _context;
        public HomeController(OurDBContext Context)
        {
             _context = Context;

        }
         public IActionResult Index()
        {
           return View(_context.ProjectUpload.ToList());
        
          // return View();

        } 

       
         public IActionResult Register()
        {
            
            return View();
        }

        [HttpPost]
         public IActionResult Register(UserAccount user)
        {
            
            if(ModelState.IsValid)
            {
                _context.UserAccount.Add(user);
                 user.IsActive = true;
                _context.SaveChanges();
                 ModelState.Clear();
                 ViewBag.Message=user.firstName+" "+user.LastName+" Is successfully registered";
                
            
            }
            return View();


        }

     public IActionResult Login()
        {
            
            return View();
        }
      
      [HttpPost]
        public IActionResult Login(UserAccount user)
        {
        //  if (ModelState.IsValid)
        //{
            //var isValid = (user.UserName == "admin" && user.Password == "admin"); 
            if(user.UserName == "admin" && user.Password == "admin")
            {
           
           

         return RedirectToAction("ProjectManagementHome", "ProjectManagement");
            }
        //}
          else
          {

           
            var account= _context.UserAccount.FirstOrDefault (u => u.UserName == user.UserName && u.Password==user.Password);
             
            
            if(account != null)
            {               
                //if(account.IsActive == false)
                //{
                 //  ViewBag.Message("This user can't access this site");
               // }
              //else
               //{ 
               HttpContext.Session.SetString ("UserId" , account.UserId.ToString() );

                 HttpContext.Session.SetString ("UserName" , account.UserName);
                 return RedirectToAction("Welcome","UserHome");
              //}
            }
            else
            {
             ModelState.AddModelError(" ", "User name and password not correct");
            }
            return View();
        }
        }

        
      

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("index");
        }
      public IActionResult ProjectManagementHome()
        {
            return View(_context.UserAccount.ToList());
            
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        
    }
}
