using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICreateSpinner : MonoBehaviour
{
    public Canvas canvas;
    public Button createButton;

    public void CreateSpinnerButton()
    {
        canvas = canvas.GetComponent<Canvas>();
        createButton = createButton.GetComponent<Button>();

        ProfileManager.Instance.CreateSpinnerPM();
    }
}