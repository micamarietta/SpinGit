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

        // curField = curField.GetComponent<InputField>();
        
        if (curScene.name == "CreateListScreen")
        {
            ProfileManager.Instance.curSpinner.tmpActivities[index] = curField.text;
            Debug.Log("tmpActivities[" + index + "] = " + ProfileManager.Instance.curSpinner.tmpActivities[index]);
        }
    }
}
