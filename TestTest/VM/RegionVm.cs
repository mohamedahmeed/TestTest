﻿using System.Collections.Generic;
using Newtonsoft.Json;

namespace TestTest.VM
{
    public class RegionVm
    {
        public int Id { get; set; }
        public string regionName { get; set; }
        public int countryId { get; set; }
        public string t { get; set; }
        
        public List<Country> countries { get; set; }


    }
}
