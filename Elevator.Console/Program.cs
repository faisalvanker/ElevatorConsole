using Elevator.Business;
using Elevator.Business.ElevatorRules;
using Elevator.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Elevator.Lookup.EnumsLookup;

namespace Elevator.ConsoleApp
{
    internal class Program
    {
        public static ElevatorManager manager = new ElevatorManager();
        static void Main(string[] args)
        {
            var validSelection = GetElevatorSelection();

            if (validSelection.Status == Validation.Success)
            {
                DisplayElevatorStatus(validSelection);
                DisplayAllElevatorStatus();
            }

            Console.ReadLine();
        }

        #region Private Methods
        private static void DisplayElevatorStatus(ValidationDto validSelection)
        {
            var elevatorResponse = CallElevator(validSelection);

            Console.WriteLine();
            Console.WriteLine(elevatorResponse.ElevatorCallFeedback);
            Console.WriteLine();
        }

        private static ElevatorCallDto CallElevator(ValidationDto selection)
        {
            return manager.CallElevator(selection.CurrentFloor, selection.DestinationFloor, selection.Occupants);
        }

        private static ValidationDto GetElevatorSelection()
        {
            string current, destination, occupants;

            Console.WriteLine("Welcome to the Elevator");
            Console.WriteLine("");

            Console.WriteLine("What is your current floor? Selection (Ground, 1, 2, 3, 4, 5, 6 ,7, 8, 9, 10)");
            current = Console.ReadLine();

            Console.WriteLine("What is your destination floor? Selection (Ground, 1, 2, 3, 4, 5, 6 ,7, 8, 9, 10)");
            destination = Console.ReadLine();

            Console.WriteLine("How many people? numeric eg. 2");
            occupants = Console.ReadLine();

            return ValidateElevatorSelection(current, destination, occupants);
        }

        private static void DisplayAllElevatorStatus()
        {
            var elevatorStatuses = manager.ElevatorStatus();

            foreach (var status in elevatorStatuses)
            {
                Console.WriteLine($" Elevator Number {status.ElevatorNumber}");
                Console.WriteLine($" Status {status.Status}");
                Console.WriteLine($" Current Floor {status.CurrentFloor}");
                Console.WriteLine($" Occupants {status.Occupants}");
                Console.WriteLine();
                Console.WriteLine();
            }
        }

        private static ValidationDto ValidateElevatorSelection(string current, string destination, string occupants)
        {
            var validation = new ElevatorValidator();

            var result = validation.ValidateSelection(current, destination, occupants);

            if (result.Status == Validation.Success)
                Console.WriteLine($"You have are on {current} floor(s), going to {destination} floor and have {occupants} person(s)");
            else
                Console.WriteLine($"Error {result.Description}");

            return result;
        }
        #endregion
    }
}
