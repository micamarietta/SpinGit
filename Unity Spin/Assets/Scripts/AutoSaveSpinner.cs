using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AutoSaveSpinner : MonoBehaviour
{
    public Scene curScene;
    public Canvas canvas;
    public InputField titleField;

    void Update()
    {
        // PlayerPrefs.DeleteAll(); // Remember to leave the splash screen for this to work

        Debug.Log("activeSpinners.Count = " + ProfileManager.Instance.activeSpinners.Count);

        curScene = SceneManager.GetActiveScene();
        if (curScene.name == "MainScreen") // || curScene.name == "DefaultSpinnerScreen")
        {
            if (ProfileManager.Instance.unsavedChanges) // If there are unsaved changes, then we need to save the data to their respective PlayerPrefsX arrays
            {
                if (ProfileManager.Instance.activeSpinners.Count != 0) // Checks if there is at least one active spinner in the app
                {
                    ProfileManager.Instance.storedTitles = new string[ProfileManager.Instance.activeSpinners.Count]; // Sets the size of the storedTitles array that needs to be saved

                    for (int i = 0; i < ProfileManager.Instance.activeSpinners.Count; ++i)
                    {
                        ProfileManager.Instance.activeSpinners[i].SaveSpinner(); // Stores the activities of the current spinner into a PlayerPrefsX array

                        ProfileManager.Instance.storedTitles[i] = ProfileManager.Instance.activeSpinners[i].title; // Grabs the titles of each of the active spinners and stores them in an array
                        Debug.Log("'" + ProfileManager.Instance.storedTitles[i] + "' stored at index " + i + " in storedTitles");
                    }
                    PlayerPrefsX.SetStringArray("storedTitles", ProfileManager.Instance.storedTitles);
                }
                else
                {
                    Debug.Log("activeSpinners is empty!!!");
                }

                // TODO: Add a pop-up that will show to the user that the activeSpinners data has been saved (to PlayerPrefs)

                ProfileManager.Instance.unsavedChanges = false;
            }
            else
            {
                Debug.Log("No unsaved changes");
            }
        }
        else if (curScene.name == "CreateListScreen")
        {
            ProfileManager.Instance.unsavedChanges = true;
            canvas = canvas.GetComponent<Canvas>();
            titleField = titleField.GetComponent<InputField>();

            ProfileManager.Instance.curSpinner.title = titleField.text; // Pass in the title to keep up to date with it

            // Compare curSpinner the spinner stored in activeSpinners
            // Automatically save any changes that are different once found
            foreach (Spinner oldSpinner in ProfileManager.Instance.activeSpinners) // Iterate through the spinners in activeSpinners
            {
                if (ProfileManager.Instance.curSpinner.gridPositionIndex == oldSpinner.gridPositionIndex) // Check if curSpinner's gridPositionIndex matches the gridPositionIndex of spinners in activeSpinners
                {
                    if (oldSpinner.title != ProfileManager.Instance.curSpinner.title) // Check if the user changed the title
                    {
                        // Update the title of the spinner in the activeSpinners list to that of curSpinner's
                        oldSpinner.title = ProfileManager.Instance.curSpinner.title;

                    }

                    if (oldSpinner.tmpActivities.Count < ProfileManager.Instance.curSpinner.tmpActivities.Count) // curSpinner is larger, which means that activities have been added
                    {
                        for (int i = 0; i < ProfileManager.Instance.curSpinner.tmpActivities.Count; ++i) // Iterate through the activities
                        {
                            if (i >= oldSpinner.tmpActivities.Count) // This is the case when we're adding activities since its out of the index
                            {
                                oldSpinner.tmpActivities.Add(ProfileManager.Instance.curSpinner.tmpActivities[i]);
                            }
                            else // Can directly transfer the activities since we're within both bounds
                            {
                                oldSpinner.tmpActivities[i] = ProfileManager.Instance.curSpinner.tmpActivities[i];
                            }
                        }
                    }
                    else if (oldSpinner.tmpActivities.Count > ProfileManager.Instance.curSpinner.tmpActivities.Count) // curSpinner is smaller, which means that activities have been removed
                    {
                        for (int i = 0; i < oldSpinner.tmpActivities.Count; ++i) // Iterate through the activities
                        {
                            if (i >= ProfileManager.Instance.curSpinner.tmpActivities.Count) // This is the case when we're removing activities since its out of the index
                            {
                                // We need to remove at the same index (which happens to be the value of the count of curSpinner) and not at an increasing index (i)
                                oldSpinner.tmpActivities.RemoveAt(ProfileManager.Instance.curSpinner.tmpActivities.Count);
                            }
                            else // Can directly transfer the activities since we're within both bounds
                            {
                                oldSpinner.tmpActivities[i] = ProfileManager.Instance.curSpinner.tmpActivities[i];
                            }
                        }
                    }
                    else // Can directly transfer the activities since the lists are the same length
                    {
                        for (int i = 0; i < oldSpinner.tmpActivities.Count; ++i)
                        {
                            oldSpinner.tmpActivities[i] = ProfileManager.Instance.curSpinner.tmpActivities[i];
                        }
                    }

                    break; // Since we found the spinner, no need to continue to iterate through the activeSpinners list
                }
            }
        }
    }
}
