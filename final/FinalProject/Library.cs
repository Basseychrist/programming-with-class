using System;
using System.Collections.Generic;

public class Library
{
    private List<Book> books;

    public Library()
    {
        books = new List<Book>();
    }

    public void AddBook(Book book)
    {
        books.Add(book);
    }

    public void RemoveBook(Book book)
    {
        books.Remove(book);
    }

    public List<Book> SearchBooks(string searchTerm)
    {
        List<Book> result = new List<Book>();

        foreach (Book book in books)
        {
            if (book.Title.ToLower().Contains(searchTerm.ToLower()) || 
                book.Author.ToLower().Contains(searchTerm.ToLower()) ||
                book.ISBN.ToLower().Contains(searchTerm.ToLower()))
            {
                result.Add(book);
            }
        }

        return result;
    }
}

