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
                new Staker("Josh"), new Staker("Mike"), new Staker("Chris"), new Staker("Kelly"), 
                new Staker("Jaxon"), new Staker("Jarrad"), new Staker("Garrett"), new Staker("Knox") 
            };
            Container<Staker> stakers = new ("StakerObjects", stakersArray);

            // build structure
            Container<IStaker> business = new("Business");
            Container<IStaker> employees = new("Employees");
            Container<IStaker> shareholders = new("Shareholders");

            rootContainer.Add(business, 55);
            rootContainer.Add(employees, 42);
            rootContainer.Add(shareholders, 3);

            Container<IStaker> general = new("General");
            Container<IStaker> mentors = new("Mentors");

            employees.Add(general, 10);
            employees.Add(mentors, 11);

            // add users
            shareholders.Add(stakersArray[0], 1);
            mentors.Add(stakersArray[0], 1);

            general.Add(stakersArray[2], 1);
            general.Add(stakersArray[3], 1);
            general.Add(stakersArray[1], 1);
            general.Add(stakersArray[4], 1);
            general.Add(stakersArray[5], 1);
            general.Add(stakersArray[6], 1);
            general.Add(stakersArray[7], 1);

            rootContainer.CalculateStake(true);
            rootContainer.PrintContents(true);

        }
    }
}