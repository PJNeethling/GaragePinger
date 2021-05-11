using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ParkBee.Assessment.API.Models
{
    public class Garage
    {
        [Key]
        public int ID { get; set; }

        public string Name { get; set; }
        public string Address { get; set; }
        public int StatusTypeID { get; set; }

        public Doors Doors { get; set; }
    }
}
