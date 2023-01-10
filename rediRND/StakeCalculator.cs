using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rediRND
{
    internal static class StakeCalculator
    {
        public static void CalculateEvenStake(Container<IStaker> contents)
        {
            decimal stake = 1m / contents.Length;
            for (int i = 0; i < contents.Length; i++)
                contents[i].Stake = stake;
        }

        public static void CalculateWeightedStake(Container<IStaker> contents, int[] weights)
        {
            for (int i = 0; i < contents.Length; i++)
                contents[i].Stake = (decimal)weights[i] / weights.Sum();
        }
    }
}
