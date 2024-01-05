using Lab4.Entity;
using Lab4.Entity.GameEntities;

namespace Lab4;

public class DbContext
{
    public List<PlayerEntity> Players { get; } = new();
    public List<GameEntity> Games { get; } = new();
}