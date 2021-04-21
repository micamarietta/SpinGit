using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProfileManager : MonoBehaviour
{
    // Converts ProfileManager into a Singleton
    private static ProfileManager _instance;
    public static ProfileManager Instance { get { return _instance; } }

    [SerializeField]
    public Spinner curSpinner; // The current spinner that is being acted upon

    [SerializeField]
    public List<Spinner> activeSpinners; // The list of the active spinners in the app

    [SerializeField]
    public bool unsavedChanges; // Tracks if any unsaved changes have been made to any spinners

    [SerializeField]
    public bool spinnersDisplayed; // Tracks if the spinners are displayed on the main menu screen

    [SerializeField]
    public bool dataLoadedToEditScreen; // Tracks if the data has been loaded into the edit screen

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
                if (storedTitle != null)
                {
                    curSpinner = new Spinner(storedTitle); // Uses the Overloaded Constructor to load the data into spinner
                    activeSpinners.Add(curSpinner); // Adds this version of curSpinnerObject into the List
                    curSpinner.gridPositionIndex = activeSpinners.Count - 1;
                }
            }
        }
    }

    public void CreateSpinnerPM() // Creates a new spinner
    {
        curSpinner = new Spinner(); // Uses the Default Constructor
        curSpinner.tmpActivities.Add("");
        activeSpinners.Add(curSpinner); // Adds this version of curSpinner into the List
        curSpinner.gridPositionIndex = activeSpinners.Count - 1;
    }

    public void DeleteSpinnerPM() // Deletes an existing Spinner
    {
        curSpinner.DeleteSpinner(); // Nullifies the contents of the spinner from PlayerPrefsX

        activeSpinners.RemoveAt(curSpinner.gridPositionIndex); // Removes curSpinner from the List of active spinners

        unsavedChanges = true;
    }

    public void RemoveActivityPM(string tmpActivity)
    {
        curSpinner.RemoveActivity(tmpActivity);
    }
}
