namespace rediRND
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Container firstContainer = new Container("first", new decimal[3]);
            Container secondContainer = new Container("second", new decimal[4]);

            ContainerStructural rootContainer = new ContainerStructural( 1M, new Container[] {firstContainer, secondContainer});

            int[] weights = new int[] {1, 3};            

            rootContainer.CalculateWeightedSplit(weights);
            rootContainer.PrintContainers();

            firstContainer.CalculateEvenSplit();
            firstContainer.PrintStakers();

            secondContainer.CalculateWeightedSplit(new int[] {8, 16, 13, 35});
            secondContainer.PrintStakers();

        }

    }
}