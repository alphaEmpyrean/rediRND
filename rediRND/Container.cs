using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rediRND
{
    internal class Container<T> : IEnumerable<T>, IEnumerable, IStaker where T : IStaker
    {
        public Container(IStaker[] stakers)
        {
            Stakers = stakers.ToList();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return ((IEnumerable<T>)Stakers).GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return Stakers.GetEnumerator();
        }

        public List<IStaker> Stakers { get; private set; }
        public decimal Stake { get; set; }

        public IStaker this[int index]
        {
            get => Stakers[index];
            set => Stakers[index] = value;
        }
    }
}
