public abstract class LibraryItem
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public DateTime AddedDate { get; set; }

    public abstract string GetInfo();
}