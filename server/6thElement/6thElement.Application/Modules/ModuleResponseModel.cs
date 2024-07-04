using _6thElement.Application.Chapters;
using _6thElement.Domain;

namespace _6thElement.Application.Modules;

public class ModuleResponseModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Type { get; set; }
    public List<ChapterResponseModel>? Chapters { get; set; }
}
