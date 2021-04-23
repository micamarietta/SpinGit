using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIAddActivity : MonoBehaviour
{
    public Transform container; // The container that the prefabs are stored within the hierarchy
    public Button addButton;

    public void AddActivityFieldButton()
    {
        if (ProfileManager.Instance.curSpinner.tmpActivities.Count < 100) // Checks to make sure another activity can be added
        {
            GameObject clonedActivityPrefab = Instantiate(Resources.Load("Prefabs/activityPrefab")) as GameObject; // Creates a clone of the prefab

            clonedActivityPrefab.transform.SetParent(container.transform); // Places this new prefab within the contain heirarchy
            clonedActivityPrefab.transform.GetChild(0).GetComponent<InputField>().text = ""; // Empties the text so its not copied over to the clone

            ProfileManager.Instance.curSpinner.tmpActivities.Add("");

            clonedActivityPrefab.transform.GetChild(0).GetComponent<UpdateActivity>().index = ProfileManager.Instance.curSpinner.tmpActivities.Count - 1; // Sets the index
        }
    }

    void Update()
    {
        if (ProfileManager.Instance.curSpinner.tmpActivities.Count >= 100) // Checks if the button needs to be disabled due to curSpinner's activity size
        {
            addButton.GetComponent<Button>().interactable = false;
        }
        else
        {
            addButton.GetComponent<Button>().interactable = true;
        }
    }
}