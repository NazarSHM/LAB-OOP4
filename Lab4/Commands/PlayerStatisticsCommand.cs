using Lab4.Entity;
using Lab4.Entity.GameEntities;
using Lab4.Service;

namespace Lab4.Commands;

public class PlayerStatisticsCommand : ICommand
{
    private readonly GameService _gameService;

    public PlayerStatisticsCommand(GameService gameService)
    {
        _gameService = gameService;
    }

    public void Execute()
    {
        Console.Write("\nEnter a player's name to view stats: ");
        string? playerName = Console.ReadLine();

        PlayerEntity player = _gameService.ReadAccounts().
            FirstOrDefault(p => p.UserName != null && p.UserName.
                Equals(playerName, StringComparison.OrdinalIgnoreCase)) ?? throw new InvalidOperationException();

        PrintPlayerGamesInfo(player);
        Console.Write("\nDo you want to view information about another player? (y/n): ");
        string? response = Console.ReadLine();
        if (response != null && response.Equals("y", StringComparison.OrdinalIgnoreCase))
        {
            Execute();
        }
    }

    private void PrintPlayerGamesInfo(PlayerEntity player)
    {
        Console.WriteLine($"\nList of games for {player.UserName}:");
        foreach (GameEntity game in _gameService.ReadPlayerGamesByPlayerId(player.Id))
        {
            PrintGameInfo(game);
        }
    }

    private void PrintGameInfo(GameEntity game)
    {
        var result = _gameService.IsPlayerWinner(game.PlayerId, game.Id) ? "Win" : "Lose";
        
                Console.WriteLine("---------------------------------------------------------------");
                Console.WriteLine($"| {"Game #",5} | {"Result",6} | {"Rating Change",13} | {"New Rating",10} | {"Game Type",15} |");
                Console.WriteLine($"| {game.Id,5} | {result,6} | {game.ChangeOfRating,13} | {_gameService.GetPlayerRating(game.PlayerId),10} | {_gameService.GetGameTypeName(game),15} |");
                Console.WriteLine("---------------------------------------------------------------");
    }
}