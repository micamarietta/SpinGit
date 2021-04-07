using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProfileManager : MonoBehaviour
{
    // [SPRINT 4] TODO 1: (UI): Get the position of the spinner icons for UISelectSpinner.cs
    // [Sprint 4] TODO 2: (Pablo): Connect UIAddActivity.cs to the button on the panel
    // [Sprint 4] TODO 3: (Pablo): Connect UIEditActivity.cs to the button on the panel
    // [Sprint 4] TODO 4: (Pablo): Connect UIRemoveActivity.cs to the button on the panel
    // [Sprint 4] TODO 5: Connect UIDeleteSpinner.cs to the button (needs button/image position)
    // [Sprint 4] TODO 6: Connect UIEditSpinner.cs to the button (needs button/image position)
    // [Sprint 4] TODO 7: Convert the spinner icon buttons to images (much like in Pablo's script)

    // Converts ProfileManager into a Singleton
    private static ProfileManager _instance;
    public static ProfileManager Instance { get { return _instance; } }

    [SerializeField]
    public Spinner curSpinner; // The current spinner that is being acted upon
    // TODO: Actually serialize the activeSpinners list
    // https://answers.unity.com/questions/460727/how-to-serialize-dictionary-with-unity-serializati.html
    [SerializeField]
    public List<Spinner> activeSpinners; // The list of the active spinners in the app
    public string[] storedTitles; // The titles of the spinners that will be saved upon closing of the app

    private void Awake() // Allows only a single instance of this class
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    void Start() // Loads the stored spinners on the start of the app
    {
        activeSpinners = new List<Spinner>();

        if (PlayerPrefsX.GetStringArray("storedTitles").Length != 0) // Checks if the user's storedSpinnerTitles array is not empty
        {
            foreach (string storedTitle in PlayerPrefsX.GetStringArray("storedTitles")) // Cycles through the PlayerPrefsX array that stores all of the titles
            {
                Debug.Log("now loading: " + storedTitle);

                if (storedTitle != null)
                {
                    curSpinner = new Spinner(storedTitle); // Uses the Overloaded Constructor to load the data into spinner
                    activeSpinners.Add(curSpinner); // Adds this version of curSpinnerObject into the List
                    curSpinner.gridPositionIndex = activeSpinners.Count - 1;
                }

                Debug.Log("'" + curSpinner.title + "' loaded properly");
            }
        }
    }

    public void SaveChangesPM(bool unsavedChanges)
    {
        if (unsavedChanges) // If there are unsaved changes, then we need to save the data to their respective PlayerPrefsX arrays
        {
            // TODO: Make sure that Update() is not saving duplicates of spinners in PlayerPrefs

            if (activeSpinners.Count != 0) // Checks if there is at least one active spinner in the app
            {
                Debug.Log("activeSpinners size: " + activeSpinners.Count);
                storedTitles = new string[activeSpinners.Count];

                for (int i = 0; i < activeSpinners.Count; ++i)
                {
                    activeSpinners[i].SaveSpinner(); // Stores the activities of the current spinner into a PlayerPrefsX array

                    storedTitles[i] = activeSpinners[i].title; // Grabs the titles of each of the active spinners and stores them in an array
                    Debug.Log("title stored at index " + i + ": " + storedTitles[i]);
                }
                PlayerPrefsX.SetStringArray("storedTitles", storedTitles);
            }
            else
            {
                Debug.Log("activeSpinners is empty!!!");
            }

            // UI TODO 1: Add a pop-up that will show to the user that the activeSpinners data has been saved (to PlayerPrefs)

            unsavedChanges = false;
        }
    }

    public void AutoChangePM(string curTitle)
    {
        curSpinner.title = curTitle; // Pass in the title to keep up to date with it

        // Compare curSpinner the spinner stored in activeSpinners
        // Automatically save any changes that are different once found
        foreach (Spinner oldSpinner in activeSpinners) // Iterate through the spinners in activeSpinners
        {
            if (curSpinner.gridPositionIndex == oldSpinner.gridPositionIndex) // Check if curSpinner's gridPositionIndex matches the gridPositionIndex of spinners in activeSpinners
            {
                if (oldSpinner.title != curSpinner.title) // Check if the user changed the title
                {
                    // Update the title of the spinner in the activeSpinners list to that of curSpinner's
                    oldSpinner.title = curSpinner.title;
                }

                if (oldSpinner.tmpActivities.Count < curSpinner.tmpActivities.Count) // curSpinner is larger, which means that activities have been added
                {
                    for (int i = 0; i < curSpinner.tmpActivities.Count; ++i) // Iterate through the activities
                    {
                        if (i >= oldSpinner.tmpActivities.Count) // This is the case when we're adding activities since its out of the index
                        {
                            oldSpinner.tmpActivities.Add(curSpinner.tmpActivities[i]);
                        }
                        else // Can directly transfer the activities since we're within both bounds
                        {
                            oldSpinner.tmpActivities[i] = curSpinner.tmpActivities[i];
                        }
                    }
                }
                else if (oldSpinner.tmpActivities.Count > curSpinner.tmpActivities.Count) // curSpinner is smaller, which means that activities have been removed
                {
                    for (int i = 0; i < oldSpinner.tmpActivities.Count; ++i) // Iterate through the activities
                    {
                        if (i >= curSpinner.tmpActivities.Count) // This is the case when we're removing activities since its out of the index
                        {
                            // We need to remove at the same index (which happens to be the value of the count of curSpinner) and not at an increasing index (i)
                            oldSpinner.tmpActivities.RemoveAt(curSpinner.tmpActivities.Count);
                        }
                        else // Can directly transfer the activities since we're within both bounds
                        {
                            oldSpinner.tmpActivities[i] = curSpinner.tmpActivities[i];
                        }
                    }
                }
                else // Can directly transfer the activities since the lists are the same length
                {
                    for (int i = 0; i < oldSpinner.tmpActivities.Count; ++i)
                    {
                        oldSpinner.tmpActivities[i] = curSpinner.tmpActivities[i];
                    }
                }

                break; // Since we found the spinner, no need to continue to iterate through the activeSpinners list
            }
        }
    }

    public void CreateSpinnerPM() // Creates a new spinner
    {
        curSpinner = new Spinner(); // Uses the Default Constructor
        activeSpinners.Add(curSpinner); // Adds this version of curSpinner into the List
        curSpinner.gridPositionIndex = activeSpinners.Count - 1;

        // [Sprint 4] TODO 7:
        // C = the distance between button
        // x0 = the x-pos at index 0
        // y0 = the y-pos at index 0
        // curSpinner.posX = x0 + ((i % 2) * C);
        // curSpinner.posY = y0 - ((i / 2) * C);
    }

    public void DeleteSpinnerPM() // Deletes an existing Spinner
    {
        // SelectSpinnerPM() is also called on the button click to determine what the curSpinner is

        // curSpinner.DeleteSpinner(); // Nullifies the contents of the spinner from PlayerPrefsX
        // Debug.Log("nullified the spinner");

        // activeSpinners.Remove(curSpinner.title); // Removes curSpinner from the List of active spinners
        // Debug.Log("removed the spinner from the active list");
    }

    public Spinner EditSpinnerPM() // Edits an existing Spinner
    {
        // SelectSpinnerPM() is also called on the button click to determine what the curSpinner is

        return curSpinner;
    }

    public void SelectSpinnerPM(int selectedPosX, int selectedPosY)
    {
        // int tmpIndex = ((abs(selectedPosX - x0)) / C) + (2 * ((abs(selectedPosY - y0)) / C);

        // curSpinner = activeSpinners[tmpIndex];
    }

    public void AddActivityPM(string activity)
    {
        curSpinner.AddActivity(activity);

        for (int i = 0; i < curSpinner.tmpActivities.Count; ++i)
        {
            Debug.Log("index: " + i + ", activity: " + curSpinner.tmpActivities[i]);
        }
    }

    public void RemoveActivityPM(int index)
    {
        curSpinner.RemoveActivity(index);
        // TODO: Debug
    }

    public void EditActivityPM(int index, string activity)
    {
        curSpinner.EditActivity(index, activity);
        // TODO: Debug
    }
}
