using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIAddActivity : MonoBehaviour
{
    /*
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
            // GameObject activityField = Resources.Load("Prefabs/activityInput") as GameObject;
            ProfileManager.Instance.AddActivityPM(activityField.text);
        }
        else
        {
            // TODO: Disable button and grey it out
        }
    }
    */

    public GameObject firstActivityFieldPrefab;
    public Transform container;

    public void AddActivityFieldButton()
    {
        if (ProfileManager.Instance.curSpinner.tmpActivities.Count < 100)
        {
            GameObject clonedActivityFieldPrefab = Instantiate(firstActivityFieldPrefab) as GameObject;
            clonedActivityFieldPrefab.transform.SetParent(container.transform);
            clonedActivityFieldPrefab.transform.GetChild(0).GetComponent<InputField>().text = "";

            ProfileManager.Instance.curSpinner.tmpActivities.Add("");

            clonedActivityFieldPrefab.transform.GetChild(0).GetComponent<UpdateActivity>().index = ProfileManager.Instance.curSpinner.tmpActivities.Count - 1;
        }
    }

    void Update()
    {
        if (ProfileManager.Instance.curSpinner.tmpActivities.Count >= 100)
        {
            // TODO: Disable button and make it "greyed out"
        }
    }
}
