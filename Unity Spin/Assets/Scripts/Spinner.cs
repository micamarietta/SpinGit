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
    public bool activitiesEmpty; // Bool to check if the tmpActivities list is empty
    public bool titleEmpty; // Bool to check if the title is empty

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
        while (tmpActivities.Contains("")) // Removes all empty activities from the tmpActivities list
        {
            tmpActivities.Remove("");
        }

        if (tmpActivities.Count >= 1) // If there are activities in the spinner, then it can save
        {
            savedActivities = new string[tmpActivities.Count];

            for (int i = 0; i < tmpActivities.Count; ++i) // Transfers the activities in the temporary List to the array that will be stored
            {
                savedActivities[i] = tmpActivities[i];
            }
            
            activitiesEmpty = false;
        }
        else // If there are NO activities in the spinner, then it CANNOT save
        {
            activitiesEmpty = true;
        }
        
        if (title.Equals("")) // If the title is empty, then the spinner CANNOT save
        {
            titleEmpty = true;
        }
        else // If the title exists, then the spinner can save
        {
            titleEmpty = false;
        }

        if (!activitiesEmpty && !titleEmpty)
        {
            PlayerPrefsX.SetStringArray(title, savedActivities); // Stores spinner in string format to a PlayerPrefsX array with the title acting as the "key"
        }
        
    }

    public void DeleteSpinner() // Nullifies the PlayerPrefsX array and removes the spinner title from the storedTitles PlayerPrefsX array
    {
        PlayerPrefs.DeleteAll();
    }

    public void RemoveActivity(string remActivity) // Removes an activity fromn the tmp list
    {
        tmpActivities.Remove(remActivity);
    }

    public string GetRandomActivity()
    {
        return savedActivities[UnityEngine.Random.Range(0, savedActivities.Length)]; // Picks random index from 0 to tmpActivities.Count
    }
}