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
    

    public string AddMember(Member member)
    {
        if (_memberCount >= MaxMembers)
        {
            return "Cannot add more members. Maximum limit reached.";
        }
        member.Id = _nextMemberId++;
        for (int i = 0; i < _members.Length; i++)
        {
            if (_members[i] == null)
            {
                _members[i] = member;
                _memberCount++;
                break;
            }
        }
        
        return $"Member '{member.Name}' added successfully with ID: {member.Id}";
    }

    public string BorrowBook(int memberId, int bookId)
    {
        Book ?currentBook = null;
        Member ?currentMember = null;
        for (int i = 0; i < _books.Length; i++)
        {
            if (_books[i] != null && _books[i].Id == bookId)
            {
                currentBook = _books[i];
                break;
            }
        }
        if (currentBook == null)
        {
            return $"Book with ID {bookId} not found.";
        } else if (currentBook.IsAvailable == false)
        {
            return $"Book '{currentBook.Title}' is already borrowed.";
        }
        foreach (var member in _members)
        {
            if (member != null && member.Id == memberId)
            {
                currentMember = member;
                break;
            }
        }

        if (currentMember == null)
        {
            return $"Member with ID {memberId} not found.";
        }
                if (_borrowRecordCount >= MaxBorrowRecords)
        {
            return "Cannot create more borrow records. Maximum limit reached.";
        }
   

        for (int i = 0; i < currentMember.BorrowedBooks.Length; i++)
        {
            if (currentMember.BorrowedBooks[i] == null)
            {
                currentMember.BorrowedBooks[i] = currentBook;
                break;
            }
            else if (i == currentMember.BorrowedBooks.Length - 1)
            {
                return $"Member '{currentMember.Name}' has reached the maximum borrowing limit.";
            }
        }
     
        BorrowRecord borrowRecord = new BorrowRecord
        {
            Id = _nextBorrowRecordId++,
            Book = currentBook,
            Member = currentMember,
        };
        _borrowRecords[_borrowRecordCount++] = borrowRecord;
        currentBook.IsAvailable = false;
        return $"Book '{currentBook.Title}' borrowed successfully by member '{currentMember.Name}'.";
    }



    
    
}