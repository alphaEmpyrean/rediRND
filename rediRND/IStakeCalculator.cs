using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rediRND
{
    /// <summary>
    /// The interface <c>IStakeCalculator</c> specifies that an object
    /// can prefrom <c>Stake</c> calculations on the <c>IStaker</c> passed to it.
    /// </summary>
    /// <typeparam name="T">
    /// Specified Type for <c>T</c> must be of type <c>IStaker</c>
    /// </typeparam>
    public interface IStakeCalculator<T> where T : IStaker
    {
        /// <summary>
        /// Performs calculations on the <c>IStaker</c> object passed to it
        /// according to the scheme laid out in the implimenting class. 
        /// </summary>
        /// <param name="staker">Object must impliment interface <c>IStaker</c>.</param>
        void Calculate(T staker);
    }
}
