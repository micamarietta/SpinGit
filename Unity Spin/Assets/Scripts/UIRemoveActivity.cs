using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIRemoveActivity : MonoBehaviour
{
    public Button removeButton;
    public GameObject activityPrefab;

    [SerializeField]
    public int remIndex;

    public void RemoveActivityButton()
    {
        string remActivity = activityPrefab.transform.GetComponentInChildren<InputField>().text;

        // FindIndex doesn't allow strings; it only allows "predicates". So this is a way to convert the string into a "predicate"
        remIndex = ProfileManager.Instance.curSpinner.tmpActivities.FindIndex(searchString => searchString == activityPrefab.transform.GetComponentInChildren<InputField>().text);
        activityPrefab.transform.GetComponentInChildren<UpdateActivity>().updateIndex = remIndex;

        ProfileManager.Instance.RemoveActivityPM(remActivity);

        ProfileManager.Instance.removedActivity = true;

        Destroy(activityPrefab);
    }
}
