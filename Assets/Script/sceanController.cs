using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class sceanController : MonoBehaviour
{
    public void title_to_Game(string scean)
    {
        SceneManager.LoadScene(scean);
    }

    public void app_Exit()
    {
        Application.Quit();
    }
}
