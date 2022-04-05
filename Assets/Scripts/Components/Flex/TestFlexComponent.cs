using AreYouFruits.Common.ComponentGeneration;
using GachiBird.Environment.Objects;
using UnityEngine;

namespace GachiBird.Flex
{
    public class TestFlexComponent : AbstractComponent<TestFlex>
    {
#nullable disable
        [SerializeField] private BoosterSettings _boosterSettings;
#nullable enable
        
        protected override TestFlex Create()
        {
            return new TestFlex(_boosterSettings.BoosterInfo);
        }
    }
}