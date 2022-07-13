using AreYouFruits.Common.ComponentGeneration;
using UnityEngine;

namespace GachiBird.Serialization
{
    public sealed class GameSaverComponent : AbstractComponent<GameSaverLoader>
    {
#nullable disable
        [SerializeField] private string _fileName = "SaveData.dat";
#nullable enable

        protected override GameSaverLoader Create()
        {
            return new GameSaverLoader(DataSaverFactory.Get(_fileName));
        }
    }
}
