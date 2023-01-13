using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rediRND
{
    /// <summary>
    /// Denotes ability to be discerable by <c>Name</c>.
    /// </summary>
    internal interface IIdentifiable
    {
        /// <summary>
        /// Indentifier making the implimenter discernable.
        /// </summary>
        public string Name { get; }
    }
}
