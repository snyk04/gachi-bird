using GachiBird.Game;

namespace GachiBird.Serialization
{
    public class MoneySaver
    {
        public MoneySaver(IGameSaver gameSaverLoader, IMoneyHolder moneyHolder)
        {
            moneyHolder.OnMoneyChanged += () => gameSaverLoader.MoneyAmount = moneyHolder.Money;
        }
    }
}