﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestApp1.Models
{
   public class Event
   {
      [Key]
      public int Id { get; set; }
      public string Name { get; set; }

   }
}
