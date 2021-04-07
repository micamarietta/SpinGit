using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIAddActivity : MonoBehaviour
{
    public Canvas canvas;
    public Button addActivityButton;
    public InputField activityField;

    public void AddActivityButton()
    {
        canvas = canvas.GetComponent<Canvas>();
        addActivityButton = addActivityButton.GetComponent<Button>();
        activityField = activityField.GetComponent<InputField>();

        // [Sprint 4] TODO 2:

        if (ProfileManager.Instance.curSpinner.tmpActivities.Count <= 100) // checks to make sure the List is less than 100
        {
            ProfileManager.Instance.AddActivityPM(activityField.text);
        }
        else
        {
            // TODO: Add a pop-up that tells the user that they have too many items
        }
    }
}
