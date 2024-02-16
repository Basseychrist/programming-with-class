using System;

public class Loan
{
    public Book Book { get; set; }
    public DateTime LoanDate { get; set; }
    public DateTime DueDate { get; set; }
    public bool IsReturned { get; set; }

    public Loan(Book book, DateTime loanDate, DateTime dueDate)
    {
        Book = book;
        LoanDate = loanDate;
        DueDate = dueDate;
        IsReturned = false;
    }
}
