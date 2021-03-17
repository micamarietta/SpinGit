using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomSpinner
{
    // The locations that PlayerPrefs are stored on iOS and Android: https://answers.unity.com/questions/131511/playerprefs-storage-location-on-android-or-ios.html
    private List<string> tmpActivities; // a temmporary List of the activities (strings) to allow the user to freely edit the spinner
    public string[] savedActivities; // all of the final activities found in the List are then transferred to this array which will be stored using PlayerPrefsX
    public string title; // titles are used as the "key" for the PlayerPrefsX so we know which one to access

    //NOTE: the following 2 TODO's are not planned to be finished in Sprint #2
    //Future TODO: add a variable to store an image that represents the spinner on the Main Menu
    //Future TODO: add a vector to correctly display the image on the Main Menu

    public CustomSpinner() // Normal constructor to build new spinner objects
    {
        tmpActivities = new List<string>();
        savedActivities = new string[100]; // max size is 100
        Debug.Log("created new savedActivities");
    }

    public CustomSpinner(string storedTitle) // Overloaded constructor used to load the pre-existing spinners stored in PlayerPrefsX
    {
        title = storedTitle;
        for (int i = 0; i < PlayerPrefsX.GetStringArray(storedTitle).Length; ++i)
        {
            tmpActivities.Add(PlayerPrefsX.GetStringArray(storedTitle)[i]);
            Debug.Log("spinner with title: " + title + ", loaded activity at index " + i + ": " + tmpActivities[i]);
        }
        savedActivities = new string[100]; // Max size is 100
    }

    public string GetTitle()
    {
        return title;
    }

    public void SetTitle(string t)
    {
        title = t;
    }

    public void DeleteSpinner()
    {
        for (int i = 0; i < PlayerPrefsX.GetStringArray("storedSpinnerTitles").Length; ++i) // Cycles through the PlayerPrefsX that stores all of the titles
        {
            if (PlayerPrefsX.GetStringArray("storedSpinnerTitles")[i] == title) // Nullifies the title found in the PlayerPrefsX
            {
                PlayerPrefsX.GetStringArray("storedSpinnerTitles")[i] = null;
                Debug.Log("succesfully nullified title in title array");
                break;
            }
        }

        PlayerPrefsX.SetStringArray(title, null); // Nullifies the array stored with the given title keyword
        Debug.Log("succesfully nullified array in array array");
    }

    public void SaveSpinner() // Saves the spinner into a PlayerPrefsX array
    {
        // TODO: check to make sure the current title is not the same as any other saved titles

        // TODO: incorporate a button to make this method functional
        for (int i = 0; i < tmpActivities.Count; ++i) // Transfers the activities in the temporary List to the array that will be stored
        {
            savedActivities[i] = tmpActivities[i];
            Debug.Log("stored at index " + i + ": " + savedActivities[i]);
        }

        PlayerPrefsX.SetStringArray(title, savedActivities);
        tmpActivities.Clear();
    }

    public void EditSpinner()
    {
        // TODO: Load the data into the textfields in the boxes so that it can be edited
        // > Use title to load the data
    }

    public void AddToSpinner(string activity) // Adds a new activity to the tmp list
    {
        if (tmpActivities.Count <= 100) // checks to make sure the List is less than 100
        {
            tmpActivities.Add(activity);
            Debug.Log("added activity: " + activity);
        }
        // TODO: have an else-statement that will display a pop-up to the user that they have too many items

        Debug.Log("index: " + (tmpActivities.Count-1) + ", input: " + activity);
    }

    public void RemoveFromSpinner() // Removes an activity from the tmp List
    {
        // TODO: incorporate a button that indicates the index at which an activity needs to be removed
        // tmpActivities.RemoveAt("index")
        // Debug.Log("removed activity: " + activity);
    }
}