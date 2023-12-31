using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UIElements;

public class Fstate : MonoBehaviour
{
    public bool con=false;
    public int level=1;

    private void OnCollisionEnter(Collision other) {
        print("coll" + other.gameObject.name);
        if(other.gameObject.CompareTag("Player")){
            int comlevel=other.gameObject.GetComponent<Pstate>().level;
            Debug.Log(comlevel);
            if(comlevel>=level){
                other.gameObject.GetComponent<Pstate>().exp+=level*10;
                
                Sound.play(1);
                transform.position = new Vector3 (0, -1235513124134123, 2);
                StartCoroutine(text(other.gameObject));
            }
        }else{
            con=true;
        }
    }
    private void OnCollisionExit(Collision other) {
        con=false;
    }

    IEnumerator text (GameObject player){
        string fish = eternal.datainfo[name].name;
        
        foreach(string c in eternal.saveinfo.collection)
            if (c.Equals(fish)){
                Destroy(transform.parent.gameObject);
                yield return null;
            }
        print(fish);
        TextMeshProUGUI text = player.transform.GetChild(0).GetChild(0).GetChild(0).GetComponentInChildren<TextMeshProUGUI>();
        string s = fish + "이(가) 도감에 추가되었습니다!";
        eternal.saveinfo.collection.Add(fish);
        text.text = s;
        
        Color32 color = text.color;
        for (byte a = 0; a < 200; a+= 20){
            color.a = a;
            text.color = color;
            yield return new WaitForEndOfFrame();
        }
        
        yield return new WaitForSeconds(2f);
        for (byte a = 150; a > 0; a-= 5){
            color.a = a;
            text.color = color;
            yield return new WaitForEndOfFrame();
        }
        color.a = 0;
        text.color = color;
        Destroy(transform.parent.gameObject);
    }

}
