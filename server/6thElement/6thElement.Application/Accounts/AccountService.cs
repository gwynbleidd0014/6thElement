﻿using _6thElement.Application.Users;
using _6thElement.Domain.Users;
using Mapster;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

namespace _6thElement.Application.Accounts;

public class AccountService : IAccountsService
{
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;

    public AccountService(UserManager<User> userManager, SignInManager<User> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    public async Task<User?> LoginUserAsync(UserLoginModel model)
    {
        var user = await _userManager.FindByEmailAsync(model.Email) ?? throw new Exception("User Not Found");
        var result = await _signInManager.CheckPasswordSignInAsync(user, model.Password, false);
        if (result.Succeeded)
        {
            return user;
        }

        return null;
    }

    public async Task<bool> CreateUserAsync(UserRegisterModel model)
    { 
        var user = model.Adapt<User>();

        var oldUser = await _userManager.FindByEmailAsync(model.Email);

        if (oldUser != null)
            throw new Exception("User Already Exists");

        var result = await _userManager.CreateAsync(user, model.Password);

        if (result.Succeeded)
            return true;

        return false;
    }
}