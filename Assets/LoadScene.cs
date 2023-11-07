using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
  public void OnBackButton()
    {
        SceneManager.LoadScene(0);

    }
    public void OnExitButton()
    {
        Application.Quit();

    }
}
