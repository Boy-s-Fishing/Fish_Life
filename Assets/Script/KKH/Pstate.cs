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
        StatusSave.Instance.LoadGameData();
        level=StatusSave.Instance.data.level;
        exp=StatusSave.Instance.data.exp;
        StartCoroutine(status());
    }

   void levelUp(){
        if(exp>=100){
            level++;
            exp-=100;
            StatusSave.Instance.data.level=this.level;
        }

    }

    private void OnApplicationQuit() {
        StatusSave.Instance.SaveGameData();
    }

    public void Dead(){
        Time.timeScale=0;
        gameoverPanel.SetActive(true);
    }


    public IEnumerator status(){
        while(true){
            levelUp();
            StatusSave.Instance.data.exp=this.exp;
            yield return new WaitForEndOfFrame();
        }
    }
}
