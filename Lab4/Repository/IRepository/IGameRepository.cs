using Lab4.Entity.GameEntities;

namespace Lab4.Repository.IRepository;

public interface IGameRepository
{
    void CreateGame(GameEntity game);
    GameEntity ReadGameById(int gameId);
    IEnumerable<GameEntity> ReadAllGames();
}