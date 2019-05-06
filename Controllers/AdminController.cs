using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TerminologyDemo.Models;


namespace TerminologyDemo.Controllers
{
    public class AdminController : Controller
    {
      
       private OurDBContext _context;
        public AdminController(OurDBContext Context)
        {
             _context = Context;

        }
 
      







    }
}