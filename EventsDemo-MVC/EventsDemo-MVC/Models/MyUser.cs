using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventsDemo_MVC.Models
{
   public class MyUser : IdentityUser
   {
      [PersonalData]
      public string FullName { get; set; }
      [PersonalData]
      public DateTime DOB { get; set; }
   }
}

