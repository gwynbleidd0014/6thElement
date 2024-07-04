using Microsoft.AspNetCore.Identity;

namespace _6thElement.Domain.Users;

public class User : IdentityUser
{
    public int Age { get; set; }
}
