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
        private bool exist(string Name)
        {
            return dB.hotels.Any(s => s.hotelName == Name);
        }
        // GET: api/<HotelController>
        [HttpGet]
        public ActionResult< IEnumerable<Hotel>> GetHotels()
        {
            List<Hotel> h = dB.hotels.ToList();
            if(h != null)
                {
                List<HotelVm> hotels = h.Select(s => new HotelVm
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
        public ActionResult GetHotelById(int id)
        {
        Hotel hotel=dB.hotels.Find(id);
            if (hotel == null) { return NotFound(); }
            else { return Ok(hotel); }
          
        }

        // POST api/<HotelController>
        [HttpPost]
        public ActionResult PostHotel([FromBody] HotelVm  newHotel)
        {
            if (!exist(newHotel.hotelName))
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
        public ActionResult Put(int id, [FromBody] EditHotelVm editHotel)
        {
            Hotel hotel = dB.hotels.Find(id);
            if (hotel == null) return NotFound();
            else
            {
                if (!exist(editHotel.hotelName)) 
                {
                    hotel.hotelName = editHotel.hotelName;
                    hotel.RoomsNumber = editHotel.RoomsNumber;
                    hotel.regionId = editHotel.regionId;

                    dB.hotels.Update(hotel);
                    dB.SaveChanges();
                }
               return Ok();
            }

        }

        // DELETE api/<HotelController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            Hotel hotel =dB.hotels.Find(id);
            if (hotel == null)
            {
                return NotFound();
            }
            else { 
                dB.hotels.Remove(hotel);
                dB.SaveChanges();
                return Ok();
            }
        }
    }
}
