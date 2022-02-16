using GachiBird.PlayerLogic;

namespace GachiBird.Game
{
    public sealed class PlayerOutOfBoundsGameEnder
    {
        public PlayerOutOfBoundsGameEnder(IGameCycle gameCycle, IPlayerBordersTrigger playerBordersTrigger)
        {
            playerBordersTrigger.OnPlayerOutOfBounds += gameCycle.EndGame;
        }
    }
}
