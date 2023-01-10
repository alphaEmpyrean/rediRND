using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rediRND
{
    internal class Staker : IStaker
    {
        readonly string _name;
        decimal _stake;

        public Staker(string name)
        {
            _name = name;
            _stake = 0m;
        }

        public string Name 
        { 
            get { return _name; } 
        }
        public decimal Stake 
        { 
            get { return _stake; } 
            set { _stake = value; }
        }
    }
}
