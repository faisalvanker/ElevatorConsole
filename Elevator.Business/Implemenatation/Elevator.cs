using Elevator.Business.Contracts;
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
    public class Elevator : IElevator
    {
        #region Property Fields
        public int ElevatorNumber { get; set; }
        public ElevatorFloor CurrentFloor { get; set; }

        public ElevatorFloor DestinationFloor { get; set; }

        public ElevatorStatus Status { get; set; }

        public int MaximumOccupancy { get { return Config.MaximumOccupancyOfLifts; } }

        public int Occupants { get; set; }

        #endregion

    }
}
