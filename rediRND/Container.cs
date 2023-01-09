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
        decimal _stake;
        readonly decimal[] _stakers;

        public Container(decimal stake, decimal[] stakers)
        {
            _stake = stake;
            _stakers = stakers;
        }

        public decimal Stake 
        { 
            get { return _stake; }
            set { _stake = value; }
        }
        
        public decimal[] Stakers
        {
            get 
            {
                decimal[] returnArray = new decimal[_stakers.Length];
                _stakers.CopyTo(returnArray, 0);
                return returnArray;
            }
        }

        public void CalculateEvenSplit()
        {
            decimal stake = 1m / _stakers.Length;
            for (int i = 0; i < _stakers.Length; i++)
                _stakers[i] = stake;
        }

        public void CalculateWeightedSplit(int[] weights)
        {            
            for (int i = 0; i < _stakers.Length; i++)
                _stakers[i] = (decimal) weights[i] / weights.Sum();
        }

        public void PrintStakers()
        {
            for (int i = 0; i < _stakers.Length; i++)
            {
                Console.WriteLine($"Staker {i + 1} - Stake: {_stakers[i]:g5}");
            }
        }
    }
}
