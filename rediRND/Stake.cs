using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rediRND
{
    /// <summary>
    /// A <c>Stake</c> is a percentage defined as a <see langword="decimal"/>. 
    /// It is an immutable class and can only be set during instantiation.
    /// </summary>
    public class Stake
    {
        /// <summary>
        /// The <c>Stake</c> object is backed by <c>Value</c>, 
        /// a property of the type <see langword="decimal"/>.
        /// </summary>
        /// <value><c>Value</c> must be between 0 and 1.</value> 
        public decimal Value { get; private set; }

        /// <summary>
        /// This constructor takes a <see langword="decimal"/> between 0 and 1.
        /// </summary>
        /// <param name="value">Must be between 0 and 1</param>
        public Stake(decimal value) 
        {
            if (value > 1 || value < 0)
                throw new ArgumentOutOfRangeException("Stake objects must have a value between 0 and 1"); 
            Value= value;            
        }

        /// <summary>
        /// Override <c>ToString</c> method to enable use
        /// of class reference as a shortcut for printing
        /// its value in a string.
        /// </summary>
        /// <returns>Return the value of the underlying <c>Value</c> property.</returns>
        public override string ToString()
        {
            return Value.ToString();
        }
    }
}
