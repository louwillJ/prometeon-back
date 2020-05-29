// using System.Collections.Generic;
// using System.Threading.Tasks;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.EntityFrameworkCore;
// using prometeon_new.Data;

// namespace prometeon_new.Controllers {
//     [ApiController]
//     [Route ("api/plantModel")]
//     public class PlantModel : ControllerBase{
//         [HttpGet]
//         [Route ("")]

//         public async Task<ActionResult<List<PlantModel>>> Get ([FromServices] DataContext context) {
//             var usuarios = await context.Usuarios.ToListAsync ();
//             return usuarios;
//         }
//     }
// }