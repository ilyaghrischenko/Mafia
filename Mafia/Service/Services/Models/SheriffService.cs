using Domain.Enums;
using Domain.Interfaces.Models;
using Domain.Interfaces.Repositories;

namespace Service.Services.Models;

public class SheriffService(IUserRepository userRepository): ISheriffService
{
    private readonly IUserRepository _userRepository = userRepository;
    private bool _canShoot = true;
    
    public async Task<bool> Check(int userId)
    {
        var userToCheck = await _userRepository.Get(userId);
        if (userToCheck == null) return false;

        return userToCheck.Role.RoleName == RoleName.Mafia;
    }

    public async Task<bool> Shoot(int userId)
    {
        if (!_canShoot) return false;
        
        var userToShoot = await _userRepository.Get(userId);
        if (userToShoot == null) return false;
        
        userToShoot.Role.Statuses.Add(Status.Shot);
        await _userRepository.Update(userToShoot);
        
        _canShoot = false;
        return true;
    }
}