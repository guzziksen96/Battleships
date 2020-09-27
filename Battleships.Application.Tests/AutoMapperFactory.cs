using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;

namespace Battleships.Application.Tests
{
    public static class AutoMapperFactory
    {
        public static IMapper Create(Profile profile)
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(profile);
            });
            return mappingConfig.CreateMapper();
        }
    }
}
