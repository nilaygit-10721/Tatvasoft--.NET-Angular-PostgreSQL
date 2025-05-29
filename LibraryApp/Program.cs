using LibraryApp.Models;
using LibraryApp.Services;

BookService bookService = new BookService();
bool running = true;

while (running)
{
    Console.WriteLine("\nLibrary Menu:");
    Console.WriteLine("1. View all books");
    Console.WriteLine("2. View book by ID");
    Console.WriteLine("3. Add a book");
    Console.WriteLine("4. Update a book");
    Console.WriteLine("5. Delete a book");
    Console.WriteLine("6. Exit");
    Console.Write("Enter your choice: ");
    int choice = int.Parse(Console.ReadLine());

    switch (choice)
    {
        case 1:
            var books = bookService.GetBooks();
            foreach (var b in books)
                Console.WriteLine($"{b.Id}. {b.Title} by {b.Author} ({b.Genre})");
            break;

        case 2:
            Console.Write("Enter book ID: ");
            int id = int.Parse(Console.ReadLine());
            var book = bookService.GetBookById(id);
            if (book != null)
                Console.WriteLine($"{book.Id}: {book.Title} by {book.Author} ({book.Genre})");
            else
                Console.WriteLine("Book not found.");
            break;

        case 3:
            Book newBook = new Book();
            Console.Write("Title: "); newBook.Title = Console.ReadLine();
            Console.Write("Author: "); newBook.Author = Console.ReadLine();
            Console.Write("Genre: "); newBook.Genre = Console.ReadLine();
            bookService.AddBook(newBook);
            Console.WriteLine("Book added!");
            break;

        case 4:
            Book updateBook = new Book();
            Console.Write("Enter book ID to update: ");
            updateBook.Id = int.Parse(Console.ReadLine());
            Console.Write("New Title: "); updateBook.Title = Console.ReadLine();
            Console.Write("New Author: "); updateBook.Author = Console.ReadLine();
            Console.Write("New Genre: "); updateBook.Genre = Console.ReadLine();
            int updateResult = bookService.UpdateBook(updateBook);
            Console.WriteLine(updateResult == 1 ? "Updated!" : "Book not found.");
            break;

        case 5:
            Console.Write("Enter book ID to delete: ");
            int deleteId = int.Parse(Console.ReadLine());
            int deleteResult = bookService.DeleteBook(deleteId);
            Console.WriteLine(deleteResult == 1 ? "Deleted!" : "Book not found.");
            break;

        case 6:
            running = false;
            Console.WriteLine("Thank you,Goodbye!");
            break;

        default:
            Console.WriteLine("Invalid choice.");
            break;
    }
}
