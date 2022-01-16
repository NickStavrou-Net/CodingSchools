using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestMasterDetail.DataAccess;
using TestMasterDetail.Models;

namespace TestMasterDetail.Controllers
{
   public class TeamsController : Controller
   {
      private readonly AppDbContext db;

      public TeamsController(AppDbContext db)
      {
         this.db = db;
      }

      /* public IActionResult Index()
      {
         return View();
      }
      */
      public IActionResult List()
      {
         MasterDetailViewModel model = new MasterDetailViewModel
         {
            Teams = db.Teams.ToList(),
            SelectedTeam = null,
            SelectedTeamMember = null,
            DataEntryTarget = DataEntryTargets.Teams,
            DataDisplayMode = DataDisplayModes.Read
         };
         return View("Main", model);
      }

      [HttpPost]
      public IActionResult Select(int teamId)
      {
         MasterDetailViewModel model = new MasterDetailViewModel
         {
            Teams = db.Teams.ToList(),
            SelectedTeam = db.Teams.Find(teamId),
            SelectedTeamMember = null,
            DataEntryTarget = DataEntryTargets.Teams,
            DataDisplayMode = DataDisplayModes.Read
         };

         return View("Main", model);
      }

      [HttpPost]
      public IActionResult InsertEntry()
      {
         MasterDetailViewModel model = new MasterDetailViewModel
         {
            Teams = db.Teams.ToList(),
            SelectedTeam = null,
            SelectedTeamMember = null,
            DataEntryTarget = DataEntryTargets.Teams,
            DataDisplayMode = DataDisplayModes.Insert
         };
         return View("Main", model);
      }

      [HttpPost]
      public IActionResult InsertSave(Team team)
      {
         db.Teams.Add(team);
         db.SaveChanges();

         MasterDetailViewModel model = new MasterDetailViewModel
         {
            Teams = db.Teams.ToList(),
            //SelectedTeam = db.Teams.Find(team.TeamID),
            SelectedTeam = null,
            SelectedTeamMember = null,
            DataEntryTarget = DataEntryTargets.Teams,
            DataDisplayMode = DataDisplayModes.Read
         };

         return View("Main", model);
      }

      [HttpPost]
      public IActionResult UpdateEntry(int teamId)
      {
         MasterDetailViewModel model = new MasterDetailViewModel
         {
            Teams = db.Teams.ToList(),
            SelectedTeam = db.Teams.Find(teamId),
            SelectedTeamMember = null,
            DataEntryTarget = DataEntryTargets.Both,
            DataDisplayMode = DataDisplayModes.Update
         };

         db.Entry(model.SelectedTeam).Collection(team => team.Members).Load();

         return View("Main", model);
      }


      [HttpPost]
      public IActionResult UpdateSave(Team team)
      {
         db.Teams.Update(team);
         db.SaveChanges();

         MasterDetailViewModel model = new MasterDetailViewModel
         {
            Teams = db.Teams.ToList(),
            SelectedTeam = team,
            SelectedTeamMember = null,
            DataEntryTarget = DataEntryTargets.Teams,
            DataDisplayMode = DataDisplayModes.Read
         };
         return View("Main", model);
      }

      [HttpPost]
      public IActionResult Delete(int teamId)
      {
         Team team = db.Teams.Find(teamId);
         db.Teams.Remove(team);
         db.SaveChanges();

         MasterDetailViewModel model = new MasterDetailViewModel
         {
            Teams = db.Teams.ToList(),
            SelectedTeam = null,
            SelectedTeamMember = null,
            DataEntryTarget = DataEntryTargets.Teams,
            DataDisplayMode = DataDisplayModes.Read
         };
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
            DataEntryTarget = DataEntryTargets.Teams,
            DataDisplayMode = DataDisplayModes.Read
         };
         return View("Main", model);
      }

      [HttpPost]
      public IActionResult CancelSelection()
      {
         MasterDetailViewModel model = new MasterDetailViewModel
         {
            Teams = db.Teams.ToList(),
            SelectedTeam = null,
            SelectedTeamMember = null,
            DataEntryTarget = DataEntryTargets.Teams,
            DataDisplayMode = DataDisplayModes.Read
         };
         return View("Main", model);
      }

   }
}
