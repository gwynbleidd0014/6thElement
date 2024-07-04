using _6thElement.Application.Questions;
using _6thElement.Domain;

namespace _6thElement.Application.Chapters;

public class ChapterResponseModel
{
    public int Id { get; set; }
    public int Order { get; set; }
    public List<QuestionResponseModel> Questions { get; set; }
}
