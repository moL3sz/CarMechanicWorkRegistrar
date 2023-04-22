using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WorkRegistrarAPI.Data;
using WorkRegistrarAPI.Models;
using Newtonsoft.Json.Linq;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;

namespace WorkRegistrarAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WorkflowController : Controller
    {
        // GET: WorkflowController
        private readonly PitStopContext _context;
        private readonly ILogger<WorkflowController> _logger;

        public WorkflowController(PitStopContext context, ILogger<WorkflowController> logger)
        {
            _context = context;
            _logger = logger;
        }



        [HttpGet]
        public async Task<List<Workflow>> GetWorkflows()
        {
            List<Workflow> workflows = await _context.Workflows.Where(x => x.Active).ToListAsync();

            return workflows;
        }


        // POST: WorkflowController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Insert(Workflow workflow)
        {

            this._logger.LogInformation($"[*] Insert begin with values: {JsonSerializer.Serialize(workflow)}");
            try
            {
                workflow.Active = true;
                workflow.CreatedDate = DateTime.Now;



                await this._context.AddAsync(workflow);
                await this._context.SaveChangesAsync();


                return Ok();
            }
            catch (Exception ex)
            {
                this._logger.LogError($"[-] Insert failed with values: {JsonSerializer.Serialize(workflow)}", ex);

                return this.BadRequest(500);
            }
        }

        // POST: WorkflowController/Edit/5
        [HttpPut]
        [ValidateAntiForgeryToken]
        public ActionResult Update(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return BadRequest(500);

            }
        }

        // POST: WorkflowController/Delete/5
        [HttpDelete]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return BadRequest(500);
            }
        }
    }
}
