using System.ComponentModel.DataAnnotations.Schema;

namespace TestTest.Model
{
    public class Rooms
    {
        public int Id { get; set; }
       
        public bool booked { get; set; }
        public int Price { get; set; }

        [ForeignKey("hotel")]
        public int hotelId { get; set; }
        public Hotel hotel { get; set; }
        [ForeignKey("states")]
        public int statesId { get; set; }
        public states states { get; set; }

    }
}
