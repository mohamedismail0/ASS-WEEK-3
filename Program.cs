using System.Collections.ObjectModel;
//using ASS_WEEK_3;

namespace ASS_WEEK_3
{



    public class Book
    {
        public string title;
        public string author;
        public string ISBN;
        public bool availability;

        public Book(string title, string author, string iSBN, bool availability)
        {
            this.title = title;
            this.author = author;
            this.ISBN = iSBN;
            this.availability = availability;
        }
    }

    public class Library
    {
        List<Book> collection = new();

        public string AddBook(Book book)
        {
            collection.Add(book);
            return "the book is added ";
        }

        public string Search(string key)
        {
            for (int i = 0; i <collection.Count; i++)
            {
                if (key == collection[i].title || key == collection[i].author)
                {
                    return "the book is found ";
                }
            }
            return "the book is not found ";
        }

        public string Borrow(string key)
        {
            for (int i = 0; i < collection.Count; i++)
            {
                if ((key == collection[i].title || key == collection[i].author) && collection[i].availability)
                {
                    collection[i].availability = false;
                    return "the book is availabile , you can borrow it ";
                }
            }
            return "the book is not found ";
        }

        public string Return(string key)
        {
            for (int i = 0; i < collection.Count; i++)
            {
                if (key == collection[i].title || key == collection[i].author)
                {
                    collection[i].availability = true; ;
                    return "the book is returned ";
                }

            }
            return "the book is not ours ";
        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Library library = new Library();

            // Adding books to the library

            Console.WriteLine(library.AddBook(new Book("The Great Gatsby", "F. Scott Fitzgerald", "9780743273565", true)));
            Console.WriteLine(library.AddBook(new Book("To Kill a Mockingbird", "Harper Lee", "9780061120084", true)));
            Console.WriteLine(library.AddBook(new Book("1984", "George Orwell", "9780451524935", true)));



            Console.WriteLine("Hello sir , Welcome to or library :) ");
            char option;

            do
            {
                Console.WriteLine("\nHow can i help you? ");
                option = Convert.ToChar(Console.ReadLine());

                Console.WriteLine("===== MENU =====");
                Console.WriteLine("B - borrow a book ");
                Console.WriteLine("A - Add a book");
                Console.WriteLine("R - Return a book");
                Console.WriteLine("S - Search for a book");
                Console.WriteLine("Q - Quit");
                Console.WriteLine("==============================\n");

                switch (option)
                {
                    case 'b':
                    case 'B':
                        Console.WriteLine(library.Borrow("1984"));
                        break;

                    case 'a':
                    case 'A':
                        Console.WriteLine(library.AddBook(new Book("atomic habits", "james clear", "97654343234", true)));
                        break;

                    case 'r':
                    case 'R':
                        Console.WriteLine(library.Return("1984"));
                        break;

                    case 's':
                    case 'S':
                        Console.WriteLine(library.Search("The Great Gatsby"));
                        break;

                    default:
                        Console.WriteLine("invalid input.");
                        break;
                }


            } while (option != 'q' && option != 'Q');
        }
    }
}

