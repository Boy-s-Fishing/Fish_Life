using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class sceanController : MonoBehaviour
{
    public void title_to_Game(string scean)
    {
        Sound.play(2);
        SceneManager.LoadScene(scean);
    }

    public void app_Exit()
    {
        Sound.play(2);
        Application.Quit();
    }
}
