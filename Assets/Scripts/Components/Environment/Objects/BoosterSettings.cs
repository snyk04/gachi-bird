#nullable enable

using UnityEngine;

namespace GachiBird.Environment.Objects
{
    [CreateAssetMenu(fileName = "Booster", menuName = "ScriptableObjects/Booster", order = 1)]
    public class BoosterSettings : ScriptableObject
    {
#nullable disable
        [field: SerializeField] public BoosterInfo BoosterInfo { get; private set; }
#nullable enable
    }
}