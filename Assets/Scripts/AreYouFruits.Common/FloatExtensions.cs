namespace AreYouFruits.Common
{
    public static class FloatExtensions
    {
        public static int SecondsToMilliseconds(this float valueInSeconds)
        {
            return (int) (valueInSeconds * 1000);
        }
    }
}