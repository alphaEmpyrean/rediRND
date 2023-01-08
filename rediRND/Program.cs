namespace rediRND
{
    internal class Program
    {
        static void Main(string[] args)
        {

            IStakeCalculator<StakerContainer<IStaker>> evenSplit = new EvenSplit();

            StakerContainer<IStaker> rootContainer = new StakerContainer<IStaker> ("Root", evenSplit, Array.Empty<IStaker>());
            PrintReport(rootContainer);
            StakerContainer<IStaker> payrollContainer = new StakerContainer<IStaker>("Payroll", evenSplit, Array.Empty<IStaker>());
            rootContainer.Add(payrollContainer);
            PrintReport(rootContainer);
            StakerContainer<IStaker> sharholderContainer = new StakerContainer<IStaker>("Shareholder", evenSplit, Array.Empty<IStaker>());
            rootContainer.Add(sharholderContainer);
            PrintReport(rootContainer);
        }

        static void PrintReport(StakerContainer<IStaker> container)
        {
            Console.WriteLine($"****{container.Name} Stake: {container.Stake:f6}");

            foreach (IStaker staker in container)
            {
                if (staker is User user)
                    Console.WriteLine($"User: {user.Name}\n\tStake: {user.Stake.Value:f6}");
                if (staker is StakerContainer<IStaker> childContainer)
                    PrintReport(childContainer);
            }
        }
    }
}