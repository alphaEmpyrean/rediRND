namespace rediRND
{
    /// <summary>
    /// Base interface that denotes ability to claim a stake in rewards.
    /// </summary>
    /// <remarks>
    /// <c>IStaker</c> is the base interface and foundation for objects who need to 
    /// have a stake in the rewards. In order to be interoperable, objects above all 
    /// else need to have a <c>Stake</c> in some reward. They must also have access 
    /// to their parent <c>Container</c>
    /// </remarks>
    internal interface IStaker : IIdentifiable
    {
        /// <summary>
        /// <c>Stake</c> represents a share of the reward as a <see langword="decimal"/> percentage
        /// </summary>
        public decimal Stake { get; set; }
        /// <summary>
        /// <c>Parent</c> is a reference to the parent <see cref ="Container"/>that 
        /// holds the current <c>IStaker</c>
        /// </summary>
        public Container Parent { get; set; }
    }
}
