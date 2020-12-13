using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using schedule_backend.Models;

namespace schedule_backend.Controllers
{
    [Route("api/schedule")]
    [ApiController]
    public class ScheduleController : ControllerBase
    {
        private readonly Data.TaskApiContext dbContext;

        public ScheduleController(Data.TaskApiContext context)
        {
            dbContext = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ResultTask>>> List()
        {
            var TaskList = await dbContext.Tasks.ToListAsync();
            List<ResultTask> result = new List<ResultTask>();
            foreach (var t in TaskList)
            {
                result.Add(t.ToResult());
            }
            return result.ToArray();
        }

        [HttpPost]
        public async Task<ActionResult<Models.Task>> Create([FromBody] ResultTask newTask)
        {
            Models.Task dbTask = new Models.Task() { TaskDate = new DateTime(newTask.Year, newTask.Month, newTask.Day), TaskText = newTask.Text };

            dbContext.Tasks.Add(dbTask);
            await dbContext.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete]
        [Route ("{day}/{text}")]
        public async Task<ActionResult> Delete(string day, string text)
        {
            string[] s = day.Split("_");
            Models.Task dT = new Models.Task() { TaskDate = new DateTime(Int32.Parse(s[2]), Int32.Parse(s[0]), Int32.Parse(s[1])), TaskText = text };
            var dbTask = dbContext.Tasks.FirstOrDefault(t => t.TaskDate == dT.TaskDate && t.TaskText == dT.TaskText);

            if (dbTask == null) return NotFound();

            dbContext.Tasks.Remove(dbTask);
            await dbContext.SaveChangesAsync();

            return NoContent();
        }
    }
}
