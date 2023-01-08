using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rediRND
{
    internal class EvenSplit : IStakeCalculator<StakerContainer<IStaker>>
    {
        public void Calculate(StakerContainer<IStaker> stakerContainer)
        {
            decimal stake = stakerContainer.Stake.Value / stakerContainer.Stakers.Count;

            foreach (IStaker staker in stakerContainer)
                staker.Stake = new Stake(stake);
        }
    }
}
