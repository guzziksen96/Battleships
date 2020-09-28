using AutoMapper;
using System.Linq;
using Battleships.Application.Game.Models;
using Battleships.Domain.Entities;

namespace Battleships.Application.Helpres
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Board, ComputerBoardDto>()
                .ForMember(c => c.SunkShips, c => c.MapFrom(s => s.Ships
                    .Where(ship => ship.IsSunk(s.HitShots))
                    .Select(sh => sh.Name)));

            CreateMap<Domain.Entities.Game, GameStateDto>()
                .ForMember(dto => dto.Result, g => g.MapFrom(game => game.GetResult().ToString()));
        }
    }
}
