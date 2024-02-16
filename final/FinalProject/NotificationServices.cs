using System;

public class NotificationService
{
      public void NotifyOverdue(User user, Book book)
        {
            // Send notification to user about overdue book
            Console.WriteLine($"Notification sent to {user.Name} about the overdue book: {book.Title}");
        }
}
