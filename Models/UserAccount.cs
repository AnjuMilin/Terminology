using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace TerminologyDemo.Models
{
  public class UserAccount
  {
      [Key]

      public int UserId { get; set; }
      
      [Required(ErrorMessage="FirstName Required")]
      public string firstName { get; set; }
      
      [Required(ErrorMessage="LastName Required")]
      public string LastName { get; set; }

      
      [Required(ErrorMessage="Email Id Required")]
      public string EmailId { get; set; }

      
      [Required(ErrorMessage="UserName Required")]
      public string UserName { get; set; }
      
      [Required(ErrorMessage="Password Required")]
      [DataType(DataType.Password)]
      public string Password { get; set; }
      
      
      [Compare( "Password" , ErrorMessage="Password  not match")]
     // [Required(ErrorMessage="ConformPassword Required")]
      public string ConformPassword { get; set; }


     public bool IsActive { get ; set ;}
      
      

    
  }

}