using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rediRND
{
    internal interface IStaker
    {
        string Name { get; }
        decimal Stake { get; set; }
    }
}
