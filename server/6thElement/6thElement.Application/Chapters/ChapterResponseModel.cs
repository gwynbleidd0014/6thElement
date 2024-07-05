using _6thElement.Application.Questions;

namespace _6thElement.Application.Chapters;

public class ChapterResponseModel
{
    public int Id { get; set; }
    public int Order { get; set; }
    public int ModuleId { get; set; }
    public List<QuestionResponseModel> Questions { get; set; }
}
