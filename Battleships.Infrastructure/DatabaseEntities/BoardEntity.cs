﻿using System.Collections.Generic;

namespace Battleships.Infrastructure.DatabaseEntities
{
    public class BoardEntity : IEntity
    {
        public int Id { get; set; }
        public virtual List<MissShotEntity> MissShots { get; set; }
        public virtual List<HitShotEntity> HitShots { get; set; }
        public virtual List<ShipEntity> Ships { get; set; }
    }
}
