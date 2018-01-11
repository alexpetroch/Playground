using System;
using System.Collections.Generic;

namespace Playground.OOD
{
    #pragma warning disable CS0169

    class ParkLot
    {
        Dictionary<VehicleSize, Queue<Place>> lotQueue = new Dictionary<VehicleSize, Queue<Place>>();
        List<Place> allPlaces = new List<Place>();

        ParkLot()
        {
            allPlaces.Add(new Place(1, VehicleSize.Small));
            allPlaces.Add(new Place(2, VehicleSize.Small));
            allPlaces.Add(new Place(3, VehicleSize.Med));
            allPlaces.Add(new Place(4, VehicleSize.Med));
            allPlaces.Add(new Place(5, VehicleSize.Med));
            allPlaces.Add(new Place(6, VehicleSize.Large));

            lotQueue.Add(VehicleSize.Small, new Queue<Place>());
            lotQueue.Add(VehicleSize.Med, new Queue<Place>());
            lotQueue.Add(VehicleSize.Large, new Queue<Place>());

            foreach (Place pl in allPlaces)
            {
                var queue = lotQueue[pl.Size];
                queue.Enqueue(pl);
            }
        }

        public Ticket Pack(Vehicle vehicle)
        {
            return null;
        }

        public void Free(Ticket ticket)
        {
            
        }
    }

    class Vehicle
    {
        VehicleSize _vehicleSize;

        public Vehicle(int id, VehicleSize size)
        {
            _vehicleSize = size;
        }
        public VehicleSize Size => _vehicleSize;
    }    

    class Place
    {        
        int _id;
        VehicleSize _placeSize;

        public Place(int id, VehicleSize size)
        {
            _id = id;
            _placeSize = size;
        }

        public VehicleSize Size => _placeSize;
    }

    class Ticket
    {
        DateTime _created;
        Place _place;
        Vehicle _vehicle;
    }

    enum VehicleSize
    {
        Small,
        Med,
        Large
    }

}
