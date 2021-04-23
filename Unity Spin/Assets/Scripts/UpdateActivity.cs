using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UpdateActivity : MonoBehaviour
{
    public InputField curField;

    [SerializeField]
    public int index;

    [SerializeField]
    public int updateIndex;
    public Scene curScene;

    void Update()
    {
        curScene = SceneManager.GetActiveScene();

        // Checks if an activity has been removed and if the current activityPrefab has an index higher than the index that was removed (thus a decrement is needed to be made)
        if (index > updateIndex && ProfileManager.Instance.removedActivity)
        {
            index--;

            // Checks if this is the last index in the list, so that the decrement process can be completed
            if (index == (ProfileManager.Instance.curSpinner.tmpActivities.Count - 1))
            {
                ProfileManager.Instance.removedActivity = false;
            }
        }

        if (curScene.name == "CreateListScreen" || curScene.name == "EditListScreen")
        {
            ProfileManager.Instance.curSpinner.tmpActivities[index] = curField.text; // Pulls the most current version of the text for the given activityField
        }
    }
}
