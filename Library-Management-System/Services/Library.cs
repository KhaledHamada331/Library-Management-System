public class Library
{
    private const int MaxBooks = 10;
    private const int MaxMembers = 10;
    private const int MaxBorrowRecords = 10;
    private int _nextBookId = 1;
    private int _nextMemberId = 1;
    private int _nextBorrowRecordId = 1;
    private int _bookCount = 0;
    private int _memberCount = 0;
    private int _borrowRecordCount = 0;
    private Book[] _books = new Book[MaxBooks];
    private Member[] _members = new Member[MaxMembers];
    private BorrowRecord[] _borrowRecords = new BorrowRecord[MaxBorrowRecords];
    public string AddBook(Book book)
    {
        if (_bookCount >= MaxBooks)
        {
            return "Cannot add more books. Maximum limit reached.";
        }
        book.Id = _nextBookId++;
        for (int i = 0; i < _books.Length; i++)
        {
            if (_books[i] == null)
            {
                _books[i] = book;
                _bookCount++;
                break;
            }
        }
        
        return $"Book '{book.Title}' added successfully with ID: {book.Id}";
    }




    
    
}