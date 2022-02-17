using AreYouFruits.Common.ComponentGeneration;
using GachiBird.Game;
using UnityEngine;

namespace GachiBird.Serialization
{
    public sealed class HighScoreSaverComponent : AbstractComponent<HighScoreSaver>
    {
#nullable disable
        [SerializeField] private SerializedInterface<IComponent<IGameSaver>> _gameSaver;
        [SerializeField] private SerializedInterface<IComponent<IScoreHolder>> _scoreHolder;
#nullable enable

        protected override HighScoreSaver Create()
        {
            return new HighScoreSaver(_gameSaver.GetHeldItem(), _scoreHolder.GetHeldItem());
        }
    }
}
