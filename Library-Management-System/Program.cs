using System;


public class Program
{
    public static void Main(string[] args)
    {
        int input = -1;
        Library library = new Library();
        do
        {
            DisplayMenu();
            Console.WriteLine();
            Console.Write("Enter your choice: ");
            input = ReadValidInt(Console.ReadLine() ?? string.Empty);
            while (input < 0 || input > 8)
            {
                WarningMsg("Invalid choice. Please enter a number between 0 and 8.");
                Console.Write("Enter your choice: ");
                input = ReadValidInt(Console.ReadLine() ?? string.Empty);
            }
            switch (input)
            {
                case 1:
                    Book newBook = new Book();
                    Console.Write("Enter title: ");
                    newBook.Title = ReadValidString(Console.ReadLine() ?? string.Empty);
                    Console.Write("Enter author: ");
                    newBook.Author = ReadValidString(Console.ReadLine() ?? string.Empty);
                    Console.Write("Enter year: ");
                    newBook.Year = ReadValidInt(Console.ReadLine() ?? string.Empty);
                    Console.Write("Enter genre: ");
                    newBook.Genre = ReadValidString(Console.ReadLine() ?? string.Empty);
                    SuccessMsg(library.AddBook(newBook));
                    ConsoleClear();
                    break;
                case 2:
                    Console.WriteLine();
                    Console.WriteLine("Choose the subscription:");
                    Console.WriteLine("1. Basic (3 books)");
                    Console.WriteLine("2. Premium (10 books)");
                    Console.WriteLine();
                    Console.Write("Enter your choice: ");
                    int subscriptionChoice = ReadValidInt(Console.ReadLine() ?? string.Empty);
                    while (subscriptionChoice < 1 || subscriptionChoice > 2)
                    {
                        WarningMsg("Invalid choice. Please enter 1 or 2.");
                        Console.Write("Enter your choice: ");
                        subscriptionChoice = ReadValidInt(Console.ReadLine() ?? string.Empty);
                    }
                    Member? newMember = null;
                    if (subscriptionChoice == 1)
                    {
                        newMember = new Member();
                    }
                    else
                    {
                        newMember = new PremiumMember();
                    }
                    Console.Write("Enter name: ");
                    newMember.Name = ReadValidString(Console.ReadLine() ?? string.Empty);
                    Console.Write("Enter email: ");
                    newMember.Email = ReadValidString(Console.ReadLine() ?? string.Empty);
                    SuccessMsg(library.AddMember(newMember));
                    ConsoleClear();
                    break;
                case 3:
                    Console.WriteLine();
                    Console.Write("Enter member ID: ");
                    int memberId = ReadValidInt(Console.ReadLine() ?? string.Empty);
                    Console.Write("Enter book ID: ");
                    int bookId = ReadValidInt(Console.ReadLine() ?? string.Empty);
                    Console.WriteLine(library.BorrowBook(memberId, bookId));
                    ConsoleClear();
                    break;
                case 4:
                    Console.WriteLine();
                    Console.Write("Enter Book ID: ");
                    int returnBookId = ReadValidInt(Console.ReadLine() ?? string.Empty);
                    Console.WriteLine(library.ReturnBook(returnBookId));
                    ConsoleClear();
                    break;
                case 5:
                    Console.WriteLine();
                    Console.Write("Enter search query: ");
                    string query = ReadValidString(Console.ReadLine() ?? string.Empty);
                    var searchedBooks = library.SearchBooks(query);
                    var searchedMembers = library.SearchMembers(query);
                    if (searchedBooks.Length == 0)
                    {
                        WarningMsg("No books found matching the query.");
                    }
                    else
                    {
                        SuccessMsg($"Found {searchedBooks.Length} book(s):");
                        foreach (var book in searchedBooks)
                        {
                            Console.WriteLine(book.GetInfo());
                        }
                    }
                    if (searchedMembers.Length == 0)
                    {
                        WarningMsg("No members found matching the query.");
                    }
                    else
                    {
                        SuccessMsg($"Found {searchedMembers.Length} member(s):");
                        foreach (var member in searchedMembers)
                        {
                            Console.WriteLine(member.GetInfo());
                        }
                    }
                    ConsoleClear();
                    break;
                case 6:
                    var availableBooks = library.AvailableBooks();
                    if (availableBooks.Length == 0)
                    {
                        WarningMsg("No available books found.");
                    }
                    else
                    {
                        SuccessMsg($"Found {availableBooks.Length} available book(s):");
                        foreach (var book in availableBooks)
                        {
                            Console.WriteLine(book.GetInfo());
                        }
                    }
                    ConsoleClear();
                    break;
                case 7:
                    Console.WriteLine();
                    Console.Write("Enter member ID: ");
                    int memberIdForHistory = ReadValidInt(Console.ReadLine() ?? string.Empty);
                    var borrowedBooks = library.MemberBorrowHistory(memberIdForHistory);
                    if (borrowedBooks.Length == 0)
                    {
                        WarningMsg("No borrowed books found for this member.");
                    }
                    else
                    {
                        SuccessMsg($"Found {borrowedBooks.Length} borrowed book(s) for member ID {memberIdForHistory}:");
                        foreach (var record in borrowedBooks)
                        {
                            Console.WriteLine(

                               $"Book: {record.Book.Title} | " +
                               $"Borrowed: {record.BorrowDate:d} | " +
                               $"Returned: {(record.ReturnDate?.ToShortDateString() ?? "Not Returned")} | " +
                               $"Late: {(record.IsLate() ? "Yes" : "No")}");
                        }
                    }
                    ConsoleClear();
                    break;
                case 8:
                    Console.WriteLine();
                    var lateRecords = library.LateReturns();
                    if (lateRecords.Length == 0)
                    {
                        WarningMsg("No late borrow records found.");
                    }
                    else
                    {
                        SuccessMsg($"Found {lateRecords.Length} late borrow record(s):");
                        foreach (var record in lateRecords)
                        {
                            Console.WriteLine(
                               $"Book: {record.Book.Title} | " +
                               $"Member: {record.Member.Name} | " +
                               $"Borrowed: {record.BorrowDate:d} | " +
                               $"Returned: {(record.ReturnDate?.ToShortDateString() ?? "Not Returned")}");
                        }
                    }


                    ConsoleClear();
                    break;

                case 0:
                    ErrorMsg("Exiting the program.");
                    input = 0;
                    break;
            }
        } while (input != 0);
    }
    static void ErrorMsg(string msg)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(msg);
        Console.ResetColor();
    }
    static void SuccessMsg(string msg)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(msg);
        Console.ResetColor();
    }
    static void WarningMsg(string msg)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(msg);
        Console.ResetColor();
    }

    static void DisplayMenu()
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("Library Management System");
        Console.WriteLine("-------------------------");
        Console.ResetColor();
        Console.WriteLine("1. Add Book");
        Console.WriteLine("2. Add Member");
        Console.WriteLine("3. Borrow Book");
        Console.WriteLine("4. Return Book");
        Console.WriteLine("5. Search Books & Members");
        Console.WriteLine("6. Display Available Books");
        Console.WriteLine("7. Display Member Borrowed History");
        Console.WriteLine("8. Display Late Borrow Records");
        ErrorMsg("0. Exit");
    }


    static string ReadValidString(string input)
    {
        if (!string.IsNullOrWhiteSpace(input))
        {
            return input;
        }
        do
        {
            Console.WriteLine();
            ErrorMsg("Invalid input.");
            Console.Write("Please enter a valid input: ");
            input = Console.ReadLine() ?? string.Empty;

        } while (string.IsNullOrWhiteSpace(input));
        return input;
    }
    static int ReadValidInt(string input)
    {
        int number;
        if (int.TryParse(input, out number))
        {
            return number;
        }
        do
        {
            Console.WriteLine();
            ErrorMsg("Invalid input.");
            Console.Write("Please enter a valid number: ");
            input = Console.ReadLine() ?? string.Empty;

        } while (!int.TryParse(input, out number));
        return number;
    }
    static void ConsoleClear()
    {
        Console.WriteLine();
        Console.Write("Press any key to continue...");
        Console.ReadKey(true);
        Console.Clear();
    }
}
