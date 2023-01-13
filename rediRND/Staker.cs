using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rediRND
{
    /// <summary>
    /// Base implimentation that denotes an ability to claim a stake in rewards.
    /// </summary>
    /// <remarks>
    /// <c>Staker</c> is the base implimentation of <c>IStaker</c> and is the minimal 
    /// object that can have a stake in the rewards. In order to be interoperable, 
    /// objects above all else possess a <c>Stake</c> in some reward. 
    /// They also have access to their parent <c>Container</c>.
    /// </remarks>
    internal class Staker : IStaker
    {
        readonly string _name;
        decimal _stake;

        /// <summary>
        /// Builds a <c>Staker</c> object with specified name and inital <c>Stake</c> of 0M.
        /// </summary>
        /// <param name="name">Identifier for the <c>Staker</c>.</param>
        public Staker(string name)
        {
            _name = name;
            _stake = 0m;
        }

        /// <summary>
        /// Indentifier making the <c>Staker</c> discerable.
        /// </summary>
        /// <remarks>
        /// Implimentation of the <see cref="IIdentifiable"/> interface.
        /// </remarks>
        public string Name 
        { 
            get { return _name; } 
        }

        /// <c>Parent</c> is a reference to the parent <see cref ="Container"/>that 
        /// holds the current <c>IStaker</c>
        /// </summary>
        public Container ?Parent { get; set; }

        /// <summary>
        /// <c>Stake</c> represents a share of the reward as a <see langword="decimal"/> percentage
        /// </summary>
        public decimal Stake 
        { 
            get { return _stake; } 
            set { _stake = value; }
        }

        public override string ToString()
        {
            return Parent is null ?
                $"{this.Name} >\tStake: {this.Stake:g5}" :
                $"{this.Name} >\tParent: {Parent.Name}\tWeight: {Parent[this]:g5}\tStake: {this.Stake:p5}";
        }
    }
}
