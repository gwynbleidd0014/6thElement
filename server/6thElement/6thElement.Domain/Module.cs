namespace _6thElement.Domain;

public class Module
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Type { get; set; }
    public string ImagePath { get; set; }
    public List<Chapter>? Chapters { get; set; }
}
