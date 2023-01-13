using System.Collections.ObjectModel;

namespace rediRND
{
    internal class Program
    {

        
        static void Main(string[] args)
        {
            // root container
            Container<IStaker> rootContainer = new("Root", Array.Empty<IStaker>());
            rootContainer.Stake = 1m;

            // create users
            Staker[] stakersArray = new Staker[]
            {
                new Staker("Josh"), new Staker("Kristen"), new Staker("Brooke"), new Staker("Kelly"),
                new Staker("Jaxon"), new Staker("Jarrad"), new Staker("Garrett"), new Staker("Knox")
            };
            Container<Staker> stakers = new("StakerObjects", stakersArray);

            // build structure
            Container business = new("Business");
            Container employees = new("Employees");
            Container shareholders = new("Shareholders");

            rootContainer.Add(business, 55);
            rootContainer.Add(employees, 42);
            rootContainer.Add(shareholders, 3);

            Container general = new("General");
            Container mentors = new("Mentors");

            employees.Add(general, 10);
            employees.Add(mentors, 1);

            // add users
            shareholders.Add(stakersArray[0], 1);
            mentors.Add(stakersArray[0], 1);
            general.Add(stakersArray[0], 1);

            shareholders.Add(stakersArray[1], 1);
            general.Add(stakersArray[1], 1);

            shareholders.Add(stakersArray[2], 1);
            general.Add(stakersArray[2], 1);

            general.Add(stakersArray[3], 1);
            general.Add(stakersArray[4], 1);
            general.Add(stakersArray[5], 1);
            general.Add(stakersArray[6], 1);
            general.Add(stakersArray[7], 1);

            rootContainer.CalculateStake(true);
            rootContainer.PrintContents(true);

        }
    }
}