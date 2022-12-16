namespace Kr_1_charp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Books> books = Books.GetInfoOfBooks("input_books.txt");
            books.Sort();
            Data.WriteInfo(books, "output_books_1.txt");
            List<Books> result = Books.GetTitleOfBooks(books);
            Data.WriteInfo(result, "output_books_2.txt");
        }
    }
}