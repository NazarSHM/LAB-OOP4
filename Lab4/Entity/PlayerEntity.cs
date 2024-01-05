using Lab4.GameAccounts;

namespace Lab4.Entity;

public class PlayerEntity
{
    public int Id { get; set; }
    public string? UserName { get; }
    public decimal CurrentRating { get; set; }
    public GameAccount GameAccount { get; }
    
    public PlayerEntity(GameAccount gameAccount)
    {
        UserName = gameAccount.UserName;
        CurrentRating = gameAccount.CurrentRating;
        GameAccount = gameAccount;
    }
}