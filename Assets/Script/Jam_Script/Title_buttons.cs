using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Title_buttons : MonoBehaviour
{
    public void title_to_Game()
    {
        SceneManager.LoadScene("Game_BG");
    }

    public void app_Exit()
    {
        Application.Quit();
    }
}
