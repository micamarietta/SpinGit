using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadSpinnerIcons : MonoBehaviour
{
    public Transform container;
    public Scene curScene;

    void Update()
    {
        curScene = SceneManager.GetActiveScene();

        // If we're on the main menu screen and the spinners are not displayed, we need to display them
        if (curScene.name == "MainScreen" && !ProfileManager.Instance.spinnersDisplayed)
        {
            for (int i = 0; i < ProfileManager.Instance.activeSpinners.Count; ++i)
            {
                GameObject clonedSpinnerIcon = Instantiate(Resources.Load("Prefabs/spinnerIcon")) as GameObject; // Instantiates the spinnerIcon prefab
                clonedSpinnerIcon.transform.SetParent(container.transform); // Places this new prefab within the contain heirarchy
                clonedSpinnerIcon.transform.GetComponentInChildren<Text>().text = ProfileManager.Instance.activeSpinners[i].title; // Sets the text of the new button prefab
                clonedSpinnerIcon.transform.GetChild(0).GetComponent<TrackIndex>().index = i;
            }

            ProfileManager.Instance.spinnersDisplayed = true; // The spinners are now displayed
        }
    }
}
