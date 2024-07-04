using _6thElement.Domain;
using Microsoft.AspNetCore.DataProtection.KeyManagement.Internal;

namespace _6thElement.Application.Questions;

public interface IQuestionRepository
{
    public Task<Question?> GetByIdAsync(int id, CancellationToken cancellationToken);
}
