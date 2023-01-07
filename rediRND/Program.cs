namespace rediRND
{
    internal class Program
    {
        public static Container<IStaker> RootContainer { get; private set; } = new Container<IStaker>(new IStaker[0]);

        public static List<Stake> StakeLedger { get; private set; } = new List<Stake> { };

        static decimal DailyGrossProfit = 1000M;

        static void Main(string[] args)
        {

            Container<User> allUsersContainer = new Container<User>(new User[] { new User("Josh"), new User("Chris"), new User("Kelly"),
                                                                                 new User("Mike"), new User("Garrett"), new User("Jarrad")});

            Container<IStaker> payrollContainer = new Container<IStaker>(new IStaker[0]);
            Container<IStaker> shareholderContainer = new Container<IStaker>(new IStaker[0]);
            RootContainer.Add(payrollContainer);
            RootContainer.Add(shareholderContainer);

            shareholderContainer.Add(allUsersContainer[0]);
            shareholderContainer.Add(allUsersContainer[1]);
            payrollContainer.Add(allUsersContainer[0]);
            payrollContainer.Add(allUsersContainer[1]);
            payrollContainer.Add(allUsersContainer[2]);
            payrollContainer.Add(allUsersContainer[3]);
            payrollContainer.Add(allUsersContainer[4]);
            payrollContainer.Add(allUsersContainer[5]);

            RootContainer.Stake = 1M;

            CalculateStake(RootContainer);

            PrintReport(RootContainer);
            PrintReport(payrollContainer);
            PrintReport(shareholderContainer);
        }

        static void CalculateStake(Container<IStaker> container)
        {
            foreach (IStaker staker in container)
            {
                staker.Stake = (decimal) 1 / container.Stakers.Count;
                if (staker is Container<IStaker> childContainer)
                    CalculateStake(childContainer);
            }

        }

        static void PrintReport(Container<IStaker> container)
        {
            foreach (IStaker staker in container)
                if (staker is User user)
                    Console.WriteLine($"User: {user.Name}\n\tStake: {user.Stake:f6}\n\tDailyProfit: {user.Reward:c}\n");
        }
    }
}