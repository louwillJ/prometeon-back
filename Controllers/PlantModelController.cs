using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using prometeon_back.Models;
using prometeon_new.Data;
using prometeon_new.Models;

namespace prometeon_back.Controllers {
    [ApiController]
    [Route ("api/plantModel")]
    public class PlantModelController : ControllerBase {
        [HttpGet]
        [Route ("")]

        public async Task<ActionResult<List<PlantModel>>> Get ([FromServices] DataContext context) {
            try {
                var plantModels = await context.MD_ORGANIZATIONAL_ITEM.ToListAsync ();
                return plantModels;
            } catch (System.Exception ex) {
                return StatusCode (500, ex.Message);
            }

        }

        [HttpGet]
        [Route ("{id:long}")]

        public async Task<ActionResult<PlantModel>> GetById ([FromServices] DataContext context, long id) {
            try {
                var plantModel = await context.MD_ORGANIZATIONAL_ITEM.FirstOrDefaultAsync (x => x.ORG_ID == id);
                return plantModel;
            } catch (System.Exception ex) {
                return StatusCode (500, ex.Message);
            }

        }

        [HttpPost]
        [Route ("")]
        public async Task<ActionResult<PlantModel>> Post (
            [FromServices] DataContext context, [FromBody] PlantModel model) {
            try {
                if (ModelState.IsValid) {
                    context.MD_ORGANIZATIONAL_ITEM.Add (model);
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
        public async Task<ActionResult> Put ([FromServices] DataContext context, [FromBody] PlantModel model, long id) {
            if (id != model.ORG_ID) {
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
        public async Task<ActionResult<PlantModel>> Delete ([FromServices] DataContext context, long id) {
            try {
                var plantModel = await context.MD_ORGANIZATIONAL_ITEM.FindAsync (id);
                if (plantModel == null) {
                    return NotFound ();
                }

                context.MD_ORGANIZATIONAL_ITEM.Remove (plantModel);
                await context.SaveChangesAsync ();
                return Ok (plantModel);

            } catch (System.Exception ex) {
                return StatusCode (500, ex.Message);
            }
        }
    }
}