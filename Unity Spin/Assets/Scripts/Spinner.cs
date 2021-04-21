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
    public int gridPositionIndex; // The index of the spinner in the activeSpinners list

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
        }
    }

    public void SaveSpinner() // Stores the spinner into a PlayerPrefsX array
    {
        savedActivities = new string[tmpActivities.Count];

        for (int i = 0; i < tmpActivities.Count; ++i) // Transfers the activities in the temporary List to the array that will be stored
        {
            if (tmpActivities[i] != null)
            {
                savedActivities[i] = tmpActivities[i];
            }
        }

        PlayerPrefsX.SetStringArray(title, savedActivities); // Stores spinner in string format to a PlayerPrefsX array with the title acting as the "key"
    }

    public void DeleteSpinner() // Nullifies the PlayerPrefsX array and removes the spinner title from the storedTitles PlayerPrefsX array
    {
        PlayerPrefs.DeleteAll();
    }

    public void RemoveActivity(string tmpActivity) // Removes an activity fromn the tmp list
    {
        tmpActivities.Remove(tmpActivity);
    }

    public string GetRandomActivity()
    {
        return tmpActivities[UnityEngine.Random.Range(0, tmpActivities.Count)]; // Picks random index from 0 to tmpActivities.Count
    }
}