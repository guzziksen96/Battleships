using Battleships.Domain.Entities;
using FluentValidation;

namespace Battleships.Application.Game.Commands.FireNewShot
{
    public class FireNewShotCommandValidator : AbstractValidator<FireNewShotCommand>
    {
        public FireNewShotCommandValidator()
        {
            RuleFor(c => c.Coordinate).Custom((coordinate, context) =>
            {
                bool isCoordinateOnBoard = Board.IsInBoundaries(coordinate);
                if (!isCoordinateOnBoard)
                {
                    context.AddFailure("Coordinate is not on the board");
                }
            });
        }
    }
}
