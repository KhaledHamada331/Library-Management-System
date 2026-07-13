public class Book : LibraryItem, ISearchable
{
    public string Author { get; set; } = string.Empty;
    public int Year { get; set; }
    public string Genre { get; set; } = string.Empty;
    public bool IsAvailable { get; set; } = true;

    public override string GetInfo()
    {
        return $"Book Title: {Title}, Author: {Author}, Year: {Year}, Genre: {Genre}, Added Date: {AddedDate.ToShortDateString()}, Available: {IsAvailable}";
    }

    public bool MatchesQuery(string query)
    {
        return Title.Contains(query, StringComparison.OrdinalIgnoreCase) ||
               Author.Contains(query, StringComparison.OrdinalIgnoreCase) ||
               Genre.Contains(query, StringComparison.OrdinalIgnoreCase); 

        
    }
}