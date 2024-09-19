using Mafia.Domain.DbModels;

namespace Mafia.Domain.Interfaces.DbModelsServices;

public interface IUserService
{
    public Task<bool> AddFriend(User user, User friend);
    public Task<bool> DeleteFriend(User user, User friend);
    public Task ChangeLogin(string userLogin, string newLogin);
    public Task ChangePassword(string userLogin, string newPassword);
    public Task ChangeEmail(string userLogin, string newEmail);
    public Task ChangeAvatar(string userLogin, byte[] newAvatar);
}