using AreYouFruits.Common.ComponentGeneration;

namespace GachiBird.UserInterface
{
    public class UserInterfaceCycleComponent : AbstractComponent<UserInterfaceCycle>
    {
        protected override UserInterfaceCycle Create()
        {
            return new UserInterfaceCycle();
        }
    }
}