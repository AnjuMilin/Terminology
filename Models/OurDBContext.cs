using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace TerminologyDemo.Models
{

   


    public class OurDBContext: DbContext
    {
    public OurDBContext (DbContextOptions <OurDBContext> options): base (options)
    {



    }



    public DbSet <UserAccount> UserAccount { get; set; }
    public DbSet <TerminologyDemo.Models.ProjectManagement> ProjectManagement{ get ; set;}
    public DbSet < ProjectUpload > ProjectUpload { get ; set;}
   
    }
}