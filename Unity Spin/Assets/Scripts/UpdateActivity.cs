using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UpdateActivity : MonoBehaviour
{
    public InputField curField;
    public int index = 0;
    public Scene curScene;

    void Update()
    {
        curScene = SceneManager.GetActiveScene();
        
        if (curScene.name == "CreateListScreen" || curScene.name == "EditListScreen")
        {
            ProfileManager.Instance.curSpinner.tmpActivities[index] = curField.text; // Pulls the most current version of the text for the given activityField
        }
    }
}
