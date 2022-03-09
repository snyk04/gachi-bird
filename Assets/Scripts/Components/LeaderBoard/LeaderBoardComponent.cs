using AreYouFruits.Common.ComponentGeneration;
using GachiBird.Game;
using GachiBird.Serialization;
using UnityEngine;

namespace GachiBird.LeaderBoard
{
    public class LeaderBoardComponent : AbstractComponent<LeaderBoard>
    {
#nullable disable
        [SerializeField] private SerializedInterface<IComponent<IScoreHolder>> _scoreHolder;
        [SerializeField] private SerializedInterface<IComponent<IDatabaseManager>> _databaseManager;
        [SerializeField] private SerializedInterface<IComponent<IGameSaver>> _gameSaver;
#nullable enable
        
        protected override LeaderBoard Create()
        {
            return new LeaderBoard(_scoreHolder.GetHeldItem(), _databaseManager.GetHeldItem(), _gameSaver.GetHeldItem());
        }
    }
}