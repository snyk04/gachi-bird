using System.Collections.Generic;
using GachiBird.Customization;

namespace GachiBird.Serialization
{
    public class StatusOfSkinsFiller
    {
        private readonly IGameSaver _gameSaver;
        private readonly IPlayerCustomizer _playerCustomizer;

        public StatusOfSkinsFiller(IGameSaver gameSaver, IPlayerCustomizer playerCustomizer)
        {
            _gameSaver = gameSaver;
            _playerCustomizer = playerCustomizer;

            FillStatusOfSkins();
        }

        private void FillStatusOfSkins()
        {
            Dictionary<int, bool> statusOfSkins = _gameSaver.LoadStatusOfSkins();
            foreach (PlayerSkinInfo playerSkinInfo in _playerCustomizer.PlayerSkinInfoArray)
            {
                if (!statusOfSkins.ContainsKey(playerSkinInfo.Id))
                {
                    statusOfSkins.Add(playerSkinInfo.Id, false);
                }
            }
            
            _gameSaver.SaveStatusOfMusic(statusOfSkins);
        }
    }
}