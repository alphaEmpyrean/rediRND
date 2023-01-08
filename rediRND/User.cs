using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rediRND
{
    public class User : IStaker
    {
        public User(string name) 
        {
            Name= name;
        }

        public string Name { get; set; }
        public Stake Stake { get; set; } = new Stake(0m);

    }
}
