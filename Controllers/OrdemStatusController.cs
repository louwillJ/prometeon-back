using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using prometeon_back.Data;
using prometeon_back.Models;

namespace prometeon_back.Controllers {
    [ApiController]
    [Route ("api/op_status")]

    public class OrdemStatusController : ControllerBase {
        [HttpGet]
        [Route ("")]

        public async Task<ActionResult<List<OrdemStatus>>> Get ([FromServices] DataContext context) {
            try {
                var ordemStatus = await context.MD_PRODUCTION_ORDER_STATUS.ToListAsync ();

                return ordemStatus;
            } catch (System.Exception ex) {
                return StatusCode (500, ex.Message);
            }

        }

        [HttpGet]
        [Route ("{id:long}")]

        public async Task<ActionResult<OrdemStatus>> GetById ([FromServices] DataContext context, long id) {
            try {
                var ordemStatus = await context.MD_PRODUCTION_ORDER_STATUS.FirstOrDefaultAsync (x => x.STA_ID == id);
                return ordemStatus;
            } catch (System.Exception ex) {
                return StatusCode (500, ex.Message);
            }

        }

        [HttpPost]
        [Route ("")]
        public async Task<ActionResult<OrdemStatus>> Post (
            [FromServices] DataContext context, [FromBody] OrdemStatus model) {
            try {
                if (ModelState.IsValid) {
                    context.MD_PRODUCTION_ORDER_STATUS.Add (model);
                    await context.SaveChangesAsync ();
                    return model;
                } else {
                    return BadRequest (ModelState);
                }
            } catch (System.Exception ex) {
                return StatusCode (500, ex.Message);
            }
        }

        [HttpPut]
        [Route ("{id:long}")]
        public async Task<ActionResult> Put ([FromServices] DataContext context, [FromBody] OrdemStatus model, long id) {
            if (id != model.STA_ID) {
                return BadRequest ();
            }

            try {
                if (ModelState.IsValid) {
                    context.Update (model);
                    await context.SaveChangesAsync ();
                    return Ok (model);
                } else {
                    return BadRequest (ModelState);
                }
            } catch (System.Exception ex) {
                return StatusCode (500, ex.Message);
            }

        }

        [HttpDelete]
        [Route ("{id:long}")]
        public async Task<ActionResult<OrdemStatus>> Delete ([FromServices] DataContext context, long id) {
            try {
                var ordemStatus = await context.MD_PRODUCTION_ORDER_STATUS.FindAsync (id);
                if (ordemStatus == null) {
                    return NotFound ();
                }

                context.MD_PRODUCTION_ORDER_STATUS.Remove (ordemStatus);
                await context.SaveChangesAsync ();
                return Ok (ordemStatus);

            } catch (System.Exception ex) {
                return StatusCode (500, ex.Message);
            }
        }
    }
}