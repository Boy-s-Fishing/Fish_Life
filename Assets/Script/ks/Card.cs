using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Card : MonoBehaviour
{
    dataInfo data;
    GameObject fish;
    GameObject canvas;

    private void Start() {
        GetComponent<Button>().onClick.AddListener(click);
        canvas = transform.parent.parent.parent.parent.parent.gameObject;
    }

    // Start is called before the first frame update
    public void set(string id, dataInfo d) {
        data = d;
        gameObject.name = id;
        try {
        fish = (GameObject) Resources.Load("fish/"+d.ename);
        } catch {}
    }
    
    public void click (){
        //물고기 프리팹 등장해야됨

        string s = 
        "이름 : " + data.name + "\n\n" + 
        "종 : " + data.species + "\n\n" +
        "주식 : " + data.food + "\n\n" +
        "서식지 : " + data.habitat + "\n\n" +
        " - " + data.explanation;
        canvas.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = s;

        for (int i = 0; i < canvas.transform.GetChild(2).childCount; i++)
            canvas.transform.GetChild(2).GetChild(i).gameObject.SetActive(false);
        canvas.transform.GetChild(2).GetChild(int.Parse(data.id)).gameObject.SetActive(true);
    }
}
