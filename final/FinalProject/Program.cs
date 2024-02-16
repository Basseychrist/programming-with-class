using System;
class Program
{
    static void Main(string[] args)
    {
        Library library = new Library();
        User user = new User("John Doe", 1);
        Database.Users.Add(user);

        Book book1 = new Book("The Great Gatsby", "F. Scott Fitzgerald", "9781234567890");
        library.AddBook(book1);

        Menu menu = new Menu(library, user);

        while (true)
        {
            menu.DisplayMenu();
        }
    }
}
