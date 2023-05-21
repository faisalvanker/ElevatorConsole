using Elevator.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Elevator.Lookup.EnumsLookup;

namespace Elevator.Business.ElevatorRules
{
    public static class ValidateFloor
    {

        public static bool Validate(string selection, out ElevatorFloor floorSelection)
        {
            floorSelection = default;
          
            var validSelection = new List<string> { "ground", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10" };

            if (!validSelection.Contains(selection.Trim().ToLowerInvariant()))
            {
                return false;
            }

            return Enum.TryParse(selection, true, out floorSelection);

        }
    }
}
