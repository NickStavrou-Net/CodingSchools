using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestMasterDetail.DataAccess;
using TestMasterDetail.Models;

namespace TestMasterDetail.Controllers
{
   public class TeamMembersController : Controller
   {

      private readonly AppDbContext db;

      public TeamMembersController(AppDbContext db)
      {
         this.db = db;
      }

      /*public IActionResult Index()
      {
         return View();
      }
      */

      [HttpPost]
      public IActionResult List(int teamId)
      {
         MasterDetailViewModel model = new MasterDetailViewModel
         {
            Teams = db.Teams.ToList(),
            SelectedTeam = db.Teams.Find(teamId),
            DataEntryTarget = DataEntryTargets.TeamMembers,
            DataDisplayMode = DataDisplayModes.Read
         };

         db.Entry(model.SelectedTeam).Collection(team => team.Members).Load();

         return View("Main", model);
      }

      [HttpPost]
      public IActionResult Select(int teamId, int memberId)
      {
         MasterDetailViewModel model = new MasterDetailViewModel
         {
            Teams = db.Teams.ToList(),
            SelectedTeam = db.Teams.Find(teamId),
            SelectedTeamMember = db.TeamMembers.Find(memberId),
            DataEntryTarget = DataEntryTargets.TeamMembers,
            DataDisplayMode = DataDisplayModes.Read
         };

         db.Entry(model.SelectedTeam).Collection(team => team.Members).Load();

         return View("Main", model);
      }

      [HttpPost]
      public IActionResult InsertEntry(int teamId)
      {
         MasterDetailViewModel model = new MasterDetailViewModel
         {
            Teams = db.Teams.ToList(),
            SelectedTeam = db.Teams.Find(teamId),
            SelectedTeamMember = null,
            DataEntryTarget = DataEntryTargets.TeamMembers,
            DataDisplayMode = DataDisplayModes.Insert
         };

         db.Entry(model.SelectedTeam).Collection(team => team.Members).Load();
         return View("Main", model);
      }

      [HttpPost]
      public IActionResult InsertSave(TeamMember member)
      {
         db.TeamMembers.Add(member);
         db.SaveChanges();
         
         MasterDetailViewModel model = new MasterDetailViewModel
         {
            Teams = db.Teams.ToList(),
            SelectedTeam = db.Teams.Find(member.TeamID),
            //SelectedTeamMember = db.TeamMembers.Find(member.TeamMemberID),
            SelectedTeamMember = null,
            DataEntryTarget = DataEntryTargets.TeamMembers,
            DataDisplayMode = DataDisplayModes.Read
         };

         db.Entry(model.SelectedTeam).Collection(team => team.Members).Load();
         return View("Main", model);
      }

      [HttpPost]
      public IActionResult UpdateEntry(int teamId, int memberId)
      {
         MasterDetailViewModel model = new MasterDetailViewModel
         {
            Teams = db.Teams.ToList(),
            SelectedTeam = db.Teams.Find(teamId),
            SelectedTeamMember = db.TeamMembers.Find(memberId),
            DataEntryTarget = DataEntryTargets.TeamMembers,
            DataDisplayMode = DataDisplayModes.Update
         };

         db.Entry(model.SelectedTeam).Collection(team => team.Members).Load();
         return View("Main", model);
      }

      [HttpPost]
      public IActionResult UpdateSave(TeamMember member)
      {
         db.TeamMembers.Update(member);
         db.SaveChanges();

         MasterDetailViewModel model = new MasterDetailViewModel
         {
            Teams = db.Teams.ToList(),
            SelectedTeam = db.Teams.Find(member.TeamID),
            SelectedTeamMember = db.TeamMembers.Find(member.TeamMemberID),
            DataEntryTarget = DataEntryTargets.TeamMembers,
            DataDisplayMode = DataDisplayModes.Read
         };

         db.Entry(model.SelectedTeam).Collection(team => team.Members).Load();

         return View("Main", model);
      }

      [HttpPost]
      public IActionResult CancelEntry(int teamId)
      {
         MasterDetailViewModel model = new MasterDetailViewModel
         {
            Teams = db.Teams.ToList(),
            SelectedTeam = db.Teams.Find(teamId),
            SelectedTeamMember = null,
            DataEntryTarget = DataEntryTargets.TeamMembers,
            DataDisplayMode = DataDisplayModes.Read
         };

         db.Entry(model.SelectedTeam).Collection(team => team.Members).Load();

         return View("Main", model);
      }

      [HttpPost]
      public IActionResult CancelSelection(int teamId)
      {
         MasterDetailViewModel model = new MasterDetailViewModel
         {
            Teams = db.Teams.ToList(),
            SelectedTeam = db.Teams.Find(teamId),
            SelectedTeamMember = null,
            DataEntryTarget = DataEntryTargets.TeamMembers,
            DataDisplayMode = DataDisplayModes.Read
         };

         db.Entry(model.SelectedTeam).Collection(team => team.Members).Load();

         return View("Main", model);
      }

      [HttpPost]
      public IActionResult Delete(int teamId, int memberId)
      {
         TeamMember member = db.TeamMembers.Find(memberId);
         db.TeamMembers.Remove(member);
         db.SaveChanges();

         MasterDetailViewModel model = new MasterDetailViewModel
         {
            Teams = db.Teams.ToList(),
            SelectedTeam = db.Teams.Find(teamId),
            SelectedTeamMember = null,
            DataEntryTarget = DataEntryTargets.TeamMembers,
            DataDisplayMode = DataDisplayModes.Read
         };

         db.Entry(model.SelectedTeam).Collection(team => team.Members).Load();

         return View("Main", model);
      }

   }
}
