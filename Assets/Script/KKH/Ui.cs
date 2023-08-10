using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ui : MonoBehaviour
{
    public GameObject gameoverPanel;
    void Start()
    {
       gameoverPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Restart(){
        Time.timeScale=1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }
}
