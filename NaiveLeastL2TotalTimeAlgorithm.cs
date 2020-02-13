using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace PickaPlace
{
    /// <summary>
    /// This algorithm optimizes L^2 total time 
    /// </summary>
    public class NaiveLeastL2TotalTimeAlgorithm : AbstractAlgorithm
    {
        /// <summary>
        /// Array of locations of user
        /// </summary>
        private ListOfLocations listOfLocations;

        /// <summary>
        /// Array of inverses of average speeds
        /// <summary>
        private List<double> inverse_average_speeds;

        public NaiveLeastL2TotalTimeAlgorithm()
        {
            Name = "Naive Least L2 Total Time Algorithm";
            listOfLocations = new ListOfLocations();
            inverse_average_speeds = new List<double>();
        }

        public void AddLocation(Location location)
        {
            listOfLocations.AddLocation(location);
        }

        /// <summary>
        /// Update the array inverse_average_speeds
        /// <summary>
        private void UpdateAverageSpeeds()
        {
            // Need to query from Map API
            // Need to make sure they are all non-zero
        }

        // Check if the users options are applicable to this algorithm
        private bool CheckIfOptionsAreAllowed()
        {
            return true;
        }

        public Location CalculateResult()
        {
            Debug.Assert(CheckIfOptionsAreAllowed(), "Options are invalid in NaiveLeastL2TotalTimeAlgorithm.CalculateResult.");

            Location result = new Location();

            // Update the average speeds
            UpdateAverageSpeeds();

            Debug.Assert(listOfLocations.Count == inverse_average_speeds.Count, "Number of locations must equal to number of average speeds in NaiveLeastL2TotalTimeAlgorithm.CalculateResult");

            // result = locations (dot product) (inverse average speeds)
            result = listOfLocations.ApplyWeightedList(inverse_average_speeds);

            return result;
        }
    }
}
