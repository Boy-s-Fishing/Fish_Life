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

    private void Update()
    {
        CommonInput();
    }

    private void CommonInput()
    {
        // 메뉴버튼
        if (device.TryGetFeatureValue(CommonUsages.menuButton, out bool primary))
        {
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

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        DontDestroyOnLoad(this);
        device = InputDevices.GetDeviceAtXRNode(XRNode.LeftHand);

        setting.SetActive(false);
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
