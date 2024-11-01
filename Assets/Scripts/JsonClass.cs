using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;

public class JsonClass : MonoBehaviour
{
    public static JsonClass instance;
    public string UserName;
    public int Score;
    [SerializeField] private TextMeshProUGUI textstartMenu;
    public void SaveData(string _name, int _score)
    {
        DataGame dataGame = new DataGame();
        dataGame.Name = _name;
        dataGame.score = _score;
        string json = JsonUtility.ToJson(dataGame);

        using (StreamWriter writer = new StreamWriter(Application.dataPath + Path.AltDirectorySeparatorChar + "SaveData.json"))
        {
            writer.Write(json);
        }
    }

    public void LoadDataAndSet()
    {
        string json = string.Empty;

        using (StreamReader reader = new StreamReader(Application.dataPath + Path.AltDirectorySeparatorChar + "SaveData.json"))
        {
            json = reader.ReadToEnd();
        }

        DataGame data = JsonUtility.FromJson<DataGame>(json);
        UserName = data.Name;
        Score = data.score;
        DebugData(data);
    }

    public DataGame CheckSavedData()
    {
        string json = string.Empty;

        using (StreamReader reader = new StreamReader(Application.dataPath + Path.AltDirectorySeparatorChar + "SaveData.json"))
        {
            json = reader.ReadToEnd();
        }

        DataGame data = JsonUtility.FromJson<DataGame>(json);
        return data;
    }

    public void DebugData(DataGame data)
    {
        string name = data.Name;
        int score = data.score;


    }


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
        DontDestroyOnLoad(this.gameObject);

    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            SaveData(UserName, Score);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            LoadDataAndSet();
        }
    }


    [Serializable]
    public class DataGame
    {
        public int score;
        public string Name;
    }

}
