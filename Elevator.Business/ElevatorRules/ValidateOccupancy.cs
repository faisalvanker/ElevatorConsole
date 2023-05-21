using Elevator.Dto;
using Elevator.Lookup;
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
            var result = int.TryParse(selection, out occupantCount);

            return result && occupantCount <= Config.MaximumOccupancyOfLifts;
        }
    }
}
