using UnityEngine;

namespace Components.Shop
{
    [CreateAssetMenu(fileName = "Player skin", menuName = "ScriptableObjects/Player skin", order = 2)]
    public class PlayerSkinSettings : ScriptableObject
    {
        [field: SerializeField] public PlayerSkinInfo PlayerSkinInfo { get; private set; }
    }
}