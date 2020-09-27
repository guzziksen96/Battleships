using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Battleships.Infrastructure;
using Xunit;

namespace Battleships.Application.Tests
{
    public class SqliteTests : SqliteTestBase<BattleshipsDbContext>
    {
        [Fact]
        public async Task DatabaseIsAvailableAndCanBeConnectedTo()
        {
            Assert.True(await DbContext.Database.CanConnectAsync());
        }
    }
}
