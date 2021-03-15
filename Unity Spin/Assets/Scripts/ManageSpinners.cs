using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageSpinners : MonoBehaviour
{
    // BIG TODO:
    // Incorporate the functionality from SpinnerMechanics.cs into either CustomSpinner.cs or ManageSpinners.cs (whichever
    // makes the most sense) so that Unity displays curSpinner instead of Pablo's manually set List

    public List<CustomSpinner> allSpinners; // a dynamic list that stores all CustomSpinner objects
    public CustomSpinner curSpinner; // the current spinner that is either being created or editted
    public string[] storedSpinnerTitles;

    void Start() // Loads the stored spinners on the start of the app
    {
        if (PlayerPrefsX.GetStringArray("storedSpinnerTitles").Length != 0) // Checks if the user's storedSpinnerTitles array is not empty
        {
            for (int i = 0; i < PlayerPrefsX.GetStringArray("storedSpinnerTitles").Length; ++i)
            {
                // First, it loads the title at i from PlayerPrefsX
                // Second, it loads a spinner with the given title to curSpinner using the overloaded constructor
                // Last, it adds curSpinner to the allSpinners List to keep track of the active spinners while the app is open
                allSpinners.Add(curSpinner = new CustomSpinner(PlayerPrefsX.GetStringArray("storedSpinnerTitles")[i]));
            }
        }
    }

    public void CreateSpinner() // Creates a new CustomSpinner object
    {
        //TODO: incorporate a button to make this method functional
        curSpinner = new CustomSpinner();
        PlayerPrefs.Save(); // Saves the active spinners to PlayerPrefs in case of a crash
    }

    //NOTE: EditSpinner() is not planned to be finished in Sprint #2
    public void EditSpinner() // Edit an existing CustomSpinner object
    {
        // TODO: incorporate a button that makes whatever spinner is selected in the app to be the curSpinner
        PlayerPrefs.Save(); // Saves the active spinners to PlayerPrefs in case of a crash
    }

    public void DeleteSpinner() // Delete
    {
        // TODO: incorporate a button that makes whatever spinner is selected in the app to be the curSpinner
        curSpinner.DeleteSpinner(); // Nullifies the contents of the spinner from PlayerPrefsX
        allSpinners.Remove(curSpinner); // Removes curSpinner from the List of active spinners
        PlayerPrefs.Save(); // Saves the active spinners to PlayerPrefs in case of a crash
    }

    void OnApplicationQuit() // Saves the titles of the active spinners
    {
        if (allSpinners.Count != 0) // Checks if there is at least one active spinner in the app
        {
            storedSpinnerTitles = new string[allSpinners.Count];

            for (int i = 0; i < allSpinners.Count; ++i)
            {
                storedSpinnerTitles[i] = allSpinners[i].GetTitle(); // Grabs the titles of each of the active spinners and stores them in an array
            }
            PlayerPrefsX.SetStringArray("storedSpinnerTitles", storedSpinnerTitles);
        }

        allSpinners.Clear(); // Since all of the active spinners are now saved in PlayerPrefsX, we can clear the list
    }
}