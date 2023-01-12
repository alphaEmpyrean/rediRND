using System;
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
    internal class Container<T> : Dictionary<T, int>, IStaker where T : IStaker
    {
        readonly string _name;
        decimal _stake;

        public Container(string name) : base()
        {
            _name = name;
            _stake = 0m;
        }

        public Container(string name, T[] initialContents) : base()
        {
            foreach (T item in initialContents) 
            {
                Add(item, 0);
            }
            _name = name;
            _stake = 0m;
            CalculateStake(false);
        }

        public string Name { get { return _name; } }
        public decimal Stake
        {
            get { return _stake; }
            set { _stake = value; }
        }
        public Container<IStaker> ?Parent { get; set; }

        public void PrintContents(bool isRecursive)
        {
            Console.WriteLine("***" + this);
            List<Container<T>> childContainers = new();
            foreach (T item in Keys)
            {
                Console.WriteLine("\t" + item);
                if (item is Container<T> childContainer)
                    childContainers.Add(childContainer);
            }
            Console.WriteLine();
            if (isRecursive)
                foreach (Container<T> childContainer in childContainers)
                    childContainer.PrintContents(true);
        }
        public void CalculateStake(bool isRecursive)
        {
            int total = this.Values.Sum();

            foreach (T item in Keys)
            {
                item.Stake += (total == 0) ? 0 : (decimal)this[item] / total * Stake;
                    if (isRecursive && item is Container<T> childContainer)
                        childContainer.CalculateStake(true);
            }
        }
        public void SetWeight(T staker, int weight)
        {
            this[staker] = weight;
        }
        public new void Add(T t, int i)
        {
            t.Parent = this;
            base.Add(t, i);
        }
        public void Add(T t)
        {
            t.Parent = (Container<IStaker>) this;
            base.Add(t, 0);
        }

        public static explicit operator Container<IStaker>(Container<T> v)
        {
            foreach ()
        }

        public override string ToString()
        {
            return Parent is null ?
                $"{this.Name} Container>\tStake: {this.Stake:g5}" :
                $"{this.Name} Container>\tParent: {Parent.Name}\tWeight: {Parent[this]:g5}\tStake: {this.Stake:g5}";
        }
    }
}
