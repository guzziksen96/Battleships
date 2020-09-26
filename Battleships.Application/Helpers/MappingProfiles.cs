using AutoMapper;
using System;
using System.Linq.Expressions;
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
             

            CreateMap<Ship, ShipEntity>().ReverseMap();
            CreateMap<Board, BoardEntity>();
            CreateMap<BoardEntity, Board>();
            CreateMap<Domain.Entities.Game, GameEntity>().ReverseMap();
        }
    }
}
