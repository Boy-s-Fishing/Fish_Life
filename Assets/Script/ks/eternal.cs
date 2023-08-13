using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class eternal : MonoBehaviour
{

    public static save saveinfo;
    public static Dictionary<string, dataInfo> datainfo = new Dictionary<string, dataInfo>();

    private static void Awake() {
        var loaded = Resources.Load("Save") as TextAsset;
        saveinfo = JsonUtility.FromJson<save>(loaded.ToString());


        loaded = Resources.Load("Data") as TextAsset;
        data d = JsonUtility.FromJson<data>(loaded.ToString());
        foreach(dataInfo data in d.datas)
            datainfo.Add(data.id, data);

        print(saveinfo);
        
    }

    void setting (){
        var loaded = Resources.Load("Save") as TextAsset;
        saveinfo = JsonUtility.FromJson<save>(loaded.ToString());


        loaded = Resources.Load("Data") as TextAsset;
        data d = JsonUtility.FromJson<data>(loaded.ToString());
        foreach(dataInfo data in d.datas)
            datainfo.Add(data.id, data);
    }
    
    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        setting();
        DontDestroyOnLoad(this);
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}

//Json 저장 클래스
[System.Serializable]
public class save
{
    public string[] collection;
}


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