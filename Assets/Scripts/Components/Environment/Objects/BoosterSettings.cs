using System.Text.RegularExpressions;
using UnityEngine;

namespace GachiBird.Environment.Objects
{
    [CreateAssetMenu(fileName = "Booster", menuName = "ScriptableObjects/Booster", order = 1)]
    public class BoosterSettings : ScriptableObject
    {
#nullable disable
        [field: SerializeField] public BoosterInfo BoosterInfo { get; private set; }
#nullable enable

        [ContextMenu("Set default id")]
        private void SetDefaultId()
        {
            BoosterInfo boosterInfo = BoosterInfo;

            boosterInfo.Id = int.Parse(new Regex(@"\D").Replace(name, ""));
            
            this.BoosterInfo = boosterInfo;
        }
    }
}