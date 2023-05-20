using Elevator.Business.Contracts;
using Elevator.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Elevator.Lookup.EnumsLookup;

namespace Elevator.Business.ElevatorRules
{
    public class RequestAlgorithm
    {
        /// <summary>
        /// This is a basic algorithm. Alot of complexity was excluded. No Queuing was implemented. 
        /// Only elevators that are available that is closest to the calling floor were considered.
        /// Additional rules can be added to this method based on requirements
        /// </summary>
        /// <param name="elevator"></param>
        /// <param name="callingFloor"></param>
        /// <returns></returns>
        public ElevatorCallDto DeterminNextAvailableElevator(List<IElevator> elevator, ElevatorFloor callingFloor)
        {
            var elevatorCallResponse = new ElevatorCallDto();

            var availableElevator = elevator.Where(x => x.Status == ElevatorStatus.Available).ToList().OrderBy(x => Math.Abs((int)x.CurrentFloor - (int)callingFloor)).FirstOrDefault();

            if (availableElevator == null)
            {
                elevatorCallResponse.ElevatorCallFeedback = "Current No Elevators Are Available. Please wait";
            }
            else
            {
                elevatorCallResponse.ElevatorCallFeedback = $"Elevator {availableElevator.ElevatorNumber} is being sent from {availableElevator.CurrentFloor} floor";
            }

            return elevatorCallResponse;

        }
    }
}
