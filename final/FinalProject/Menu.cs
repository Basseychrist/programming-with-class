using System;
public class Menu
{
    private Library library;
    private User user;

    public Menu(Library library, User user)
    {
        this.library = library;
        this.user = user;
    }

    public void DisplayMenu()
    {
        Console.WriteLine("1. Add a book");
        Console.WriteLine("2. Borrow a book");
        Console.WriteLine("3. Return a book");
        Console.WriteLine("4. Search for books");
        Console.WriteLine("5. Exit");

        int choice = int.Parse(Console.ReadLine());

        switch (choice)
        {
            case 1:
                AddBook();
                break;
            case 2:
                BorrowBook();
                break;
            case 3:
                ReturnBook();
                break;
            case 4:
                SearchBooks();
                break;
            case 5:
                Environment.Exit(0);
                break;
            default:
                Console.WriteLine("Invalid choice");
                break;
        }
    }

    private void AddBook()
    {
        Console.WriteLine("Enter the title of the book:");
        string title = Console.ReadLine();

        Console.WriteLine("Enter the author of the book:");
        string author = Console.ReadLine();

        Console.WriteLine("Enter the ISBN of the book:");
        string isbn = Console.ReadLine();

        Book book = new Book(title, author, isbn);
        library.AddBook(book);
        Console.WriteLine("Book added successfully.");
    }

    private void BorrowBook()
    {
        Console.WriteLine("Enter the title of the book you want to borrow:");
        string title = Console.ReadLine();

        Book book = library.SearchBooks(title).FirstOrDefault(b => b.IsAvailable);

        if (book != null)
        {
        user.BorrowBook(book);
        Console.WriteLine("Book borrowed successfully.");
        }   
        else
        {
            Console.WriteLine("Book not available for borrowing.");
        }
    }

    private void ReturnBook()
    {
        Console.WriteLine("Enter the title of the book you want to return:");
        string title = Console.ReadLine();

        Book book = user.BorrowedBooks.Find(b => b.Title == title);

        if (book != null)
        {
            user.ReturnBook(book);
            Console.WriteLine("Book returned successfully.");
        }
        else
        {
            Console.WriteLine("Book not found in your borrowed list.");
        }
    }

    private void SearchBooks()
    {
        Console.WriteLine("Enter the title or author of the book:");
        string searchTerm = Console.ReadLine();

        var books = library.SearchBooks(searchTerm);

        if (books.Count > 0)
        {
            foreach (var book in books)
            {
                Console.WriteLine($"Title: {book.Title}, Author: {book.Author}, ISBN: {book.ISBN}, Available: {(book.IsAvailable ? "Yes" : "No")}");
            }
        }
        else
        {
            Console.WriteLine("No books found matching the search term.");
        }
    }
}
