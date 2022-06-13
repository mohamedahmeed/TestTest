using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TestTest.VM;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TestTest.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        private readonly HotelDbContext dB;

        public HotelController(HotelDbContext DB )
        {
            dB = DB;
        }
        // GET: api/<HotelController>
        [HttpGet]
        public ActionResult< IEnumerable<Hotel>> GetHotels()
        {
            List<Hotel> h = dB.hotels.ToList();
            if(h != null)
                {
                List<HotelVm> hotels = dB.hotels.Select(s => new HotelVm
                {
                    Id = s.Id,
                    hotelName = s.hotelName,
                    RoomsNumber=s.RoomsNumber,
                    regionId=s.regionId
                }).ToList();
                return Ok(hotels);
            }
            return NotFound();
            
         
        }

        // GET api/<HotelController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<HotelController>
        [HttpPost]
        public ActionResult PostHotel([FromBody] HotelVm  newHotel)
        {
            if (dB.hotels.FirstOrDefault(h => h.hotelName == newHotel.hotelName) == null)
            {
              Hotel newone= new Hotel()
              {
                  Id=newHotel.Id,   
                  hotelName=newHotel.hotelName,
                  RoomsNumber=newHotel.RoomsNumber,
                  regionId=newHotel.regionId
              };
                dB.hotels.Add(newone);
                dB.SaveChanges();
                return Ok();
            }
            return BadRequest();

        }

        // PUT api/<HotelController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<HotelController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
