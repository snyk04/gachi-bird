using AreYouFruits.Common.ComponentGeneration;
using GachiBird.Game;
using UnityEngine;

namespace GachiBird.LeaderBoard
{
    public class LeaderBoardUpdaterComponent : AbstractComponent<LeaderBoardUpdater>
    {
#nullable disable
        [SerializeField] private SerializedInterface<IComponent<IScoreHolder>> _scoreHolder;
#nullable enable

        protected override void OnDestroy()
        {
            base.OnDestroy();
            HeldItem.OnDestroy();
        }
        
        protected override LeaderBoardUpdater Create()
        {
            return new LeaderBoardUpdater(_scoreHolder.GetHeldItem());
        }
    }
}