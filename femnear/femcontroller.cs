using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace femnear
{
    [Route("api/[controller]")]
    [ApiController]
    public class DatapersonenController : ControllerBase

    {
        private readonly femContext _context;

        //VOOR URL TE KRIJGEN KIJK NAAR "api" lijn 7 en na de / kanj op lijn 15 woord voor "controller" achte rkrijgen TOETS 19/03
        public DatapersonenController(femContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Datapersonen>>> GetStudents()
        {
            return await _context.Datapersonen.ToListAsync();
        }

    }
}
