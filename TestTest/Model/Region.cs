using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestTest
{
    public class Region
    {
        public int Id { get; set; }
        public string regionName { get; set; }
        [ForeignKey("Country")]
        public int countryId { get; set; }
       
        public virtual Country Country { get; set; }
        public virtual List<Hotel> Hotels { get; set; }
    }
}
