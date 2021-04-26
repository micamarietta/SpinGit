using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICreateSpinner : MonoBehaviour
{
    public Button createButton;

    public void CreateSpinnerButton() // Calls the profile manager to create a new spinner
    {
        ProfileManager.Instance.CreateSpinnerPM();
    }
}