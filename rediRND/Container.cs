using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rediRND
{
    public partial class StakerContainer<T> : IEnumerable<T>, IEnumerable, IStaker where T : IStaker
    {
        public StakerContainer(string name, IStakeCalculator<StakerContainer<T>> stakerCalculator, IStaker[] stakers)
        {
            Name = name;
            StakeCalculator = stakerCalculator;
            Stakers = stakers.ToList();
            Stake = name == "Root" ? new Stake(1M) : new Stake(0M);
        }

        public void CalculateStakes()
        {
            StakeCalculator.Calculate(this);
        }

        public List<IStaker> Stakers { get; private set; }
        public Stake Stake { get; set; }
        public IStakeCalculator<StakerContainer<T>> StakeCalculator { get; set; }
        public string Name { get; private set; }

        public void Add(T staker)
        {
            Stakers.Add(staker);
            CalculateStakes();
        }
    }

    public partial class StakerContainer<T> : IEnumerable<T>, IEnumerable, IStaker where T : IStaker
    {

        public IEnumerator<T> GetEnumerator()
        {
            return ((IEnumerable<T>)Stakers).GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return Stakers.GetEnumerator();
        }



        public IStaker this[int index]
        {
            get => Stakers[index];
            set => Stakers[index] = value;
        }

    }
}
