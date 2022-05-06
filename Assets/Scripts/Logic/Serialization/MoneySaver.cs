using GachiBird.Game;

namespace GachiBird.Serialization
{
    public class MoneySaver
    {
        public MoneySaver(IGameSaver gameSaver, IMoneyHolder moneyHolder)
        {
            moneyHolder.OnMoneyChanged += () => gameSaver.SaveAmountOfMoney(moneyHolder.Money);
        }
    }
}