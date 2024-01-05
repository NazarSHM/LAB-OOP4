using Lab4.Entity;
using Lab4.Entity.GameEntities;
using Lab4.Service;
using System;
using System.Linq;

namespace Lab4.Commands
{
    public class CreateGameCommand : ICommand
    {
        private readonly GameService _gameService;

        public CreateGameCommand(GameService gameService)
        {
            _gameService = gameService;
        }

       public void Execute()
{
    do
    {
        Console.Write("\nEnter a player name for the game: ");
        string playerName = GetUserInput();
        Console.WriteLine($"Debug: Player name entered: '{playerName}'");

        PlayerEntity player = _gameService.ReadAccounts()
            .FirstOrDefault(p => p.UserName?.Equals(playerName, StringComparison.OrdinalIgnoreCase) == true);

        if (player != null)
        {
            Console.WriteLine($"Debug: Player found - ID: {player.Id}, Name: {player.UserName}");
            CreateAndSaveGame(player);
        }
        else
        {
            Console.WriteLine($"Debug: Player not found.");
            Console.WriteLine("Player not found. Please ensure the player name is correct.");
        }

        Console.Write("Want to create another game? (y/n): ");
    } while (IsYes(Console.ReadLine()));
}

        private string GetUserInput()
        {
            return Console.ReadLine()?.Trim() ?? string.Empty;
        }

        private bool IsYes(string? input)
        {
            return input?.Equals("y", StringComparison.OrdinalIgnoreCase) ?? true;
        }

        private void CreateAndSaveGame(PlayerEntity player)
        {
            Console.WriteLine("Select the type of game:");
            Console.WriteLine("1. Standard Game");
            Console.WriteLine("2. Training Game");
            Console.WriteLine("3. Random Rating Game");

            if (int.TryParse(Console.ReadLine(), out int gameTypeChoice))
            {
                switch (gameTypeChoice)
                {
                    case 1:
                        HandleGameCreation(player, () => CreateStandardGame(player));
                        break;
                    case 2:
                        HandleGameCreation(player, () => new TrainingGameEntity(player.Id));
                        break;
                    case 3:
                        HandleGameCreation(player, () => new RandomRatingGameEntity(player.Id));
                        break;
                    default:
                        Console.WriteLine("Incorrect choice of game type.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid integer value.");
            }
        }

        private void HandleGameCreation(PlayerEntity player, Func<GameEntity> gameCreationFunc)
        {
            GameEntity game = gameCreationFunc.Invoke();

            if (game != null)
            {
                try
                {
                    _gameService.CreateGame(game);
                    Console.WriteLine($"The game is created! Game ID: {game.Id}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred while creating the game: {ex.Message}");
                }
            }
        }

        private GameEntity CreateStandardGame(PlayerEntity player)
        {
            Console.Write("Enter a rating for a standard game: ");
            if (decimal.TryParse(Console.ReadLine(), out decimal standardGameRating))
            {
                return new StandardGameEntity(standardGameRating, player.Id);
            }
            else
            {
                Console.WriteLine("Invalid rating input. Please enter a valid decimal value.");
                return null;
            }
        }
    }
}
