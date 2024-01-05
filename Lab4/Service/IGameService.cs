using Lab4.Entity;
using Lab4.Entity.GameEntities;

namespace Lab4.Service;

public interface IGameService
{
    void CreateAccount(PlayerEntity player);
    IEnumerable<PlayerEntity> ReadAccounts();
    void CreateGame(GameEntity game);
    IEnumerable<GameEntity> ReadPlayerGamesByPlayerId(int playerId);
    IEnumerable<GameEntity> ReadGames();
    bool IsPlayerWinner(int playerId, int gameId);
    decimal GetPlayerRating(int playerId);
    string GetGameTypeName(GameEntity game);
    decimal CalculateWinPoints(PlayerEntity player, decimal changeOfRating);
    decimal CalculateLosePoints(PlayerEntity player, decimal changeOfRating);
}