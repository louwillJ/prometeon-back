using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using prometeon_back.Data;
using prometeon_back.Models;

namespace prometeon_back.Controllers {
    [ApiController]
    [Route ("api/op")]

    public class OrdemProducaoController : ControllerBase {
        [HttpGet]
        [Route ("")]

        public async Task<ActionResult<List<OrdemProducao>>> Get ([FromServices] DataContext context) {
            try {
                var ordemProducao = await context.MD_PRODUCTION_ORDER.ToListAsync ();
                //list.Add(Convert.ToString(myReader["Date"]));

                return ordemProducao;
            } catch (System.Exception ex) {
                return StatusCode (500, ex.Message);
            }

        }

        [HttpGet]
        [Route ("{id:long}")]

        public async Task<ActionResult<OrdemProducao>> GetById ([FromServices] DataContext context, long id) {
            try {
                var ordemProducao = await context.MD_PRODUCTION_ORDER.FirstOrDefaultAsync (x => x.ORD_ID == id);
                return ordemProducao;
            } catch (System.Exception ex) {
                return StatusCode (500, ex.Message);
            }

        }

        [HttpPost]
        [Route ("")]
        public async Task<ActionResult<OrdemProducao>> Post (
            [FromServices] DataContext context, [FromBody] OrdemProducao model) {
            try {
                if (ModelState.IsValid) {
                    context.MD_PRODUCTION_ORDER.Add (model);
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
        public async Task<ActionResult> Put ([FromServices] DataContext context, [FromBody] OrdemProducao model, long id) {
            if (id != model.ORD_ID) {
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
        public async Task<ActionResult<OrdemProducao>> Delete ([FromServices] DataContext context, long id) {
            try {
                var ordemProducao = await context.MD_PRODUCTION_ORDER.FindAsync (id);
                if (ordemProducao == null) {
                    return NotFound ();
                }

                context.MD_PRODUCTION_ORDER.Remove (ordemProducao);
                await context.SaveChangesAsync ();
                return Ok (ordemProducao);

            } catch (System.Exception ex) {
                return StatusCode (500, ex.Message);
            }
        }
    }
}