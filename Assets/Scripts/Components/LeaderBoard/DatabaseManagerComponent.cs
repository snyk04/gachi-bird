using System.IO;
using AreYouFruits.Common.ComponentGeneration;
using UnityEngine;

namespace GachiBird.LeaderBoard
{
    public class DatabaseManagerComponent : AbstractComponent<DatabaseManager>
    {
#nullable disable
        [SerializeField] private string _dataSource;
#nullable enable
        
        protected override DatabaseManager Create()
        {
            return new DatabaseManager(Path.Combine(Application.streamingAssetsPath, _dataSource));
        }
    }
}