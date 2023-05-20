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
    public interface IElevatorValidator
    {

        ValidationDto ValidateSelection(string currentFloor, string destinationFloor, string occupants);

    }

}
