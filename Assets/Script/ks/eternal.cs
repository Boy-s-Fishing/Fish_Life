using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.SceneManagement;

public class eternal : MonoBehaviour
{

    public static save saveinfo;
    public static Dictionary<string, dataInfo> datainfo = new Dictionary<string, dataInfo>();

    private void Start() {
        setting();
    }

    void setting (){
        var loaded = Resources.Load("Data") as TextAsset;
        data d = JsonUtility.FromJson<data>(loaded.ToString());
        foreach(dataInfo data in d.datas)
            datainfo.Add(data.ename, data);
        
        string path = Path.Combine(Application.dataPath, "Save.json");
        try{
            string json = File.ReadAllText(path);
            saveinfo = JsonUtility.FromJson<save>(json);

        }catch{
            loaded = Resources.Load("Save") as TextAsset;
            saveinfo = JsonUtility.FromJson<save>(loaded.ToString());
            File.WriteAllText(path, saveinfo.ToString());
            }
    }

    public static void setSave () {
        string path = Path.Combine(Application.dataPath, "Save.json");
        File.WriteAllText(path, saveinfo.ToString());
    }

    
    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
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
    public List<string> collection;
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
    public string species;
    public string explanation;
}