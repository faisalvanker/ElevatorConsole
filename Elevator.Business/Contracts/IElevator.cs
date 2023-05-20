using Elevator.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static Elevator.Lookup.EnumsLookup;

namespace Elevator.Business.Contracts
{
    public interface IElevator
    {
        int ElevatorNumber { get; set; }
        ElevatorFloor CurrentFloor { get; set; }

        ElevatorFloor DestinationFloor { get; set; }

        ElevatorStatus Status { get; set; }

        int MaximumOccupancy { get; }

        int Occupants { get; set; }

    }

}
