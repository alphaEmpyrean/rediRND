using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rediRND
{
    internal class User : IStaker
    {
        public User(string name) 
        {
            Name= name;
        }

        public string Name { get; set; }
        public decimal Stake { get; set; }
        public decimal Reward { get; set; }
    }
}
