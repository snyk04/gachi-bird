using AreYouFruits.Common.ComponentGeneration;
using GachiBird.Game;
using UnityEngine;

namespace GachiBird.LeaderBoard
{
    public class LeaderBoardComponent : AbstractComponent<LeaderBoard>
    {
#nullable disable
        [SerializeField] private SerializedInterface<IComponent<IScoreHolder>> _scoreHolder;
        [SerializeField] private SerializedInterface<IComponent<IDatabaseManager>> _databaseManager;
        [SerializeField] private string _userName;
#nullable enable
        
        protected override LeaderBoard Create()
        {
            return new LeaderBoard(_scoreHolder.GetHeldItem(), _databaseManager.GetHeldItem(), _userName);
        }
    }
}