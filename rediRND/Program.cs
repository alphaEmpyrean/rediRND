namespace rediRND
{
    internal class Program
    {
        static Container<IStaker> container = new(new IStaker[] { new User("josh"), new User("mike") });

        static Timecard timecard = new Timecard(new Dictionary<User, decimal>()
            {
                { (User) container[0], 5m },
                { (User) container[1], 10m }
            });

        static decimal DailyGrossProfit = 300M;

        static void Main(string[] args)
        {
            timecard.AddEntry((User)container[0], 15);
            CalculateStake();
            CalculateDailyProfit();
            PrintReport();
        }

        static void CalculateStake()
        {
            foreach (User user in container)
            {
                user.Stake = (decimal)timecard.HoursWorkedTodayByUser(user) / timecard.TotalHoursWorked;
            }
            
        }

        static void CalculateDailyProfit()
        {
            foreach (User user in container)
            {
                user.DailyProfit = user.Stake * DailyGrossProfit;
            }
        }

        static void PrintReport()
        {
            foreach (User user in container)
            {
                Console.WriteLine($"User: {user.Name}\n\tStake: {user.Stake:f6}\n\tDailyProfit: {user.DailyProfit:c}\n");
            }
        }
    }
}