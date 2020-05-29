using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using prometeon_new.Data;
using prometeon_new.Models;

namespace prometeon_new.Controllers {
    [ApiController]
    [Route ("api/turnos")]
    public class TurnoController : ControllerBase {
        [HttpGet]
        [Route ("")]

        public async Task<ActionResult<List<Turno>>> Get ([FromServices] DataContext context) {
            try {
                var turnos = await context.MD_TURNO.ToListAsync ();
                return turnos;
            } catch (System.Exception ex) {
                return StatusCode (500, ex.Message);
            }

        }

        [HttpGet]
        [Route ("{id:long}")]

        public async Task<ActionResult<Turno>> GetById ([FromServices] DataContext context, long id) {
            try {
                var turno = await context.MD_TURNO.FirstOrDefaultAsync (x => x.TUR_ID == id);
                return turno;
            } catch (System.Exception ex) {
                return StatusCode (500, ex.Message);
            }

        }

        [HttpPost]
        [Route ("")]
        public async Task<ActionResult<Turno>> Post (
            [FromServices] DataContext context, [FromBody] Turno model) {
            try {
                if (ModelState.IsValid) {
                    context.MD_TURNO.Add (model);
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
        public async Task<ActionResult> Put ([FromServices] DataContext context, [FromBody] Turno model, long id) {
            if (id != model.TUR_ID) {
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
        public async Task<ActionResult<Turno>> Delete ([FromServices] DataContext context, long id) {
            try {
                var turno = await context.MD_TURNO.FindAsync (id);
                if (turno == null) {
                    return NotFound ();
                }

                context.MD_TURNO.Remove (turno);
                await context.SaveChangesAsync ();
                return Ok (turno);

            } catch (System.Exception ex) {
                return StatusCode (500, ex.Message);
            }
        }
    }
}