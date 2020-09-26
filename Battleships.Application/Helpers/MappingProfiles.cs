using AutoMapper;
using System;
using System.Linq;
using System.Linq.Expressions;
using Battleships.Application.Game.Models;
using Battleships.Domain.Entities;
using Battleships.Infrastructure.DatabaseEntities;

namespace Battleships.Application.Helpres
{
    public class MappingProfiles : Profile
    {
        private readonly Expression<Func<Coordinate, int>> _coordinateIdMapper = e => (e.Row - 1) * 10 + (e.Column - 'a') + 1;

        public MappingProfiles()
        {
            CreateMap<Coordinate, CoordinateEntity>()
                .ForMember(s => s.Id, c => c.MapFrom(_coordinateIdMapper));

            CreateMap<CoordinateEntity, Coordinate>();

            CreateMap<Coordinate, HitShotEntity>()
                .ForMember(c => c.Coordinate, s => s.Ignore())
                .ForMember(c => c.CoordinateId, src => src.MapFrom(_coordinateIdMapper));

            CreateMap<Coordinate, MissShotEntity>()
                .ForMember(c => c.Coordinate, s => s.Ignore())
                .ForMember(c => c.CoordinateId, src => src.MapFrom(_coordinateIdMapper));
           
            CreateMap<Coordinate, ShipPositionEntity>()
                .ForMember(c => c.Coordinate, s => s.Ignore())
                .ForMember(c => c.CoordinateId, src => src.MapFrom(_coordinateIdMapper));

            CreateMap<ShipPositionEntity, Coordinate>()
                .ForMember(c => c.Column, c => c.MapFrom(s => s.Coordinate.Column))
                .ForMember(c => c.Row, c => c.MapFrom(s => s.Coordinate.Row));

            CreateMap<MissShotEntity, Coordinate>()
                .ForMember(c => c.Column, c => c.MapFrom(s => s.Coordinate.Column))
                .ForMember(c => c.Row, c => c.MapFrom(s => s.Coordinate.Row));

            CreateMap<HitShotEntity, Coordinate>()
                .ForMember(c => c.Column, c => c.MapFrom(s => s.Coordinate.Column))
                .ForMember(c => c.Row, c => c.MapFrom(s => s.Coordinate.Row));

            CreateMap<Ship, ShipEntity>().ReverseMap();
            CreateMap<Board, BoardEntity>();
            CreateMap<BoardEntity, Board>();
            CreateMap<Domain.Entities.Game, GameEntity>().ReverseMap();

            CreateMap<Board, ComputerBoardDto>()
                .ForMember(c => c.SunkShips, c => c.MapFrom(s => s.Ships
                    .Where(ship => ship.IsSunk(s.HitShots))
                    .Select(sh => sh.Name)));

            CreateMap<Domain.Entities.Game, PendingGameStateDto>();
        }
    }
}
