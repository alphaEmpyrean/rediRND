using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rediRND
{
    internal class ContainerStructural
    {
        readonly Container[] _containers;
        decimal _stake;

        public ContainerStructural(decimal stake ,Container[] containers)
        {
            _containers = containers;
            _stake = stake;
        }

        public Container[] Containers { get { return _containers; } }
        decimal Stake { get { return _stake;} }

        public void CalculateEvenSplit()
        {
            decimal stake = 1m / Containers.Length;
            for (int i = 0; i < Containers.Length; i++)
                Containers[i].Stake = stake;
        }

        public void CalculateWeightedSplit(int[] weights)
        {
            for (int i = 0; i < Containers.Length; i++)
                Containers[i].Stake = (decimal)weights[i] / weights.Sum();
        }

        public void PrintContainers()
        {
            for (int i = 0; i < Containers.Length; i++)
            {
                Console.WriteLine($"Container {Containers[i].Name} - Stake: {Containers[i].Stake:g5}");
            }
        }
    }
}
