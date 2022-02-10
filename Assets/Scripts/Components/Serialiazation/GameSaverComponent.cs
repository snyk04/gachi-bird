#nullable enable

using AreYouFruits.Common.ComponentGeneration;
using GachiBird.Game;
using UnityEngine;

namespace GachiBird.Serialization
{
    public sealed class GameSaverComponent : AbstractComponent<IGameSaver>
    {
#nullable disable
        [SerializeField] private string _fileName = "SaveData.dat";
#nullable enable

        protected override IGameSaver Create()
        {
            return new GameSaver(DataSaverFactory.Get<SaveData>(_fileName));
        }
    }
}
