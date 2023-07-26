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
#if UNITY_EDITOR

#else
        SaveData data = new SaveData();
        data.highName = highName;
        data.highScore = highScore;
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
#endif

    }

    public void LoadScore()
    {
#if UNITY_EDITOR

#else
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            highName = data.highName;
            highscore = data.highScore;
        }
#endif

    }

}
