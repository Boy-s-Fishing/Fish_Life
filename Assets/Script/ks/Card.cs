using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Card : MonoBehaviour
{
    bool tf = false;
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
        foreach(string name in eternal.saveinfo.collection)
            if(data.name.Contains(name)){
                tf = true;
                fish = (GameObject) Resources.Load("fish/"+d.ename);
                Texture2D image = (Texture2D)Resources.Load("image/"+d.ename);
                Rect rect = new Rect(0, 0, image.width, image.height);
                gameObject.GetComponent<Image>().sprite = Sprite.Create(image, rect, new Vector2(0.5f, 0.5f));
               
                break;
            }
    }
    
    public void click (){
        if (!tf)
            return;

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
