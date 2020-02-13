using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Device.Location;

namespace PickaPlace
{
    public class Location
    {
        private GeoCoordinate coordinates;

        public double Longitude { get { return coordinates.Longitude; } set { coordinates.Longitude = value; } }
        public double Latitude { get { return coordinates.Latitude; } set { coordinates.Latitude = value; } }

        public Location() { coordinates = new GeoCoordinate(); }

        public Location(double latitude, double longitude) {coordinates = new GeoCoordinate(latitude, longitude);}

        // Operator + that add 2 locations
        public static Location operator + (Location loc1, Location loc2)
        {
            Location resultLocation = new Location();

            resultLocation.Longitude = loc1.Longitude + loc2.Longitude;
            resultLocation.Latitude = loc1.Latitude + loc2.Latitude;

            return resultLocation;
        }

        // Operator - that subtract 2 locations
        public static Location operator -(Location loc1, Location loc2)
        {
            Location resultLocation = new Location();

            resultLocation.Longitude = loc1.Longitude - loc2.Longitude;
            resultLocation.Latitude = loc1.Latitude - loc2.Latitude;

            return resultLocation;
        }

        // Multiply with a scalar
        public static Location operator * (Location loc, double scale)
        {
            Location result = new Location();

            result.Longitude = loc.Longitude * scale;
            result.Latitude = loc.Latitude * scale;

            return result;
        }

        public double Distance(Location loc1, Location loc2)
        {
            Location diff = loc1 - loc2;
            return Math.Sqrt(Math.Pow(diff.Longitude, 2) + Math.Pow(diff.Latitude, 2));
        }
    }

    public class ListOfLocations
    {
        // The list of locations
        private List<Location> locations;
        
        // The number of locations in list
        public int Count
        {
            get { return locations.Count; }
        }

        // Default constructor
        public ListOfLocations()
        {
            locations = new List<Location>();
        }

        // Add a location to the list
        public void AddLocation(Location location)
        {
            locations.Add(location);
        }

        // Get the centroid of the list
        public Location GetCentroid()
        {
            Location result = new Location();

            foreach (Location location in locations)
            {
                result = result + location;
            }

            result = result * (1 / Count);

            return result;
        }
    
        // Result when apply a list of weights to the list of location
        // result = locations * weights (componentwise)
        public Location ApplyWeightedList(List<double> weights)
        {
            Location result = new Location();

            // need to assert if weights.count is the same as Count
            Debug.Assert(weights.Count == Count, "Number of weights must equal number of locations in ListOfLocations.ApplyWeightedList");

            foreach (var item in locations.Zip(weights, (location, weight) => new Tuple<Location, double>(location, weight)))
            {
                result = result + (item.Item1 * item.Item2);
            }

            return result;
        }

    }

}
