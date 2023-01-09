using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rediRND
{
    internal class Container
    {
        readonly decimal[] _stakers;
        string _name;
        decimal _stake = 0M;

        public Container(string name, decimal[] stakers)
        {
            _stakers = stakers;
            _name = name;
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
        
        public decimal[] Stakers
        {
            get { return _stakers; }
        }

        public void CalculateEvenSplit()
        {
            decimal stake = 1m / Stakers.Length;
            for (int i = 0; i < Stakers.Length; i++)
                Stakers[i] = stake;
        }

        public void CalculateWeightedSplit(int[] weights)
        {            
            for (int i = 0; i < Stakers.Length; i++)
                Stakers[i] = (decimal) weights[i] / weights.Sum();
        }

        public void PrintStakers()
        {
            for (int i = 0; i < Stakers.Length; i++)
            {
                Console.WriteLine($"Staker {i + 1} - Stake: {Stakers[i]:g5}");
            }
        }
    }
}
