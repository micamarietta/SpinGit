using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// This class is a scriptable object: https://docs.unity3d.com/Manual/class-ScriptableObject.html
[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/CustomSpinner", order = 1)]

public class CustomSpinner : ScriptableObject
{
    // BIG TODO:
    // This class needs a button overhaul to connect the methods to the UI; I'm neither expertized nor brave enough to try - Cole

    // The locations that PlayerPrefs are stored on iOS and Android: https://answers.unity.com/questions/131511/playerprefs-storage-location-on-android-or-ios.html
    private List<string> tmpActivities; // a temmporary List of the activities (strings) to allow the user to freely edit the spinner
    public string[] savedActivities; // all of the final activities found in the List are then transferred to this array which will be stored using PlayerPrefsX
    public string title; // titles are used as the "key" for the PlayerPrefsX so we know which one to access
    //NOTE: the following 2 TODO's are not planned to be finished in Sprint #2
    //Future TODO: add a variable to store an image that represents the spinner on the Main Menu 
    //Future TODO: add a vector to correctly display the image on the Main Menu

    // NOTE: I kept these three variables because I don't know exactly what they do nor how they work; I know Pablo used them with the AddToSpinner() method - Cole
    // Source of original code which Pablo modified: https://answers.unity.com/questions/1101002/adding-a-new-string-to-my-array-after-each-button.html
    public Button addActivity;
    public Canvas canvas;
    public InputField activity;

    /*
    NOTE: I'm not sure if this still needs to be included or if it will be modified with the button overhaul
    public void Start()
    {
        addActivity = addActivity.GetComponent<Button>();
        canvas = canvas.GetComponent<Canvas>();
        activity = activity.GetComponent<InputField>();
    }
    */

    public CustomSpinner() // Normal constructor to build new spinner objects
    {
        // TODO: declare the title like how its specified in the parantheses
        // title = (needs to be the user input passed in from the textbox && can't be the same as any existing titles found in the "storedTitles" array)
        savedActivities = new string[100]; // max size is 100
    }

    public CustomSpinner(string storedTitle) // Overloaded constructor used to load the pre-existing spinners stored in PlayerPrefsX
    {
        title = storedTitle;
        for (int i = 0; i < PlayerPrefsX.GetStringArray(storedTitle).Length; ++i)
        {
            tmpActivities[i] = PlayerPrefsX.GetStringArray(storedTitle)[i];
        }
        savedActivities = new string[100]; // Max size is 100
    }

    public string GetTitle()
    {
        return title;
    }

    public void AddToSpinner() // Adds a new activity to the tmp list
    {
        //TODO: double check that these buttons still work
        if (tmpActivities.Count <= 100) // checks to make sure the List is less than 100
        {
            tmpActivities.Add(activity.text);
        }
        //TODO: have an else-statement that will display a pop-up to the user that they have too many items

        Debug.Log("index: " + (tmpActivities.Count-1) + ", input: " + activity.text);
    }

    public void RemoveFromSpinner() // Removes an activity from the tmp List
    {
        //TODO: incorporate a button that indicates the index at which an activity needs to be removed
        //tmpActivities.RemoveAt("index")
    }

    public void SaveSpinner() // Saves the spinner into a PlayerPrefsX array
    {
        //TODO: incorporate a button to make this method functional
        for (int i = 0; i < tmpActivities.Count; ++i) // Transfers the activities in the temporary List to the array that will be stored
        {
            savedActivities[i] = tmpActivities[i];
        }

        PlayerPrefsX.SetStringArray(title, savedActivities);
        tmpActivities.Clear();
    }

    public void DeleteSpinner()
    {
        for (int i = 0; i < PlayerPrefsX.GetStringArray("storedSpinnerTitles").Length; ++i) // Cycles through the PlayerPrefsX that stores all of the titles
        {
            if (PlayerPrefsX.GetStringArray("storedSpinnerTitles")[i] == title) // Nullifies the title found in the PlayerPrefsX
            {
                PlayerPrefsX.GetStringArray("storedSpinnerTitles")[i] = null;
                break;
            }
        }

        PlayerPrefsX.SetStringArray(title, null); // Nullifies the array stored with the given title keyword
    }

    /*
    NOTE: This was a part of Pablo's original code and it was tied to AddToSpinner()
    NOTE: I'm not sure if it still needs to be included or if it will be modified with the button overhaul
    public void OnButtonClick()
    {
        AddToSpinner();
    }
    */
}