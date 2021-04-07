using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{

    //test

    public void LoadSplashScreen()
    {
        SceneManager.LoadScene(0);
        Debug.Log("Heading to the splash scene");
    }

    public void LoadMainScreen()
    {
        SceneManager.LoadScene(1);
        Debug.Log("Heading to the main scene");
    }

    public void LoadDefaultSpinnerScript()
    {
        SceneManager.LoadScene(2);
        Debug.Log("Heading to the default spinner");
    }

    public void LoadCreateListScreen()
    {
        SceneManager.LoadScene(3);
        Debug.Log("Heading to the create list scene");
    }

}
