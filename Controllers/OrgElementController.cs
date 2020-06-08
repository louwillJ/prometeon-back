using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using prometeon_back.Data;
using prometeon_back.Models;

namespace prometeon_back.Controllers {
    [ApiController]
    [Route ("api/orgElement")]
    public class OrgElementController : ControllerBase {
        [HttpGet]
        [Route ("")]

        public async Task<ActionResult<List<OrgElement>>> Get ([FromServices] DataContext context) {
            try {
                var elOrganizacionais = await context.MD_ORGANIZATIONAL_ELEMENT.ToListAsync ();
                return elOrganizacionais;
            } catch (System.Exception ex) {
                return StatusCode (500, ex.Message);
            }

        }
    }
}