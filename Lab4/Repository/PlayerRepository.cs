using Lab4.Entity;
using Lab4.Repository.IRepository;

namespace Lab4.Repository;

public class PlayerRepository: IPlayerRepository
{
    private readonly List<PlayerEntity> _players;

    public PlayerRepository(List<PlayerEntity> players)
    {
        _players = players;
    }

    public void CreatePlayer(PlayerEntity player)
    {
        player.Id = _players.Count + 1;
        _players.Add(player);
    }

    public PlayerEntity ReadPlayerById(int playerId)
    {
        return _players.FirstOrDefault(p => p.Id == playerId) ?? throw new InvalidOperationException();
    }

    public IEnumerable<PlayerEntity> ReadAllPlayers()
    {
        return _players;
    }
    
    public void CreateAccount(PlayerEntity player)
    {
        player.Id = _players.Count + 1;
        _players.Add(player);
    }

    public IEnumerable<PlayerEntity> ReadAccounts()
    {
        return _players;
    }
    
    public PlayerEntity ReadAccountById(int playerId)
    {
        return _players.FirstOrDefault(p => p.Id == playerId) ?? throw new InvalidOperationException();
    }
    
    public void UpdateRating(int playerId, decimal newRating)
    {
        var player = _players.FirstOrDefault(p => p.Id == playerId);
        if (player != null)
        {
            player.CurrentRating = newRating;
        }
    }
}