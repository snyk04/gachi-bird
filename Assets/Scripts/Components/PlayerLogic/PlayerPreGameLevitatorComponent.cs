﻿#nullable enable

using AreYouFruits.Common.ComponentGeneration;
using GachiBird.Game;
using UnityEngine;

namespace GachiBird.PlayerLogic
{
    public class PlayerPreGameLevitatorComponent : AbstractComponent<PlayerPreGameLevitator>
    {
#nullable disable
        [SerializeField] private AbstractComponent<IGameCycle> _gameCycle;
        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField] private float _defaultGravityScale;
#nullable enable
        
        protected override PlayerPreGameLevitator Create()
        {
            var item = new PlayerPreGameLevitator(_gameCycle.HeldItem, _rigidbody, _defaultGravityScale);

            item.Start();

            return item;
        }
    }
}
