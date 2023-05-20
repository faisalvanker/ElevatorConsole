using Elevator.Business;
using Elevator.Business.Contracts;
using Elevator.Lookup;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using static Elevator.Lookup.EnumsLookup;
using System.Collections.Generic;


namespace Elevator.Tests
{
    [TestClass]
    public class ElevatorUnitTests
    {
        [TestMethod]
        public void CallElevatorFromGroundFloorWhenAllElevatorsAreBusy()
        {
           //arrange 
           var elevatorList = new List<IElevator>
            {
                new Business.Elevator
                {
                    ElevatorNumber=1,
                    CurrentFloor=ElevatorFloor.Third,
                    DestinationFloor=ElevatorFloor.Third,
                    Status=EnumsLookup.ElevatorStatus.Up,
                    Occupants=0
                },
                 new Business.Elevator
                {
                    ElevatorNumber=2,
                    CurrentFloor=ElevatorFloor.Second,
                    DestinationFloor=ElevatorFloor.Tenth,
                    Status=EnumsLookup.ElevatorStatus.Up,
                    Occupants=3
                },
                new Business.Elevator
                {
                    ElevatorNumber=3,
                    CurrentFloor=ElevatorFloor.Sixth,
                    DestinationFloor=ElevatorFloor.Ground,
                    Status=EnumsLookup.ElevatorStatus.Down,
                    Occupants=1
                }
            };

            var expected = "Current No Elevators Are Available. Please wait";

            //act
            var manager = new ElevatorManager(elevatorList);
            var result= manager.CallElevator(Lookup.EnumsLookup.ElevatorFloor.Ground, Lookup.EnumsLookup.ElevatorFloor.Third, 8);

            //assert
            Assert.AreEqual(expected, result.ElevatorCallFeedback);
        }

        [TestMethod]
        public void CallElevatorFromTenthFloorWhenAllTwoElevatorsAreAvailable()
        {
            //arrange 
            var elevatorList = new List<IElevator>
            {
                new Business.Elevator
                {
                    ElevatorNumber=1,
                    CurrentFloor=ElevatorFloor.Ground,
                    DestinationFloor=ElevatorFloor.Ground,
                    Status=EnumsLookup.ElevatorStatus.Available,
                    Occupants=0
                },
                 new Business.Elevator
                {
                    ElevatorNumber=2,
                    CurrentFloor=ElevatorFloor.Second,
                    DestinationFloor=ElevatorFloor.Second,
                    Status=EnumsLookup.ElevatorStatus.Available,
                    Occupants=3
                },
                new Business.Elevator
                {
                    ElevatorNumber=3,
                    CurrentFloor=ElevatorFloor.Ninth,
                    DestinationFloor=ElevatorFloor.Ground,
                    Status=EnumsLookup.ElevatorStatus.Down,
                    Occupants=1
                }
            };

            var expected = "Elevator 2 is being sent from Second floor";

            //act
            var manager = new ElevatorManager(elevatorList);
            var result = manager.CallElevator(Lookup.EnumsLookup.ElevatorFloor.Tenth, Lookup.EnumsLookup.ElevatorFloor.Ground, 2);

            //assert
            Assert.AreEqual(expected, result.ElevatorCallFeedback);
        }

        [TestMethod]
        public void CallElevatorFromGroundFloorWhenAllThreeElevatorsAreAvailable()
        {
            //arrange 
            var elevatorList = new List<IElevator>
            {
                new Business.Elevator
                {
                    ElevatorNumber=1,
                    CurrentFloor=ElevatorFloor.Fifth,
                    DestinationFloor=ElevatorFloor.Fifth,
                    Status=EnumsLookup.ElevatorStatus.Available,
                    Occupants=0
                },
                 new Business.Elevator
                {
                    ElevatorNumber=2,
                    CurrentFloor=ElevatorFloor.Sixth,
                    DestinationFloor=ElevatorFloor.Sixth,
                    Status=EnumsLookup.ElevatorStatus.Available,
                    Occupants=3
                },
                new Business.Elevator
                {
                    ElevatorNumber=3,
                    CurrentFloor=ElevatorFloor.Ninth,
                    DestinationFloor=ElevatorFloor.Ninth,
                    Status=EnumsLookup.ElevatorStatus.Available,
                    Occupants=1
                }
            };

            var expected = "Elevator 1 is being sent from Fifth floor";

            //act
            var manager = new ElevatorManager(elevatorList);
            var result = manager.CallElevator(Lookup.EnumsLookup.ElevatorFloor.Ground, Lookup.EnumsLookup.ElevatorFloor.Ground, 8);

            //assert
            Assert.AreEqual(expected, result.ElevatorCallFeedback);
        }

        [TestMethod]
        public void CallElevatorFromThirdFloorWhenElevatorsIsOnSameFloor()
        {
            //arrange 
            var elevatorList = new List<IElevator>
            {
                new Business.Elevator
                {
                    ElevatorNumber=1,
                    CurrentFloor=ElevatorFloor.Ground,
                    DestinationFloor=ElevatorFloor.Fifth,
                    Status=EnumsLookup.ElevatorStatus.Up,
                    Occupants=0
                },
                 new Business.Elevator
                {
                    ElevatorNumber=2,
                    CurrentFloor=ElevatorFloor.Tenth,
                    DestinationFloor=ElevatorFloor.Third,
                    Status=EnumsLookup.ElevatorStatus.Down,
                    Occupants=3
                },
                new Business.Elevator
                {
                    ElevatorNumber=3,
                    CurrentFloor=ElevatorFloor.Third,
                    DestinationFloor=ElevatorFloor.Third,
                    Status=EnumsLookup.ElevatorStatus.Available,
                    Occupants=1
                }
            };

            var expected = "Elevator 3 is being sent from Third floor";

            //act
            var manager = new ElevatorManager(elevatorList);
            var result = manager.CallElevator(Lookup.EnumsLookup.ElevatorFloor.Third, Lookup.EnumsLookup.ElevatorFloor.Ground, 1);

            //assert
            Assert.AreEqual(expected, result.ElevatorCallFeedback);
        }

    }
}
