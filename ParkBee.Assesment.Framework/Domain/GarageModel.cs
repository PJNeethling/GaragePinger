using System.Collections.Generic;

namespace ParkBee.Assesment.Framework.Domain
{
    public class Garages : List<Garage> { }
    public class Garage
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int StatusTypeID { get; set; }
        public GarageStatuses Status => (GarageStatuses)StatusTypeID;
        public bool IsOnline => Status == GarageStatuses.Online ? true : false;

        public Doors Doors { get; set; }
    }

    public enum GarageStatuses
    {
        Unknown = 0,
        Online = 1,
        Offline = 2,
    }
}
