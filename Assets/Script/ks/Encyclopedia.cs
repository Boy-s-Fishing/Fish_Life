using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Encyclopedia : MonoBehaviour
{
    string name;
    Dictionary<string, dataInfo> info;
    
    private void Start() {
        name = gameObject.name;
        var loaded = Resources.Load("Data") as TextAsset;
        data d = JsonUtility.FromJson<data>(loaded.ToString());
        foreach(dataInfo data in d.datas)
            info.Add(data.name, data);
    }

    void card() {
        
    }



}









//Json 저장 클래스
class data
{
    public dataInfo[] datas;
}

[System.Serializable]
class dataInfo
{
    public int id;
    public string name;
    public string food;
    public string explanation;
}