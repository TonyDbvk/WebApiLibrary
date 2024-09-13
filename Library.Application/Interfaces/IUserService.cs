﻿using Library.Domain.Models;

namespace Library.Application.Interfaces
{
    public interface IUserService
    {
        Task<bool> AuthenticateUserAsync(string username, string password);
        Task<bool> DeleteUserAsync(Guid id);
        Task<List<User>> GetAllUsersAsync();
        Task<User> GetUserByIdAsync(Guid id);
        Task<User> GetUserByUsernameAsync(string username);
        Task<Guid> RegisterUserAsync(string username, string password, string firstName, string lastName,string email);
        Task<bool> UpdateUserAsync(User user);
        Task<string> GenerateJwtTokenAsync(string username, string password);
    }
}