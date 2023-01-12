using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rediRND
{
    internal class Scheme : IScheme
    {
        
        public Scheme(string name, TimeSpan duration)
        {
            Duration = duration;
        }

        public decimal Stake { get ; set; }
        public string Name { get; }
        public TimeSpan Duration { get; set; }
        public Container<IStaker>? Parent { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
