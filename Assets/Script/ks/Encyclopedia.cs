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
        var loaded = Resources.Load("Data") as TextAsset;
        data d = JsonUtility.FromJson<data>(loaded.ToString());
        foreach(dataInfo data in d.datas)
            info.Add(data.id, data);
        
        card();
    }

    void card() {
        foreach(KeyValuePair<string, dataInfo> k in info) {
            GameObject g = Instantiate(prefab, transform);
            g.AddComponent<Card>().set(k.Key, k.Value);
            
            Texture2D image = (Texture2D)Resources.Load("image/" + k.Value.ename);
            Rect rect = new Rect(0, 0, image.width, image.height);
            g.GetComponent<Image>().sprite = Sprite.Create(image, rect, new Vector2(0.5f, 0.5f));

        }
        print("fin");
    }
}









//Json 저장 클래스
class data
{
    public dataInfo[] datas;
}

[System.Serializable]
public class dataInfo
{
    public string id;
    public string name;
    public string ename;
    public string food;
    public string habitat;
    public string species;
    public string explanation;
}