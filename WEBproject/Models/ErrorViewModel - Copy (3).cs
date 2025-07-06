public class File
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime DateUpdated { get; set; }
    public bool IsPublic { get; set; }
    public int UserId { get; set; }
    public User User { get; set; }
}