using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Card : MonoBehaviour
{
    bool have = false;
    dataInfo data;
    GameObject canvas;

    private void Start() {
        GetComponent<Button>().onClick.AddListener(click);
        canvas = transform.parent.parent.parent.parent.parent.gameObject;
    }

    // Start is called before the first frame update
    public void set(string id, dataInfo d) {
        data = d;
        gameObject.name = id;
        foreach(string name in eternal.saveinfo.collection)
            if(data.name.Contains(name)){
                have = true;
                Texture2D image = (Texture2D)Resources.Load("image/"+data.ename);
                Rect rect = new Rect(0, 0, image.width, image.height);
                gameObject.GetComponent<Image>().sprite = Sprite.Create(image, rect, new Vector2(0.5f, 0.5f));
               
                break;
            }
    }
    
    public void click (){
        Sound.play(2);
        if (!have)
            return;

        string s = 
        "이름 : " + data.name + "\n\n" + 
        "종 : " + data.species + "\n\n" +
        "주식 : " + data.food + "\n\n" +
        " - " + data.explanation;
        canvas.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = s;

        for (int i = 0; i < canvas.transform.GetChild(2).childCount; i++)
            canvas.transform.GetChild(2).GetChild(i).gameObject.SetActive(false);
        
        canvas.transform.GetChild(2).Find(data.ename).transform.localPosition = new Vector3 (0,0,0);
        
        canvas.transform.GetChild(2).Find(data.ename).gameObject.SetActive(true);
        print(data.ename);
    }
}
