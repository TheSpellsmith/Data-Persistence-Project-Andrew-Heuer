using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class highScoreManager : MonoBehaviour
{
    public static highScoreManager Instance;

    public int highScore;
    public string highName;


    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

    }

    [SerializeField]

    class SaveData
    {
        public int highScore;
        public string highName;
    }
    public void SaveScore()
    {

        SaveData data = new SaveData();
        data.highName = highName;
        data.highScore = highScore;
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);


    }

    public void LoadScore()
    {

        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            highName = data.highName;
            highScore = data.highScore;

        }

    }
}