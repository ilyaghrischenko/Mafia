using Mafia.Domain.DbModels;
using Mafia.DTO.Models;
using Microsoft.AspNetCore.Http;

namespace Mafia.Domain.Interfaces.DbModelsServices;

public interface IUserService
{
    public Task AddFriend(int userId, int friendId);
    public Task DeleteFriend(int userId, int friendId);
    public Task ChangeLogin(string userId, string newLogin);
    public Task ChangePassword(string userId, string newPassword);
    public Task ChangeEmail(string userId, string newEmail);
    public Task ChangeAvatar(string userId, ChangeAvatarModel changeAvatarModel);

    
}