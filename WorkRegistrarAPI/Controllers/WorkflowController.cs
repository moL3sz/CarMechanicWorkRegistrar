namespace WorkRegistrarAPI.Controllers
{
    using System.Text.Json;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using WorkRegistrarAPI.Data;
    using WorkRegistrarAPI.Enums;
    using WorkRegistrarAPI.Models;
    using WorkRegistrarAPI.Extensions;

    [ApiController]
    [Route("api/[controller]/[action]")]
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

        /// <summary>
        ///  Lapozhatóssággal ellátva visszaadja a tábla adott oldali állapotát.
        /// </summary>
        /// <param name="options"></param>
        /// <returns>Az adott szakasz a tábla valós állapotráról.</returns>
        [HttpPost]
        public async Task<List<Workflow>> GetWorkflows(DataLoaderOptions options)
        {
            List<Workflow> workflows = await _context.Workflows.Where(x => x.Active).ToListAsync();

            if (options.Orderfield != null)
            {
                workflows = workflows.OrderBy(options.Orderfield).ToList();
            }

            if (options.OrderDescand)
            {
                workflows.Reverse();
            }

            return workflows
                .Skip((options.PageNumber - 1) * options.PageSize)
                .Take(options.PageSize)
                .ToList();
        }

        /// <summary>
        /// Vissza adja hogy összes mennyi record van az adatzbázisban -> azért hogy ki tudjuk kliens oldalon számolni mennyi page gomb kerüljön majd fel.
        /// </summary>
        /// <returns>Összes record mennyisége.</returns>
        [HttpGet]
        public async Task<int> GetWorkflowSize()
        {
            return await this._context.Workflows.Where(x => x.Active).CountAsync();
        }


        [HttpGet("{id}")]
        public async Task<Workflow> GetWorkflow([FromRoute] int id)
        {
            return await _context.Workflows.FindAsync(id);
        }

        // POST: api/Workflow/Update?{workflow}
        [HttpPost]
        public async Task<IActionResult> Insert(Workflow workflow)
        {

            this._logger.LogInformation($"[*] Insert begin with values: {JsonSerializer.Serialize(workflow)}");
            try
            {

                // Set up default Genereted values
                workflow.Active = true; // this is active, means it is not deleted yet
                workflow.CreatedDate = DateTime.Now; // the creation date of the new record

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

        // POST: api/Workflow/Update?{workflow}
        [HttpPut]
        public async Task<ActionResult> Update(Workflow workflow)
        {
            this._logger.LogInformation($"[*] Update begin with values: {JsonSerializer.Serialize(workflow)}");

            try
            {

                // set up new w
                this._context.Update(workflow);
                await this._context.SaveChangesAsync();
                return this.Ok(workflow);

            }
            catch (Exception ex)
            {
                this._logger.LogError($"[-] Update failed with values: {JsonSerializer.Serialize(workflow)}", ex);
                return this.BadRequest(500);

            }
        }

        // DELETE: api/Workflow/Delete/
        [HttpDelete("{workflowId}")]
        public async Task<IActionResult> Delete(int workflowId)
        {
            this._logger.LogInformation($"[*] Delete begin with ID: {workflowId}");

            try
            {
                Workflow? currentWorkflow = await _context.Workflows.FindAsync(workflowId);
                if (currentWorkflow == null)
                {
                    this._logger.LogError($"Workflow not found with ID: {workflowId}");
                    return BadRequest(500);
                }

                currentWorkflow.Active = false;

                _context.Update(currentWorkflow);
                await this._context.SaveChangesAsync();

                return Ok();
            }
            catch
            {
                this._logger.LogInformation($"[*] Delete failed with ID: {workflowId}");

                return BadRequest(500);
            }
        }

        // PUT: api/Workflow/UpdateStatus/5
        [HttpPut("{workflowId}")]
        public async Task<IActionResult> UpdateStatus([FromRoute] int workflowId)
        {
            try
            {
                Workflow? currentWorkflow = await _context.Workflows.FindAsync(workflowId);

                if (currentWorkflow == null)
                {
                    this._logger.LogError($"Workflow not found with ID: {workflowId}");
                    return BadRequest(404);
                }

                // If the project is not in the DONE state, it will send to the next state
                currentWorkflow.WorkStatus = ((int)currentWorkflow.WorkStatus) + 1 <= 2 ?
                    (WorkStatus)((int)currentWorkflow.WorkStatus) + 1 :
                     WorkStatus.DONE;

                _context.Update(currentWorkflow);
                await this._context.SaveChangesAsync();
                return Ok(currentWorkflow);

            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.Message, ex);
                return BadRequest(500);
            }
;
        }
    }
}
