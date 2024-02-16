using System.Collections.Generic;

public static class Database
{
        public static List<Book> Books { get; set; }
        public static List<User> Users { get; set; }

        static Database()
        {
            Books = new List<Book>();
            Users = new List<User>();
        }
}
