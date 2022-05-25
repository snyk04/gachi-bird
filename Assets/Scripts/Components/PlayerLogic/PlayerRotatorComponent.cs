using System;
using AreYouFruits.Common.ComponentGeneration;
using UnityEngine;

namespace GachiBird.PlayerLogic
{
    public class PlayerRotatorComponent : AbstractComponent<PlayerRotator>
    {
#nullable disable
        [SerializeField] private SerializedInterface<IComponent<IJumpable>> _jumpable;
        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField] private Transform _transform;
        
        [SerializeField] private float _maxRotateAngle;
#nullable enable
        
        protected override PlayerRotator Create()
        {
            return new PlayerRotator(_jumpable.GetHeldItem(), _rigidbody, _transform, _maxRotateAngle);
        }

        private void Update()
        {
            HeldItem.Rotate();
        }
    }
}