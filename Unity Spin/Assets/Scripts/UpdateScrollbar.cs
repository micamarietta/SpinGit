using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateScrollbar : MonoBehaviour
{
    public ScrollRect scrollrect;

    void Update() // Updates if the scrollbar is enabled or disabled
    {
        if (ProfileManager.Instance.activeSpinners.Count > 6)
        {
            scrollrect.enabled = true; // Enables the scrollrect
            scrollrect.GetComponentInChildren<Scrollbar>().interactable = true; // Enables the scrollbar
        }
        else
        {
            scrollrect.enabled = false; // Disables the scrollrect
            scrollrect.GetComponentInChildren<Scrollbar>().interactable = false; // Disables the scrollbar
        }
    }
}
