using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rediRND
{
    internal interface IScheme : IStaker
    {
        public TimeSpan Duration { get; set; }
    }
}
