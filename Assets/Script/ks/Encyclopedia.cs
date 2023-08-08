using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    public string food;
    public string explanation;
}