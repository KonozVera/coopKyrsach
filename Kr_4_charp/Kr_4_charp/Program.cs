namespace Kr_4_charp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Flowers> flowers = Flowers.GetInfoOfFlowers("input_flowers.txt");
            flowers.Sort();
            Data.WriteInfo(flowers, "output_flowers1.txt");
            List<Flowers> result = Flowers.GetInfofOfName(flowers);
            Data.WriteInfo(result, "output_flowers2.txt");

        }
    }
}