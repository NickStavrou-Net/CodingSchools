﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TestMasterDetail.DataAccess
{
   public class TeamMember
   {
      [Key]
      [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
      public int TeamMemberID { get; set; }
      public int TeamID { get; set; }
      public string Name { get; set; }
      public string Email { get; set; }
   }
}
