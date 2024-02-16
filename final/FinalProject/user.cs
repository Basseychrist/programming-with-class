using System.Collections.Generic;

public class User
{
    public string Name { get; set; }
    public int ID { get; set; }
    public List<Book> BorrowedBooks { get; set; }

    public User(string name, int id)
    {
        Name = name;
        ID = id;
        BorrowedBooks = new List<Book>();
    }

    public void BorrowBook(Book book)
    {
        BorrowedBooks.Add(book);
        book.IsAvailable = false;
    }

    public void ReturnBook(Book book)
    {
        BorrowedBooks.Remove(book);
        book.IsAvailable = true;
    }
}