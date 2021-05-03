using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UpdateScrollbar : MonoBehaviour
{
    public ScrollRect scrollrect;
    public Scene curScene;

    void Update() // Updates if the scrollbar is enabled or disabled
    {
        curScene = SceneManager.GetActiveScene();

        if (curScene.name == "MainScreen") // Updates the scrollbar on the Main Menu Screen
        {
            if (ProfileManager.Instance.activeSpinners.Count > 6) // If there's more than 6 spinners, the scrollbar is enabled
            {
                scrollrect.vertical = true; // Enables the scrollbar in the scrollrect
            }
            else // Otherwise the scrollbar is disabled
            {
                scrollrect.vertical = false; // Disables the scrollbar in the scrollrect
            }
        }
        else if (curScene.name == "CreateListScreen" || curScene.name == "EditListScreen") // Updates the scrollbar on the Create List Screen and Edit List screen
        {
            if (ProfileManager.Instance.curSpinner.tmpActivities.Count > 4) // If there's more than 4 activities, the scrollbar is enabled
            {
                scrollrect.vertical = true; // Enables the scrollbar in the scrollrect
            }
            else // Otherwise the scrollbar is disabled
            {
                scrollrect.vertical = false; // Disables the scrollbar in the scrollrect
            }
        }
    }
}