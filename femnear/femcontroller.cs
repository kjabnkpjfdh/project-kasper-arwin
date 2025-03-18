using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace femnear
{
    [Route("api/[controller]")]
    [ApiController]
    public class DatapersonenController : ControllerBase

    {
        private readonly femContext _context;

        //VOOR URL TE KRIJGEN KIJK NAAR "api" lijn 6 en na de / kanj op lijn 14 woord voor "controller" achter krijgen TOETS 19/03
        public DatapersonenController(femContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Datapersonen>>> GetStudents()
        {
            return await _context.Datapersonen.ToListAsync();
        }

        [HttpPost]
        public void AddPersonen([FromBody] Datapersonen value)
        {
            var personen = value;// new MijnTabel { Naam = value.Naam };
            _context.Add(personen);
            _context.SaveChangesAsync();
        }


    }
}
