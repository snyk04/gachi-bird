using UnityEngine;

namespace GachiBird.Device
{
    public class DeviceSetup
    {
        private static bool _isDeviceSetup = false;
        
        public DeviceSetup()
        {
            if (!_isDeviceSetup)
            {
                _isDeviceSetup = true;

                SetupDevice();
            }
        }

        private static void SetupDevice()
        {
        #if UNITY_ANDROID
            Application.targetFrameRate = Screen.currentResolution.refreshRate;
        #endif
        }
    }
}