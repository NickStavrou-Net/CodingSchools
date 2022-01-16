using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TestMasterDetail.DataAccess
{
   public class Team
   {
      [Key]
      [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
      public int TeamID { get; set; }
      public string Name { get; set; }
      public string Description { get; set; }

      [ForeignKey("TeamID")]
      public List<TeamMember> Members { get; set; }
   }
}
