using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using prometeon_new.Data;
using prometeon_new.Models;

namespace prometeon_new.Controllers
{
    [ApiController]
    [Route ("api/turno/excecoes")]
    public class TurnoExceptionController : ControllerBase
    {
        [HttpGet]
        [Route ("")]

        public async Task<ActionResult<List<TurnoException>>> Get ([FromServices] DataContext context) {
            try {
                var excecoes = await context.MD_TURNO_EXCEPTION.ToListAsync ();
                return excecoes;
            } catch (System.Exception ex) {
                return StatusCode (500, ex.Message);
            }

        }

        [HttpGet]
        [Route ("{id:long}")]

        public async Task<ActionResult<TurnoException>> GetById ([FromServices] DataContext context, long id) {
            try {
                var excecao = await context.MD_TURNO_EXCEPTION.FirstOrDefaultAsync (x => x.TUR_ID == id);
                return excecao;
            } catch (System.Exception ex) {
                return StatusCode (500, ex.Message);
            }

        }

        [HttpPost]
        [Route ("")]
        public async Task<ActionResult<TurnoException>> Post (
            [FromServices] DataContext context, [FromBody] TurnoException model) {
            try {
                if (ModelState.IsValid) {
                    context.MD_TURNO_EXCEPTION.Add (model);
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
        public async Task<ActionResult> Put ([FromServices] DataContext context, [FromBody] TurnoException model, long id) {
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
        public async Task<ActionResult<TurnoException>> Delete ([FromServices] DataContext context, long id) {
            try {
                var excecao = await context.MD_TURNO_EXCEPTION.FindAsync (id);
                if (excecao == null) {
                    return NotFound ();
                }

                context.MD_TURNO_EXCEPTION.Remove (excecao);
                await context.SaveChangesAsync ();
                return Ok (excecao);

            } catch (System.Exception ex) {
                return StatusCode (500, ex.Message);
            }
        }
    }
}