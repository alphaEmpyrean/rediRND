using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace rediRND
{
    internal class Container : Dictionary<IStaker, int> , IContainer, IStaker
    { 

        public Container(string name) : base()
        {
            Name = name;
        }

        public Container(string name, IStaker[] initialContents) : base()
        {
            foreach (IStaker item in initialContents) 
            {
                Add(item, 0);
            }
            Name = name;
            CalculateStake(false);
        }

        public string Name { get; set; }
        public Container ?Parent { get; set; }
        public decimal Stake { get; set; } = 0;

        public void PrintContents(bool isRecursive)
        {
            Console.WriteLine("***" + this);
            List<Container> childContainers = new();
            foreach (IStaker item in Keys)
            {
                Console.WriteLine("\t" + item);
                if (item is Container childContainer)
                    childContainers.Add(childContainer);
            }
            Console.WriteLine();
            if (isRecursive)
                foreach (Container childContainer in childContainers)
                    childContainer.PrintContents(true);
        }

        public void CalculateStake(bool isRecursive)
        {
            int total = this.Values.Sum();

            foreach (IStaker item in Keys)
            {
                item.Stake += (total == 0) ? 0 : (decimal)this[item] / total * Stake;
                    if (isRecursive && item is Container childContainer)
                        childContainer.CalculateStake(true);
            }
        }

        public void SetWeight(IStaker staker, int weight)
        {
            this[staker] = weight;
        }

        public new void Add(IStaker t, int i)
        {
            t.Parent = this;
            base.Add(t, i);
        }

        public void Add(IStaker t)
        {
            t.Parent = this;
            base.Add(t, 0);
        }

        public override string ToString()
        {
            return Parent is null ?
                $"{this.Name} Container>\tStake: {this.Stake:g5}" :
                $"{this.Name} Container>\tParent: {Parent.Name}\tWeight: {Parent[this]:g5}\tStake: {this.Stake:p5}";
        }
    }

    internal class Container<T> : Container where T : IStaker
    {

        public Container(string name, T[] initialContents) : base(name)
        {
            foreach (IStaker item in initialContents)
            {
                Add(item, 0);
            }
            Name = name;
            CalculateStake(false);
        }
    }
}