namespace KR_
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Books> books = Books.GetInfoOfBooks("input_books.txt");
            books.Sort();
            Data.WriteInfo(books, "output_books1.txt");
            List<Books> result = Books.GetInfoOfName(books);
            Data.WriteInfo(result, "output_books2.txt");
        }
    }
}