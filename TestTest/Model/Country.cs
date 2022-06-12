using Newtonsoft.Json;
using System.Collections.Generic;

namespace TestTest
{
    public class Country
    {
        public int Id { get; set; }
        public string countryName { get; set; }
        
        public virtual List<Region> Regions { get; set; }

    }
}
