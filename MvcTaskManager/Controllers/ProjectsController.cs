using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using MvcTaskManager.Models;

namespace MvcTaskManager.Controllers
{
    [EnableCors("MyPolicy")]
  
    public class ProjectsController : Controller
    {

        [HttpGet]
        [Route("api/projects")]
        public List<Project> GetAllProjects()
        {
            TaskManagerDbContext db = new TaskManagerDbContext();
            List<Project> projects = db.Projects.ToList();
            return projects;
        }

        [HttpPost]
        [Route("api/projects")]
        public Project Post([FromBody] Project project)
        {
            TaskManagerDbContext db = new TaskManagerDbContext();
            db.Projects.Add(project);
            db.SaveChanges();
            return project;
        }

        [HttpPut]
        [Route("api/projects")]
        public IActionResult UpdateProject([FromBody] Project project)
        {
            TaskManagerDbContext db = new TaskManagerDbContext();
            var _project = db.Projects.Where(x => x.ProjectID == project.ProjectID).FirstOrDefault();
            if (_project != null)
            {
                _project.ProjectName = project.ProjectName;
                _project.DateOfStart = project.DateOfStart;
                _project.TeamSize = project.TeamSize;
                db.SaveChanges();
                return Json(project);
            }

            return NotFound(project);

        }


        [HttpDelete]
        [Route("api/projects")]
        [ActionName("DeleteProject")]
        public IActionResult DeleteProject(int Id)
        {
            TaskManagerDbContext db = new TaskManagerDbContext();
            var _project = db.Projects.Where(x => x.ProjectID == Id).FirstOrDefault();
            if (_project != null)
            {
                db.Projects.Remove(_project);
                db.SaveChanges();
                return Ok(Id);
            }

            return NotFound(Id);

        }

        [HttpGet]
        [Route("api/projects/search/{searchby}/{searchtext}")]
        public List<Project>Search(string searchBy, string searchText)
        {
            TaskManagerDbContext db = new TaskManagerDbContext();
            List<Project> projects = null;

            if(searchBy =="ProjectId")
            {
                projects = db.Projects.Where(x => x.ProjectID.ToString().Contains(searchText)).ToList();
            }
            if (searchBy == "ProjectName")
            {
                projects = db.Projects.Where(x => x.ProjectName.ToString().Contains(searchText)).ToList();
            }
            if (searchBy == "DateOfStart")
            {
                projects = db.Projects.Where(x => x.DateOfStart.ToString().Contains(searchText)).ToList();
            }
            if (searchBy == "TeamSize")
            {
                projects = db.Projects.Where(x => x.TeamSize.ToString().Contains(searchText)).ToList();
            }

            return projects;
        }
    }

    
    
}


