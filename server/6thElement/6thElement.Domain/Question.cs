namespace _6thElement.Domain;

public class Question
{
    public int Id { get; set; }
    public string Description { get; set; }
    public int ChapterId { get; set; }
    public string ImagePath { get; set; }
    public Chapter Chapter { get; set; }
    public List<Answer> Answers { get; set; }
}
