using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;
using TMPro;
using System;

public class Fstate : MonoBehaviour
{
    public bool con=false;
    public int level=1;

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag=="Player"){
            int comlevel=other.gameObject.GetComponent<Pstate>().level;
            Debug.Log(comlevel);
            if(comlevel>=level){
                other.gameObject.GetComponent<Pstate>().exp+=level*10;
                
                Destroy(transform.parent.gameObject);
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
            if (c.Equals(fish))
                yield return null;
                
        print(fish);
        TextMeshProUGUI text = player.transform.GetChild(0).GetChild(0).GetChild(0).GetComponentInChildren<TextMeshProUGUI>();
        string s = fish + "이(가) 도감에 추가되었습니다!";
        eternal.saveinfo.collection.Add(fish);
        text.text = s;
        
        Color color = text.color;
        for (float a = 0; a < 150; a+= 1){
            color.a = a;
            text.color = color;
            print("+ " + a);
            yield return new WaitForSeconds(0.1f);
        }
        
        yield return new WaitForSeconds(2f);
        for (float a = 150; a > 0; a-= 0.3f){
            color.a = a;
            text.color = color;
            print("- " + a);
        }
    }

}
