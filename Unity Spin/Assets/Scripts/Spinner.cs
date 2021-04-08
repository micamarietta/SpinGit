using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Spinner
{
    // The locations that PlayerPrefs are stored on iOS and Android: https://answers.unity.com/questions/131511/playerprefs-storage-location-on-android-or-ios.html

    public List<string> tmpActivities; // A temporary list of activities that the user can freely edit
    public string[] savedActivities; // The list of activities that will be stored on the closing of the app
    public string title; // The title of the spinner which will be used as a "key" for the PlayerPrefsX array
    public int gridPositionIndex;
    public int posX;
    public int posY;

    public Spinner() // Default Constructor used for the creation of a new spinner
    {
        tmpActivities = new List<string>();
        title = "";
    }

    public Spinner(string storedTitle) // Overloaded Constructor used to load stored spinners from PlayerPrefsX
    {
        tmpActivities = new List<string>();
        title = storedTitle;

        foreach (string activity in PlayerPrefsX.GetStringArray(title)) // Takes each activity from the PlayerPrefsX array and appends it to the tmpActivities List
        {
            tmpActivities.Add(activity);
            Debug.Log("loaded '" + activity + "' at index " + (tmpActivities.Count - 1));
        }
        Debug.Log("succesfully loaded spinner using overloaded constructor, title: " + title);
    }

    public void SaveSpinner() // Stores the spinner into a PlayerPrefsX array
    {
        savedActivities = new string[tmpActivities.Count];

        for (int i = 0; i < tmpActivities.Count; ++i) // Transfers the activities in the temporary List to the array that will be stored
        {
            savedActivities[i] = tmpActivities[i];
        }

        for (int i = 0; i < savedActivities.Length; ++i)
        {
            Debug.Log("In SaveSpinner(): savedActivities[" + i + "] = " + savedActivities[i]);
        }

        PlayerPrefsX.SetStringArray(title, savedActivities); // Stores spinner in string format to a PlayerPrefsX array with the title acting as the "key"

        /*
        for (int i = 0; i < PlayerPrefsX.GetStringArray(title).Length; ++i)
        {
            Debug.Log("'" + PlayerPrefsX.GetStringArray(title)[i] + "' saved at index " + i + " with the title: " + title);
        }
        */
    }

    public void DeleteSpinner() // Nullifies the PlayerPrefsX array and removes the spinner title from the storedTitles PlayerPrefsX array
    {
        PlayerPrefsX.SetStringArray(title, null); // Nullifies the array stored with the given title keyword
        Debug.Log("succesfully nullified array in array array");

        for (int i = 0; i < PlayerPrefsX.GetStringArray("storedTitles").Length; ++i) // Cycles through the PlayerPrefsX that stores all of the titles
        {
            if (PlayerPrefsX.GetStringArray("storedSpinnerTitles")[i] == title) // Nullifies the title found in the PlayerPrefsX
            {
                PlayerPrefsX.GetStringArray("storedSpinnerTitles")[i] = null;
                Debug.Log("succesfully nullified title in title array");
                break;
            }
        }
    }

    public void EditSpinner() // Brings up the CreateNewSpinner Scene but has the loaded data
    {
        // How this may work...
        // 1) Pass in the UI property ("scrollable table" or whatever Pablo said it was called)
        // 2) Fill it in with the tmpActivities List
        // 3) Return it back into ProfileManager.cs
    }

    public void AddActivity(string activity) // Adds a new activity to the tmp list
    {
        tmpActivities.Add(activity);
    }

    public void RemoveActivity(int index) // Removes an activity fromn the tmp list
    {
        tmpActivities.RemoveAt(index); // index - 1???
    }

    public void EditActivity(int index, string activity)
    {
        tmpActivities[index] = activity;
    }

    public string GetRandomActivity()
    {
        return tmpActivities[UnityEngine.Random.Range(0, tmpActivities.Count)]; // Picks random index from 0 to tmpActivities.Count
    }
}
