using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using prometeon_new.Data;
using prometeon_new.Models;

namespace prometeon_new.Controllers {
    [ApiController]
    [Route ("api/usuarios")]

    public class UsuarioController : ControllerBase {
        [HttpGet]
        [Route ("")]

        public async Task<ActionResult<List<Usuario>>> Get ([FromServices] DataContext context) {
            try {
                var usuarios = await context.MD_USERS.ToListAsync ();
                return usuarios;
            } catch (System.Exception ex) {
                return StatusCode (500, ex.Message);
            }

        }

        [HttpGet]
        [Route ("{id:long}")]

        public async Task<ActionResult<Usuario>> GetById ([FromServices] DataContext context, long id) {
            try {
                var usuario = await context.MD_USERS.FirstOrDefaultAsync (x => x.USR_ID == id);
                return usuario;
            } catch (System.Exception ex) {
                return StatusCode (500, ex.Message);
            }

        }

        [HttpPost]
        [Route ("")]
        public async Task<ActionResult<Usuario>> Post (
            [FromServices] DataContext context, [FromBody] Usuario model) {
            try {
                if (ModelState.IsValid) {
                    context.MD_USERS.Add (model);
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
        public async Task<ActionResult> Put ([FromServices] DataContext context, [FromBody] Usuario model, long id) {
            if (id != model.USR_ID) {
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
        public async Task<ActionResult<Usuario>> Delete ([FromServices] DataContext context, long id) {
            try {
                var user = await context.MD_USERS.FindAsync (id);
                if (user == null) {
                    return NotFound ();
                }

                context.MD_USERS.Remove (user);
                await context.SaveChangesAsync ();
                return Ok (user);

            } catch (System.Exception ex) {
                return StatusCode (500, ex.Message);
            }
        }
    }
}