﻿using System.Collections;
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

    [SerializeField]
    public List<Spinner> activeSpinners; // The list of the active spinners in the app

    [SerializeField]
    public bool unsavedChanges; // Tracks if any unsaved changes have been made to any spinners

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

    public void CreateSpinnerPM() // Creates a new spinner
    {
        curSpinner = new Spinner(); // Uses the Default Constructor
        curSpinner.tmpActivities.Add("");
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

        // curSpinner.EditSpinner();

        return curSpinner;
    }

    public void SelectSpinnerPM(int selectedPosX, int selectedPosY)
    {
        // int tmpIndex = ((abs(selectedPosX - x0)) / C) + (2 * ((abs(selectedPosY - y0)) / C);
        // curSpinner = activeSpinners[tmpIndex];
    }

    public void RemoveActivityPM(int index)
    {
        curSpinner.RemoveActivity(index);
        // TODO: Debug
    }
}
