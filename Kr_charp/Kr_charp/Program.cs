namespace Kr_charp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Animals> animals = Animals.GetListOfAnimals("input_animals.txt");
            animals.Sort();
            Data.WriteInfo(animals, "output_animals_1.txt");
            List<Animals> result = Animals.GetNameOfAnimals(animals);
            Data.WriteInfo(result, "output_animals_2.txt");
        }
    }
}