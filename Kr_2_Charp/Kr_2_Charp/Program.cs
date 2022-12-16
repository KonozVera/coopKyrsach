using System.IO;

namespace Kr_2_Charp
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Candy> candies = Candy.GetInfoOfCandy("input_candy.txt");
            candies.Sort();
            Data.WriteInfo(candies, "output_candy1.txt");
            List<Candy> result = Candy.GetInfoOfName(candies);
            Data.WriteInfo(result, "output_candy2.txt");
        }
    }
}