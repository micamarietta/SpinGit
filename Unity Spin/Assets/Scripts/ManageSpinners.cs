using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ManageSpinners : MonoBehaviour
{
    // BIG TODO #1: incorporate the functionality of SpinnerMechanics.cs into ManageSpinners.cs so that the demo displays curSpinner instead of Pablo's manually set List
    // BIG TODO #2: enable a way to accurately link the titleField.text to the curSpinner and then un-comment the button methods so they're actually functioning

    public Canvas canvas;
    public Button createButton;
    public Button deleteButton;
    public Button editButton;
    public Button saveButton;
    public Button addActivityButton;
    // public Button removeActivityButton;
    public InputField titleField;
    public InputField activityField;
    

    public List<CustomSpinner> allSpinners; // A dynamic list that stores all CustomSpinner objects
    public CustomSpinner curSpinner; // The current spinner that is either being created or editted
    public string[] storedSpinnerTitles;
    public Scene currentScene;

    void Start() // Loads the stored spinners on the start of the app
    {
        allSpinners = new List<CustomSpinner>();

        if (PlayerPrefsX.GetStringArray("storedSpinnerTitles").Length != 0) // Checks if the user's storedSpinnerTitles array is not empty
        {
            for (int i = 0; i < PlayerPrefsX.GetStringArray("storedSpinnerTitles").Length; ++i)
            {
                // First, it loads the title at i from PlayerPrefsX
                // Second, it loads a spinner with the given title to curSpinner using the overloaded constructor
                // Last, it adds curSpinner to the allSpinners List to keep track of the active spinners while the app is open
                allSpinners.Add(curSpinner = new CustomSpinner(PlayerPrefsX.GetStringArray("storedSpinnerTitles")[i]));

                Debug.Log("stored title: " + allSpinners[i].GetTitle());
            }
        }
    }

    /*
    void Update() // Update to check if the current scene is in the create list scene to be able to grab the most current title and save it
    {
        currentScene = SceneManager.GetActiveScene();

        if (currentScene.name == "CreateListScreen")
        {
            titleField = titleField.GetComponent<InputField>();
            curSpinner.SetTitle(titleField.text);
        }
    }
    */

    public void CreateSpinnerButton() // Creates a new CustomSpinner object
    {
        canvas = canvas.GetComponent<Canvas>();
        createButton = createButton.GetComponent<Button>();

        curSpinner = new CustomSpinner();
        Debug.Log("created new spinner");
        // Debug.Log("added the title: " + curSpinner.GetTitle());
        // PlayerPrefs.Save(); // Saves the active spinners to PlayerPrefs in case of a crash
    }

    public void DeleteSpinnerButton() // Deletes an existing CustomSpinner object
    {
        canvas = canvas.GetComponent<Canvas>();
        deleteButton = deleteButton.GetComponent<Button>();

        // TODO: add a way to specify which title is being deleted to update curSpinner
        /*
        for (int i = 0; i < allSpinners.Count; ++i)
        {
            if (allSpinners[i].GetTitle() == HIGLIGHTED_TITLE_TEXT)
            {
                curSpinner = allSpinners[i];
                Debug.Log("current spinner title: " + curSpinner.GetTitle());
            }
        }
        */

        // curSpinner.DeleteSpinner(); // Nullifies the contents of the spinner from PlayerPrefsX
        // Debug.Log("deleted the spinner");
        // allSpinners.Remove(curSpinner); // Removes curSpinner from the List of active spinners
        // Debug.Log("removed the spinner from the active list");
        // PlayerPrefs.Save(); // Saves the active spinners to PlayerPrefs in case of a crash
    }

    public void EditSpinnerButton() // Edits an existing CustomSpinner object
    {
        canvas = canvas.GetComponent<Canvas>();
        editButton = editButton.GetComponent<Button>();
        // titleField = titleField.GetComponent<InputField>();

        // TODO: add a method to set the title in the title text box
        // > public void SetCurrentTitle() { curSpinner.SetTitle() = titleField.text >> search through index to load it }
        // curSpinner.EditSpinner();
    }

    public void SaveSpinnerButton()
    {
        canvas = canvas.GetComponent<Canvas>();
        saveButton = saveButton.GetComponent<Button>();

        // curSpinner.SaveSpinner();
        // Debug.Log("saved the spinner");
        // PlayerPrefs.Save(); // Saves the active spinners to PlayerPrefs in case of a crash
    }

    public void AddToSpinnerButton()
    {
        canvas = canvas.GetComponent<Canvas>();
        addActivityButton = addActivityButton.GetComponent<Button>();
        activityField = activityField.GetComponent<InputField>();


        // Note: just for the demo...
        curSpinner = new CustomSpinner();

        curSpinner.AddToSpinner(activityField.text);
        Debug.Log("added to the spinner");
    }

    public void RemoveFromSpinnerButton()
    {
        // TODO: incorporate a button to make this method functional
        canvas = canvas.GetComponent<Canvas>();
        // removeActivityButton = removeActivityButton.GetComponent<Button>();
        // activityField = activityField.GetComponent<InputField>();

        // curSpinner.RemoveFromSpinner();
        // Debug.Log("removed from the spinner");
    }

    void OnApplicationQuit() // Saves the titles of the active spinners
    {
        if (allSpinners.Count != 0) // Checks if there is at least one active spinner in the app
        {
            Debug.Log("active spinners size: " + allSpinners.Count);
            storedSpinnerTitles = new string[allSpinners.Count];

            for (int i = 0; i < allSpinners.Count; ++i)
            {
                storedSpinnerTitles[i] = allSpinners[i].GetTitle(); // Grabs the titles of each of the active spinners and stores them in an array
                Debug.Log("title stored at index " + i + ": " + storedSpinnerTitles[i]);
            }
            PlayerPrefsX.SetStringArray("storedSpinnerTitles", storedSpinnerTitles);
        }

        allSpinners.Clear(); // Since all of the active spinners are now saved in PlayerPrefsX, we can clear the list
        Debug.Log("cleared allSpinners list");
    }
}
