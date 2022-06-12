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
    public class CountryController : ControllerBase
    {
        private readonly HotelDbContext db;

        public CountryController(HotelDbContext Db)
        {
            db = Db;
        }
        // GET: api/<CountryController>
        [HttpGet]
        public ActionResult<IEnumerable<CountryVm>> GetCountry()
        {
            // return db.Countries.ToList();
            List<Country> country = db.Countries.ToList();
            if (country == null)
            {
                return NotFound();
            }

            List<CountryVm> countries = db.Countries.Select(s => new CountryVm
            {
                Id = s.Id,
                countryName = s.countryName,
            }).ToList();
            return Ok(countries);


        }

        // GET api/<CountryController>/5
        [HttpGet("{id}")]
        public ActionResult<CountryVm> GetCountryById(int id)
        {
            Country c=db.Countries.FirstOrDefault(s=>s.Id == id);
            if(c == null)
            {
                return NotFound();
            }
            CountryVm country = new CountryVm()
            {
                Id = c.Id,
                countryName = c.countryName,
            };
            return Ok(country);

            
        }

        // POST api/<CountryController>
        [HttpPost]
        public ActionResult<CountryVm> PostCountry([FromBody] CountryVm c)
        {
            if(c == null)
            {
                return NoContent();
            }
            Country country = db.Countries.FirstOrDefault(s => s.countryName == c.countryName);
            if(country == null)
            {
                Country newCountry = new Country()
                {
                    Id = c.Id,
                    countryName = c.countryName,
                };
                db.Countries.Add(newCountry);
                db.SaveChanges();
                return Ok();
            }
            return BadRequest();
        }

        // PUT api/<CountryController>/5
        [HttpPut("{id}")]
        public ActionResult<CountryVm> PutCpuntry(int id, [FromBody] CountryVm c)
        {
            Country country = db.Countries.Find(id);
            if (country != null)
            {
                if(country.Id == id)
                {
                    if (country.countryName != c.countryName&& country.Id == id)
                    {
                        country.countryName = c.countryName;
                        db.Update(country);
                        db.SaveChanges();
                        return Ok();
                    }
                    return BadRequest();
                }
                return BadRequest();
            }
          
           return NoContent();

        }

        // DELETE api/<CountryController>/5
        [HttpDelete("{id}")]
        public ActionResult<CountryVm> Delete(int id)
        {
            Country country=db.Countries.Find(id);
            if(country != null)
            {
                db.Countries.Remove(country);
                db.SaveChanges();
                return Ok();
            }
           return BadRequest();
        }
    }
}
