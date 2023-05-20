using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Elevator.Lookup.EnumsLookup;

namespace Elevator.Lookup
{
    public static class RandomElevator
    {
        public static ElevatorFloor RandomFloor()
        {
            Random rnd = new Random();
            int floor = rnd.Next(0, 10);

            return (ElevatorFloor)floor;
        }
    }
}
