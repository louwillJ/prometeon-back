using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using prometeon_back.Data;
using prometeon_back.Models;

namespace prometeon_back.Controllers {
    [ApiController]
    [Route ("api/plantModel")]
    public class PlantModelController : ControllerBase {
        [HttpGet]
        [Route ("")]

        public async Task<ActionResult<List<PlantModel>>> Get ([FromServices] DataContext context) {
            try {
                // var plantModels = (from org in context.MD_ORGANIZATIONAL_ITEM join itemUp in context.MD_ORGANIZATIONAL_ITEM on org.ORG_ID_ITEM_UP equals itemUp.ORG_ID select new PlantModel {
                //     ORG_ID = org.ORG_ID,
                //         ORG_NAME = org.ORG_NAME,
                //         ORG_ID_ITEM_UP = org.ORG_ID_ITEM_UP,
                //         ORG_ACTIVE = org.ORG_ACTIVE,
                //         ORG_DESCRIPTION = org.ORG_DESCRIPTION,
                //         ELE_ID = org.ELE_ID,
                //         ItemUp = itemUp != null ? itemUp : org
                // }).ToListAsync ();

                var pl = await context.MD_ORGANIZATIONAL_ITEM.ToListAsync ();

                foreach (var t in pl) {
                    t.ItemUp = context.MD_ORGANIZATIONAL_ITEM.FirstOrDefault (x => x.ORG_ID == t.ORG_ID_ITEM_UP);
                }

                return pl;
                // return await plantModels;
            } catch (System.Exception ex) {
                return StatusCode (500, ex.Message);
            }

        }

        [HttpGet]
        [Route ("{id:long}")] // nivel/

        public async Task<ActionResult<List<PlantModel>>> GetByNivelId ([FromServices] DataContext context, long id) {
            try {
                var plantModel = await context.MD_ORGANIZATIONAL_ITEM.Where (x => x.ELE_ID == id).ToListAsync ();
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