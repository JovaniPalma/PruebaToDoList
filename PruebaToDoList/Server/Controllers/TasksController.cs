using Microsoft.AspNetCore.Mvc;
using PruebaToDoList.Server.DataBase;
using PruebaToDoList.Shared.Enties;

namespace PruebaToDoList.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TasksController : Controller
    {
        private readonly DataContext context;

        public TasksController(DataContext context)
        {
            this.context=context;
        }

        [HttpPost]
        public async Task<ActionResult<TaskGoal>> PostGoals(TaskGoal task)
        {
            task.Date = DateTime.Now;
            context.Tasks.Add(task);
            await context.SaveChangesAsync();
            return Ok(task);
        }

        [HttpPut]
        public async Task<ActionResult<TaskGoal>> PutGoals(TaskGoal task)
        {
            var taskDb = context.Tasks.FirstOrDefault(x => x.Id == task.Id);
            if (taskDb is null)
            {
                return NotFound();
            }

            taskDb.Name = task.Name;
            taskDb.Important = task.Important;
            taskDb.Estatus = task.Estatus;

            await context.SaveChangesAsync();

            return Ok(task);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Goal>> DeleteGoals(int id)
        {
            TaskGoal task = new()
            {
                Id = id
            };
            context.Tasks.Remove(task);
            await context.SaveChangesAsync();
            return Ok(task);
        }

        protected override void Dispose(bool disposing)
        {
            context.Dispose();
            base.Dispose(disposing);
        }
    }
}
