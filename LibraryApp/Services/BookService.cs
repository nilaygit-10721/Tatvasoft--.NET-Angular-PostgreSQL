using LibraryApp.Models;

namespace LibraryApp.Services
{
    public class BookService
    {
        private List<Book> books;

        public BookService()
        {
            books = new List<Book>()
            {
                new Book { Id = 1, Title = "Book A", Author = "Author 1", Genre = "Fiction" },
                new Book { Id = 2, Title = "Book B", Author = "Author 2", Genre = "Non-Fiction" },
                new Book { Id = 3, Title = "Book C", Author = "Author 3", Genre = "Drama" }
            };
        }

        public List<Book> GetBooks() => books;

        public Book GetBookById(int id) =>
            books.FirstOrDefault(b => b.Id == id);

        public void AddBook(Book book)
        {
            book.Id = books.Count + 1;
            books.Add(book);
        }

        public int UpdateBook(Book updatedBook)
        {
            var book = GetBookById(updatedBook.Id);
            if (book == null) return -1;

            book.Title = updatedBook.Title;
            book.Author = updatedBook.Author;
            book.Genre = updatedBook.Genre;
            return 1;
        }

        public int DeleteBook(int id)
        {
            var book = GetBookById(id);
            if (book == null) return -1;

            books.Remove(book);
            return 1;
        }
    }
}
