using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestTest.Model
{
    public class states
    {
        public int id { get; set; }

        public string States { get; set; }
      
        public  List<Rooms> rooms { get; set; }

    }
}
