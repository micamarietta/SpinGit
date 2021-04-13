using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadSplashScreen()
    {
        SceneManager.LoadScene(0);
    }

    public void LoadMainScreen()
    {
        SceneManager.LoadScene(1);
    }

    public void LoadDefaultSpinnerScript()
    {
        SceneManager.LoadScene(2);
    }

    public void LoadCreateListScreen()
    {
        SceneManager.LoadScene(3);
    }

    public void LoadEditListScreen()
    {
        SceneManager.LoadScene(4);
    }

}
