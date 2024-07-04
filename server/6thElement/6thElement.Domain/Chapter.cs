namespace _6thElement.Domain;

public class Chapter
{
    public int Id { get; set; }
    public int Order { get; set; }
    public int ModuleId { get; set; }
    public Module Module { get; set; }
    public List<Question> Questions { get; set; }
}
