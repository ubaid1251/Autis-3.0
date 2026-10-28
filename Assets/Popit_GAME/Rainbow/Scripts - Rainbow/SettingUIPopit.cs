using UnityEngine;
using UnityEngine.UI;

namespace Rainbow
{
    public class SettingUIPopit : MonoBehaviour
    {
        public Toggle Sound;
        public Toggle Vibration;
        // Start is called before the first frame update
        void Start()
        {
            Sound.isOn = GlobalVars.Instance.Sound;
            Vibration.isOn = GlobalVars.Instance.Vibration;
        }
        public void ToggleSound(bool value)
        {
            GlobalVars.Instance.Sound = value;
        }

        public void ToggleVibration(bool value)
        {
            GlobalVars.Instance.Vibration = value;
        }
    }
}