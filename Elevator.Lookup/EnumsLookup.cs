using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elevator.Lookup
{
    public class EnumsLookup
    {
        public enum ElevatorFloor
        {
            Ground,
            First,
            Second,
            Third,
            Fourth,
            Fifth,
            Sixth,
            Seventh,
            Eight,
            Ninth,
            Tenth,
        }

        public enum ElevatorStatus
        {
            Available,
            Up,
            Down,
            OutOfService
        }

        public enum Validation
        {
            Success,
            Invalid,
        }
    }
}
