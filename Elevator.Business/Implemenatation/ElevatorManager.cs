using Elevator.Business.Contracts;
using Elevator.Business.ElevatorRules;
using Elevator.Dto;
using Elevator.Lookup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Elevator.Lookup.EnumsLookup;

namespace Elevator.Business
{
    public class ElevatorManager : IElevatorManager
    {
        private List<IElevator> _elevatorList = new List<IElevator>();
        public ElevatorManager()
        {
            InitialiseElevators();
        }

        public ElevatorManager(List<IElevator> elevators)
        {
            _elevatorList= elevators;
        }

        /// <summary>
        /// This method is used to simulate a call to an elevator. This is equivalent to pressing the up or down button when waiting for a lift.
        /// </summary>
        /// <param name="currentFloor"></param>
        /// <param name="destinationFloor"></param>
        /// <param name="occupants"></param>
        public ElevatorCallDto CallElevator(ElevatorFloor callingFloor, ElevatorFloor destinationFloor, int occupants)
        {
            var requestAlgorithm = new RequestAlgorithm();

            return requestAlgorithm.DeterminNextAvailableElevator(_elevatorList, callingFloor);
        }
       
        public List<IElevator> ElevatorStatus()
        {
            return _elevatorList;
        }

        /// <summary>
        /// This initialises the Elevators. Currently a hard coded list. 
        /// </summary>
        private void InitialiseElevators()
        {
            var floor = RandomElevator.RandomFloor();

            _elevatorList.AddRange(new List<IElevator>
            {
                new Elevator
                {
                    ElevatorNumber=1,
                    CurrentFloor=RandomElevator.RandomFloor(),
                    DestinationFloor=RandomElevator.RandomFloor(),
                    Status=EnumsLookup.ElevatorStatus.Up,
                    Occupants=0
                },
                 new Elevator
                {
                    ElevatorNumber=2,
                    CurrentFloor=floor,
                    DestinationFloor=floor,
                    Status=EnumsLookup.ElevatorStatus.Available,
                    Occupants=3
                },
                new Elevator
                {
                    ElevatorNumber=3,
                    CurrentFloor=RandomElevator.RandomFloor(),
                    DestinationFloor=RandomElevator.RandomFloor(),
                    Status=EnumsLookup.ElevatorStatus.Down,
                    Occupants=1
                }
            });
        }
    }
}
