using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace rediRND
{
    internal class Container<T> :IStaker where T : IStaker
    {
        readonly IStaker[] _contents;
        readonly string _name;
        decimal _stake;

        public Container(string name, T[] initialContents)
        {
            _contents = new IStaker[initialContents.Length];
            Array.Copy(initialContents, Contents, _contents.Length);
            _name = name;
            _stake = 0m;
        }

        public IStaker[] Contents { get { return _contents; } }
        public int Length { get { return _contents.Length; } }
        public string Name { get { return _name; } }
        public decimal Stake
        {
            get { return _stake; }
            set { _stake = value; }
        }

        public IStaker this[int index] 
        {
            get { return _contents[index]; }
            set { _contents[index] = value;}
        }

        public void PrintContents()
        {
            for (int i = 0; i < Contents.Length; i++)
            {
                Console.WriteLine($"{typeof(T)} {Contents[i].Name} - Stake: {Contents[i].Stake:g5}");
            }
        }

        public static implicit operator Container<T>(Container<Container<IStaker>> v)
        {
            Container<T> temp = new Container<T>(v.Name, new T[v.Length]);
            for (var i = 0; i < v.Length; i++)
            {
                temp.Contents[i] = v[i];
            }
            return temp;
        }
    }    
}
