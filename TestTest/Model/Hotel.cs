using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using TestTest.Model;

namespace TestTest
{
    public class Hotel
    {
        public int Id { get; set; }
        public string hotelName { get; set; }
        public int RoomsNumber { get; set; }

        [ForeignKey("region")]
        public int regionId { get; set; }
        public Region region { get; set; }

        public List<Rooms> rooms  { get; set; }


    }
}
