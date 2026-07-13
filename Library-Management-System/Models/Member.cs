public class Member : ISearchable
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public DateTime JoinDate { get; set; } = DateTime.Now;
    public Book[] BorrowedBooks { get; set; } = new Book[3];

    public bool MatchesQuery(string query)
    {
        return Name.Contains(query, StringComparison.OrdinalIgnoreCase) ||
               Email.Contains(query, StringComparison.OrdinalIgnoreCase);
    }
}