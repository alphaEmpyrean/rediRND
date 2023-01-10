namespace rediRND
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // build structure
            IStaker[] stakers = new Staker[] {new Staker("Josh"), new Staker("Mike"), new Staker("Chris"), new Staker("Kelly"), new Staker("Jaxon"), new Staker("Jarrad"), new Staker("Garrett"), new Staker("Knox") };
            Container<IStaker>[] containers = new Container<IStaker>[6];

            Container<IStaker> thirdContainer = new("first", new IStaker[] { stakers[0], stakers[1], stakers[2] });
            containers[5] = thirdContainer;
            Container<IStaker> fourthContainer = new("second", new IStaker[] { stakers[4], stakers[5], stakers[6], stakers[7] });
            containers[4] = fourthContainer;

            Container<Container<IStaker>> structuralContainer = new("Structural", new Container<IStaker>[] { thirdContainer, fourthContainer });
            containers[3] = structuralContainer;

            Container<IStaker> firstContainer = new("first", new IStaker[] { stakers[0], stakers[1], stakers[2] });
            containers[2] = firstContainer;
            Container<IStaker> secondContainer = new("second", new IStaker[] { stakers[4], stakers[5], stakers[6], stakers[7] });
            containers[1] = secondContainer;

            Container<Container<IStaker>> rootContainer = new("Root", new Container<IStaker>[] { firstContainer, secondContainer, structuralContainer });
            containers[0] = rootContainer;

            // Calculate Stakes

            rootContainer.Stake = 1M;

            StakeCalculator.CalculateWeightedStake(rootContainer, new int[] { 1, 2, 1 });

            StakeCalculator.CalculateEvenStake(firstContainer);
            StakeCalculator.CalculateEvenStake(structuralContainer);
            StakeCalculator.CalculateEvenStake(secondContainer);

            StakeCalculator.CalculateWeightedStake(thirdContainer, new int[] { 1, 2, 1 });
            StakeCalculator.CalculateEvenStake(fourthContainer);

            // Print Stakes
            for (var i = 0; i < containers.Length; i++)
            {
                containers[i].PrintContents();
            }
        }
    }
}