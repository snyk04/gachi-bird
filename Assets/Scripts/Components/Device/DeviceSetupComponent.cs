using AreYouFruits.Common.ComponentGeneration;

namespace GachiBird.Device
{
    public class DeviceSetupComponent : AbstractComponent<DeviceSetup>
    {
        protected override DeviceSetup Create() => new DeviceSetup();
    }
}