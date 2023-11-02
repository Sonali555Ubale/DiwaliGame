using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FireCrackerSelector : MonoBehaviour
{
    public void SetFireCracker(int type= 0)
    {
        PlayerPrefs.SetInt("FireCrackerType", type);
        Debug.Log(PlayerPrefs.GetInt("FireCrackerType"));
        nextScene();
    }

    public void nextScene()
    {
        SceneManager.LoadScene(1);
    }
}
