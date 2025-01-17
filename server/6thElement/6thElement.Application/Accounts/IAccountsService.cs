﻿using _6thElement.Application.Users;
using _6thElement.Domain.Users;

namespace _6thElement.Application.Accounts;

public interface IAccountsService
{
    public Task<User?> LoginUserAsync(UserLoginModel model);
    public Task<bool> CreateUserAsync(UserRegisterModel model);
    public Task<List<string>> GetUserRoles(User model);
    public Task<UserResponseModel> GetUserById(string id);
}
