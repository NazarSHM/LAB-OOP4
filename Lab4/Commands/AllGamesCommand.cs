using Lab4.Entity.GameEntities;
using Lab4.Service;

namespace Lab4.Commands;

public class AllGamesCommand: ICommand
{
    private readonly GameService _gameService;

    public AllGamesCommand(GameService gameService)
    {
        _gameService = gameService;
    }
    
    public void Execute()
    {
        Console.WriteLine("\nList of all games:");
        foreach (GameEntity game in _gameService.ReadGames())
        {
            PrintGameInfo(game);
        }
    }
    
    private void PrintGameInfo(GameEntity game)
    {
        String result = _gameService.IsPlayerWinner(game.PlayerId, game.Id) ? "Win" : "Lose";
         Console.WriteLine("---------------------------------------------------------------");
                Console.WriteLine($"| {"Game #",5} | {"Result",6} | {"Rating Change",13} | {"New Rating",10} | {"Game Type",15} |");
                Console.WriteLine($"| {game.Id,5} | {result,6} | {game.ChangeOfRating,13} | {_gameService.GetPlayerRating(game.PlayerId),10} | {_gameService.GetGameTypeName(game),15} |");
                Console.WriteLine("---------------------------------------------------------------");
    }
}