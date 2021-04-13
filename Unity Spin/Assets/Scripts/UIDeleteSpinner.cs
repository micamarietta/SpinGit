using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIDeleteSpinner : MonoBehaviour
{
    public Button deleteButton;

    public void DeleteSpinnerButton()
    {
        ProfileManager.Instance.DeleteSpinnerPM();
    }
}