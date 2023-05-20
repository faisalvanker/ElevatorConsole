using Elevator.Business.Contracts;
using Elevator.Business.ElevatorRules;
using Elevator.Dto;
using System;
using static Elevator.Lookup.EnumsLookup;

namespace Elevator.Business
{
    public class ElevatorValidator : IElevatorValidator
    {
        public ValidationDto ValidateSelection(string currentFloor, string destinationFloor, string occupants)
        {
            ElevatorFloor current;
            ElevatorFloor destination;
            int occupantCount;

            ValidationDto validationDto = new ValidationDto();
       

            if (ValidateFloor.Validate(currentFloor, out current) && ValidateFloor.Validate(destinationFloor, out destination) && ValidateOccupancy.Validate(occupants, out occupantCount))
            {
                validationDto.CurrentFloor = current;
                validationDto.DestinationFloor = destination;
                validationDto.Occupants = occupantCount;
                validationDto.Status = Validation.Success;
                validationDto.Description = "Successful Selection";
            }
            else
            {
                validationDto.Status = Validation.Invalid;
                validationDto.Description = "Invalid Selection Provided";
            }

            return validationDto;
        }
    }
}