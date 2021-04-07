using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AutoSaveSpinner : MonoBehaviour
{
    public Scene curScene;
    public Canvas canvas;
    public InputField titleField;
    public bool unsavedChanges; // May need to serialize??

    void Update()
    {
        curScene = SceneManager.GetActiveScene();
        if (curScene.name == "MainScreen")
        {
            ProfileManager.Instance.SaveChangesPM(unsavedChanges);
            unsavedChanges = false;
        }
        else if (curScene.name == "CreateListScreen")
        {
            unsavedChanges = true;
            canvas = canvas.GetComponent<Canvas>();
            // titleField = titleField.GetComponent<InputField>();

            // ProfileManager.Instance.AutoChangePM(titleField.text);
            ProfileManager.Instance.AutoChangePM("TestDemo");
        }
    }
}
