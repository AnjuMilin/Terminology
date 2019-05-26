using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace TerminologyDemo.Models
{
  public class ProjectManagement
  {
      [Key]

      public int ProjectId { get; set; }
    
      [Required(ErrorMessage="Project Name  Required")]
      public string ProjectName { get; set; }
     
     

     
        
  }

}