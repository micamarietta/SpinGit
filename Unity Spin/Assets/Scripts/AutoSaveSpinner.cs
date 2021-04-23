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
    public Text titleDisplay;

    void Update()
    {
        curScene = SceneManager.GetActiveScene();

        if (curScene.name != "MainScreen") // Any screen thats not the main screen means that the spinners are not being displayed
        {
            ProfileManager.Instance.spinnersDisplayed = false;
        }

        if (curScene.name != "EditListScreen") // Any screen thats not the edit list screen means that the data has not been loaded
        {
            ProfileManager.Instance.dataLoadedToEditScreen = false;
        }

        if (curScene.name == "DefaultSpinnerScreen") // Sets the title name in the deault spinner screen
        {
            titleDisplay.text = ProfileManager.Instance.curSpinner.title;
        }

        if (curScene.name == "MainScreen" || curScene.name == "DefaultSpinnerScreen")
        {
            if (ProfileManager.Instance.unsavedChanges) // If there are unsaved changes, then we need to save the data to their respective PlayerPrefsX arrays
            {
                if (ProfileManager.Instance.activeSpinners.Count != 0) // Checks if there is at least one active spinner in the app
                {
                    ProfileManager.Instance.storedTitles = new string[ProfileManager.Instance.activeSpinners.Count]; // Sets the size of the storedTitles array that needs to be saved

                    for (int i = 0; i < ProfileManager.Instance.activeSpinners.Count; ++i)
                    {
                        ProfileManager.Instance.activeSpinners[i].gridPositionIndex = i; // Updates the index if a spinner is deleted or created

                        ProfileManager.Instance.activeSpinners[i].SaveSpinner(); // Stores the activities of the current spinner into a PlayerPrefsX array

                        ProfileManager.Instance.storedTitles[i] = ProfileManager.Instance.activeSpinners[i].title; // Grabs the titles of each of the active spinners and stores them in an array
                    }
                    PlayerPrefsX.SetStringArray("storedTitles", ProfileManager.Instance.storedTitles);
                }

                // TODO: Add a pop-up that will show to the user that the activeSpinners data has been saved (to PlayerPrefs)

                ProfileManager.Instance.unsavedChanges = false;
            }
        }
        else if (curScene.name == "CreateListScreen" || curScene.name == "EditListScreen")
        {
            ProfileManager.Instance.unsavedChanges = true;
            canvas = canvas.GetComponent<Canvas>();
            titleField = titleField.GetComponent<InputField>();

            if (curScene.name == "EditListScreen" && titleField.text != "")
            {
                ProfileManager.Instance.curSpinner.title = titleField.text; // Pass in the title to keep up to date with it
            }
            else if (curScene.name == "CreateListScreen")
            {
                ProfileManager.Instance.curSpinner.title = titleField.text; // Pass in the title to keep up to date with it
            }

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
