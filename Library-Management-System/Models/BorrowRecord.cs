public class BorrowRecord
{
    public int Id { get; set; }
    public Book Book { get; set; } = null!;
    public Member Member { get; set; } = null!;
    public DateTime BorrowDate { get; set; } 
    public DateTime? ReturnDate { get; set; }
    private const int RegularLoanDays = 14;
    private bool IsLateBasedOnDays(int days , DateTime returnDate)
    {
        return (returnDate - BorrowDate) > TimeSpan.FromDays(days);
    }

    public BorrowRecord()
    {
       
        BorrowDate = DateTime.Now;
    
    }
    public bool IsLate()
    {
        if (Member is PremiumMember)
        {
            return IsLateBasedOnDays(PremiumMember.LoanDays, ReturnDate ?? DateTime.Now);
        }
        
        return IsLateBasedOnDays(RegularLoanDays, ReturnDate ?? DateTime.Now);
        
    }
}