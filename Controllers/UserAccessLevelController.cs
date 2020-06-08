using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using prometeon_back.Data;
using prometeon_back.Models;

namespace prometeon_back.Controllers {
    [ApiController]
    [Route ("api/nivelAcesso")]
    public class UserAccessLevelController : ControllerBase {
        [HttpGet]
        [Route ("")]

        public async Task<ActionResult<List<UserAccessLevel>>> Get ([FromServices] DataContext context) {
            try {
                var niveisAcesso = await context.MD_ACCESS_LEVEL.ToListAsync ();
                return niveisAcesso;
            } catch (System.Exception ex) {
                return StatusCode (500, ex.Message);
            }

        }
    }
}