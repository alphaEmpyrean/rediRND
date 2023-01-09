namespace rediRND
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Container container = new Container(1m, new decimal[10]);

            container.CalculateEvenSplit();
            container.PrintStakers();

            int[] weights = new int[container.Stakers.Length];
            for (int i = 0; i < weights.Length; i++)
                weights[i] = i;

            container.CalculateWeightedSplit(weights);
            container.PrintStakers();

        }

    }
}