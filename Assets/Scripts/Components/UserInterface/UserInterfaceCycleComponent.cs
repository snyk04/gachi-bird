using AreYouFruits.Common.ComponentGeneration;

namespace GachiBird.UserInterface
{
    public class UserInterfaceCycleComponent : AbstractComponent<UserInterfaceCycle, IUserInterfaceCycle>
    {
        protected override UserInterfaceCycle Create()
        {
            return new UserInterfaceCycle();
        }
    }
}