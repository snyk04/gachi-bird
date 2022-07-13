using System.Collections.Generic;
using System.Linq;
using GachiBird.Customization;

namespace GachiBird.Serialization
{
    public class StatusOfSkinsFiller
    {
        private readonly IGameSaverLoader _gameSaverLoader;
        private readonly IPlayerCustomizer _playerCustomizer;

        public StatusOfSkinsFiller(IGameSaverLoader gameSaverLoader, IPlayerCustomizer playerCustomizer)
        {
            _gameSaverLoader = gameSaverLoader;
            _playerCustomizer = playerCustomizer;

            FillStatusOfSkins();
        }

        private void FillStatusOfSkins()
        {
            var statusOfSkins = new Dictionary<int, bool>(_gameSaverLoader.SkinStatus);

            foreach (PlayerSkinInfo playerSkinInfo in _playerCustomizer.PlayerSkinInfoArray)
            {
                if (!statusOfSkins.ContainsKey(playerSkinInfo.Id))
                {
                    statusOfSkins.Add(playerSkinInfo.Id, false);
                }
            }
            
            _gameSaverLoader.SkinStatus = statusOfSkins;
        }
    }
}