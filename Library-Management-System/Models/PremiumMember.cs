public class PremiumMember : Member
{
    public const int MaxBorrowLimit = 10;
    public const int LoanDays = 30;
    public PremiumMember()
    {
        BorrowedBooks = new Book[MaxBorrowLimit];
    }
    public override string GetInfo()
    {
        return $"Premium Member Name: {Name}, Email: {Email}, Join Date: {JoinDate.ToShortDateString()}";
    }
}