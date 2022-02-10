#nullable enable

using AreYouFruits.Common.ComponentGeneration;
using GachiBird.Game;
using UnityEngine;

namespace GachiBird.Serialization
{
    public sealed class HighScoreSaverComponent : AbstractComponent<HighScoreSaver>
    {
#nullable disable
        [SerializeField] private AbstractComponent<IGameSaver> _gameSaver;
        [SerializeField] private AbstractComponent<IScoreHolder> _scoreHolder;
#nullable enable

        protected override HighScoreSaver Create()
        {
            return new HighScoreSaver(_gameSaver.HeldItem, _scoreHolder.HeldItem);
        }
    }
}
