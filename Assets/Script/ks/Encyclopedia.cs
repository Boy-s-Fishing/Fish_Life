using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Encyclopedia : MonoBehaviour
{
    string name;
    public GameObject prefab;
    Dictionary<string, dataInfo> info = new Dictionary<string, dataInfo>();
    
    private void Start() {
        name = gameObject.name;
        card();
    }

    void card() {
        foreach(KeyValuePair<string, dataInfo> k in eternal.datainfo) {
            GameObject g = Instantiate(prefab, transform);
            
            Texture2D image = (Texture2D)Resources.Load("image/not");
            Rect rect = new Rect(0, 0, image.width, image.height);
            g.GetComponent<Image>().sprite = Sprite.Create(image, rect, new Vector2(0.5f, 0.5f));
            g.AddComponent<Card>().set(k.Key, k.Value);
        }
        print("fin");
    }
}
