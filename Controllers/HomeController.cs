using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TerminologyDemo.Models;


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
           // return View(_context.UserAccount.ToList());
           return View();
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
           // return RedirectToAction("AdminHome");
           

         return RedirectToAction("ProjectManagementHome", "ProjectManagement");
            }
        //}
          else
          {

           
            var account= _context.UserAccount.FirstOrDefault (u => u.UserName == user.UserName && u.Password==user.Password);
             //var account = _context.UserAccount.Where(u => u.UserName == user.UserName && u.Password == user.Password).FirstOrDefault();
            
            if(account != null)
            {
               
               HttpContext.Session.SetString ("UserId" , account.UserId.ToString() );

                 HttpContext.Session.SetString ("UserName" , account.UserName);
                 return RedirectToAction("Welcome");
            }
            else
            {
             ModelState.AddModelError(" ", "User name and password not correct");
            }
            return View();
        }
        }

        
       public IActionResult ResetPassword()
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
                return RedirectToAction("Login");
            }
            
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("index");
        }
      public IActionResult AdminHome()
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
