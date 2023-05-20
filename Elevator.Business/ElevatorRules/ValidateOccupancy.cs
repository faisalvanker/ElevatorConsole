using Elevator.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Elevator.Lookup.EnumsLookup;

namespace Elevator.Business.ElevatorRules
{
    public static class ValidateOccupancy
    {

        public static bool Validate(string selection, out int occupantCount)
        {
            return int.TryParse(selection, out occupantCount);
        }
    }
}
