﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rediRND
{
    internal interface IStaker : IIdentifiable, IContainable<IStaker>
    {
        public decimal Stake { get; set; }
    }
}
