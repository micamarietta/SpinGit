using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LimitSpinners : MonoBehaviour
{
    public Button createSpinner; // The button to be disabled

    void Update()
    {
        if (ProfileManager.Instance.activeSpinners.Count >= 12) // If there are 12 or more spinners, disable the create spinner button
        {
            createSpinner.GetComponent<Button>().interactable = false;
        }
        else // If there are less than 12 spinners, enable the create spinner button
        {
            createSpinner.GetComponent<Button>().interactable = true;
        }
    }
}
