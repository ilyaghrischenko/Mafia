using Mafia.Domain.Enums;
using Mafia.Domain.Interfaces.Repositories;

namespace Mafia.Domain.DbModels;

public class GameRole
{
    private readonly IUserRepository _userRepository;
    
    public int Id { get; set; }
    public RoleName RoleName { get; set; }
    public string Description { get; set; }
    public List<Status> Statuses { get; set; } = new();
    public int countVotes { get; set; } = 0;
    
    public GameRole() { }
    public GameRole(RoleName roleName, string description, IUserRepository userRepository)
    {
        RoleName = roleName;
        Description = description;
        _userRepository = userRepository;
    }
    
    //TODO: create services
    public async Task<bool> Vote(int userId)
    {
        var userToVote = await _userRepository.Get(userId);
        if (userToVote == null) return false;
        
        userToVote.GameRole.countVotes++;
        // await _userRepository.Update(userToVote);
        return true;
    }
    
    public override string ToString()
        => $"GameRole: {RoleName}, Description: {Description}";
}