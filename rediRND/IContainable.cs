using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rediRND
{
    internal interface IContainable<T> where T : IStaker
    {
        public Container<T> ?Parent { get; set; }
    }
}
