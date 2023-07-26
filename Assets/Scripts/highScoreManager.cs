using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

   // [SerializeField]

}
