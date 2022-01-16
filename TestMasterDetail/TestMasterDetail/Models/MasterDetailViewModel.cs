using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestMasterDetail.DataAccess;

namespace TestMasterDetail.Models
{
   public class MasterDetailViewModel
   {
      public List<Team> Teams { get; set; }
      public Team SelectedTeam { get; set; }
      public TeamMember SelectedTeamMember { get; set; }
      public DataEntryTargets DataEntryTarget { get; set; }
      public DataDisplayModes DataDisplayMode { get; set; }
   }
}
