using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Elevator.Lookup.EnumsLookup;

namespace Elevator.Dto
{
    public class ValidationDto
    {
       public ElevatorFloor CurrentFloor { get; set; }

        public ElevatorFloor DestinationFloor { get; set; }

        public int Occupants { get; set; }

        public Validation Status { get; set; }
        public string Description { get; set; }
    }
}
