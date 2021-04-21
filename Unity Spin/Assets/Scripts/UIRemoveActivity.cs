using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIRemoveActivity : MonoBehaviour
{
    public Button removeButton;
    public GameObject activityPrefab;

    public void RemoveActivityButton()
    {
        string tmpActivity = activityPrefab.transform.GetComponentInChildren<Text>().text;

        ProfileManager.Instance.RemoveActivityPM(tmpActivity);
    }
}
