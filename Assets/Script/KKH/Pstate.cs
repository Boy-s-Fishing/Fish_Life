using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pstate : MonoBehaviour
{
    public GameObject gameoverPanel;    // Start is called before the first frame update
    public int level=1;
    public int exp=0;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        levelUp();
    }
   void levelUp(){
    if(exp>=100){
        level++;
        exp-=100;
    }
   }

    

    public void Dead(){
        Debug.Log("1");
        Time.timeScale=0;
        gameoverPanel.SetActive(true);
    }
}
