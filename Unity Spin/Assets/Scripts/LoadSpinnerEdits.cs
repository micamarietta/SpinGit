using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadSpinnerEdits : MonoBehaviour
{
    public Transform container; // The container that the prefabs are stored within the hierarchy
    public InputField titleField;
    public Scene curScene;

    void Update()
    {
        curScene = SceneManager.GetActiveScene();

        if (curScene.name == "EditListScreen" && !ProfileManager.Instance.dataLoadedToEditScreen)
        {
            titleField.text = ProfileManager.Instance.curSpinner.title; // Loads the title into the title field

            for (int i = 0; i < ProfileManager.Instance.curSpinner.tmpActivities.Count; ++i) // Cycle through the activities to load them into the prefab
            {
                GameObject curActivityPrefab = Instantiate(Resources.Load("Prefabs/activityPrefab")) as GameObject; // Instantiates the activityField prefab
                curActivityPrefab.transform.SetParent(container.transform); // Places this new prefab within the contain heirarchy

                // Fills curActivityPrefab with the text from the activities in curSpinner
                curActivityPrefab.transform.GetChild(0).GetComponent<InputField>().text = ProfileManager.Instance.curSpinner.tmpActivities[i];
            }

            ProfileManager.Instance.dataLoadedToEditScreen = true; // The data has now been loaded
        }
    }
}
