using _6thElement.Application.Answers;
using _6thElement.Domain;

namespace _6thElement.Application.Questions;

public class QuestionResponseModel
{
    public string Description { get; set; }
    public string ImagePath { get; set; }
    public List<AnswerResponseModel> Answers { get; set; }
}
