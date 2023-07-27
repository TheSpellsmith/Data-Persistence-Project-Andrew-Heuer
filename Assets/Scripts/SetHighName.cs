using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SetHighName : MonoBehaviour
{
    public void SetName(string name)
    {
        name = name.ToUpper();
        if (name.Length >= 3)
        {
            name = name.Substring(0, 3);
        }
        highScoreManager.Instance.highName = name;
        highScoreManager.Instance.SaveScore();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(0);
        }
    }
}
