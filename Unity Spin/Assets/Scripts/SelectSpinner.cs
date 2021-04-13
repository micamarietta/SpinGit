using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectSpinner : MonoBehaviour
{
    public Button thisSpinnerButton;

    public void SelectSpinnerButton() // This is called upon clicking on the spinnerIcon prefab
    {
        ProfileManager.Instance.curSpinner = ProfileManager.Instance.activeSpinners[thisSpinnerButton.GetComponent<TrackIndex>().index];
    }
}
