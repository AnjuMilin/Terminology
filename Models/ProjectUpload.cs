using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace TerminologyDemo.Models
{
  public class ProjectUpload
  {
      [Key]

      public int PId { get; set; }
      
      [Required(ErrorMessage="Contrinuter name Required")]
      public string Contributer { get; set; }
      
     // [Required(ErrorMessage="Project name Required")]
      public string ProjectTitle { get; set; }

      
     // [Required(ErrorMessage="Project title Required")]
      public string NewsTitle { get; set; }   
     
      
      [Required(ErrorMessage="New url Required")]
      public string urlName { get; set; }   

    
  }

}