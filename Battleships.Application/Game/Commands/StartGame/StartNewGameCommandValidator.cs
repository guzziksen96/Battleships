using System.Collections.Generic;
using System.Linq;
using Battleships.Domain.Entities;
using Battleships.Domain.Rules;
using FluentValidation;

namespace Battleships.Application.Game.Commands.StartGame
{
    public class StartNewGameCommandValidator : AbstractValidator<StartNewGameCommand>
    {
        public StartNewGameCommandValidator()
        {
            RuleFor(c => c.Ships).Custom((ships, context) =>
            {
                bool areShipsNamesValid = AreShipsNamesValid(ships);
                if (!areShipsNamesValid)
                {
                    context.AddFailure("Wrong ship names");
                }


                bool areShipsWidthValid = AreShipsWidthValid(ships);
                if (!areShipsWidthValid)
                {
                    context.AddFailure("Wrong ship widths");
                }

                bool areShipsInBoardRange = AreShipsInBoardRange(ships);
                if (!areShipsInBoardRange)
                {
                    context.AddFailure("Ships not in board range");
                }


                bool areShipsNotColliding = AreShipsNotColliding(ships);
                if (!areShipsNotColliding)
                {
                    context.AddFailure("Ships are colliding with each other");
                }
            });
        }

        public bool AreShipsNotColliding(List<Ship> ships)
        {
            for (int i = 0; i < ships.Count - 1; i++)
            {
                var currentShip = ships[i];
                for (int j = i + 1; j < ships.Count; j++)
                {
                    var nextShip = ships[j];
                    if (currentShip.IsCollidingWith(nextShip))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public bool AreShipsInBoardRange(List<Ship> ships)
        {
            foreach (var ship in ships)
            {
                if (!Board.IsInBoundaries(ship))
                {
                    return false;
                }
            }

            return true;
        }

        public bool AreShipsNamesValid(List<Ship> ships)
        {
            if (ships.Count != ShipNames.All.Length)
            {
                return false;
            }

            foreach (var ship in ShipNames.All)
            {
                var oneNamedShipExist = ships.Count(s => s.Name == ship) == 1;
                if (!oneNamedShipExist)
                {
                    return false;
                }
            }

            return true;
        }

        public bool AreShipsWidthValid(List<Ship> ships)
        {
            foreach (var shipName in ShipNames.All)
            {
                var ship = ships.FirstOrDefault(s => s.Name == shipName);
                if (ship == null)
                    return false;

                var validShipWidth = ShipWidths.Values[shipName];
                if (ship?.ShipPositions.Count() != validShipWidth)
                    return false;
            }

            return true;
        }
    }
}
