using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PruebaToDoList.Server.DataBase;
using PruebaToDoList.Shared.Enties;

namespace PruebaToDoList.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GoalsController : Controller
    {
        private readonly DataContext context;

        public GoalsController(DataContext context)
        {
            this.context=context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Goal>>> GetGoals()
        {
            return await context.Goals.Include(x => x.Tasks).ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Goal>> PostGoals(Goal goal)
        {
            goal.Date = DateTime.Now;
            context.Goals.Add(goal);
            await context.SaveChangesAsync();
            return Ok(goal);
        }

        [HttpPut]
        public async Task<ActionResult<IEnumerable<Goal>>> PutGoals(Goal goal)
        {
            var goalDb = context.Goals.FirstOrDefault(x => x.Id == goal.Id);
            if (goalDb is null)
            {
                return NotFound();
            }

            goalDb.Name = goal.Name;

            await context.SaveChangesAsync();

            return Ok(goal);
        }

        [HttpDelete]
        public async Task<ActionResult<Goal>> DeleteGoals(Goal goal)
        {
            context.Goals.Remove(goal);
            await context.SaveChangesAsync();
            return Ok(goal);
        }

        protected override void Dispose(bool disposing)
        {
            context.Dispose();
            base.Dispose(disposing);
        }
    }
}
