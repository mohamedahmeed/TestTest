using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using TestTest.VM;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TestTest.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionController : ControllerBase
    {
        private readonly HotelDbContext db;

        public RegionController(HotelDbContext db)
        {
            this.db = db;
        }
        // GET: api/<RegionController>
        [HttpGet]
        public ActionResult<IEnumerable<RegionVm>> GetRegions()
        {
            List<Region> regions1 = db.regions.Include(s=>s.Country).ToList();
            if (regions1 == null)
            {
                return NoContent();
            }
            List<Country> cc = db.Countries.ToList();
            List<RegionVm> regions = db.regions.Select(r => new RegionVm
            {
            Id = r.Id,
                countryId = r.countryId,
                regionName = r.regionName,
                t=r.Country.countryName,
                countries=cc,


            }).ToList();
            return Ok(regions);

        }

        // GET api/<RegionController>/5
        [HttpGet("{id}")]
        public ActionResult<RegionVm> GetRegionById(int id)
        {
            Region region = db.regions.Include(s => s.Country).Where(s=>s.Id==id).FirstOrDefault();
            if (region == null)
            {
                return NoContent();
            }
            List<Country> cc = db.Countries.ToList();
            RegionVm vm = new RegionVm()
            {
                countryId = region.countryId,
                Id=region.Id,
                regionName = region.regionName,
               countries=cc,
            };
            return Ok(vm);
        }
       
        // POST api/<RegionController>
        [HttpPost]
        public ActionResult<RegionVm> PostRegion( addRegionVm r)
        {
            Region region=db.regions.FirstOrDefault(s=>s.regionName==r.regionName);
            if(region == null)
            {
                Region vm = new Region()
                {
                    Id=r.Id,
                    regionName = r.regionName,
                    countryId=r.countryId,
                };
                db.regions.Add(vm);
                db.SaveChanges();
                return Ok();
            }
            return BadRequest();
        }

        // PUT api/<RegionController>/5
        [HttpPut("{id}")]
        public ActionResult<RegionVm> PutRegion(int id, [FromBody] RegionVm r)
        {
            Region rr = db.regions.Find(id);
            if(rr!= null)
            {
                if (rr.regionName != r.regionName&&rr.Id!=r.Id)
                {
                    rr.regionName = r.regionName;
                    rr.countryId = r.countryId;
                  
                    //rr.Country = r.Country;// كان ناقص
                    db.Update(rr);
                    db.SaveChanges();
                    return Ok();
                }
                return BadRequest();
            }
           
            return NotFound();
        }

        // DELETE api/<RegionController>/5
        [HttpDelete("{id}")]
        public ActionResult<RegionVm> Delete(int id)
        {
            Region Re = db.regions.Find(id);
            if (Re != null)
            {
                db.regions.Remove(Re);
                db.SaveChanges();
                return Ok();
            }
            return BadRequest();
        }
    }
}
