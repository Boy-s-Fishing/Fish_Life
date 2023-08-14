using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class Controller : MonoBehaviour
{
    public GameObject setting;

    InputDevice device;
    bool push = false;
    InputDeviceCharacteristics characteristics;
    

    private void Start() {
        setting.SetActive(false);
    }

private void OnEnable() {
    List<InputDevice> devices = new List<InputDevice>();
        InputDevices.GetDevicesWithCharacteristics(InputDeviceCharacteristics.Left, devices);
        if (devices.Count==1)
            device = devices[0];
}
    private void Update()
    {
        
        CommonInput();
    }

    void Checked(InputDevice d) {
        d.TryGetFeatureValue(CommonUsages.menuButton, out bool primary);
        if (primary)
            print("cl");
    }

    private void CommonInput()
    {
        // 메뉴버튼
        device.TryGetFeatureValue(CommonUsages.menuButton, out bool primary);
        if (primary)
        {
            print("cl");
            if (primary && !push)
            {
                push = true;
                // on/off
                if (setting.activeSelf)
                    setting.SetActive(false);
                else
                    setting.SetActive(true);
            }
            else if (!primary && push)
                push = false;
        }
    }

}
