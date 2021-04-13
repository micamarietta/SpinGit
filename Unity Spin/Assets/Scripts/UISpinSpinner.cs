using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISpinSpinner : MonoBehaviour
{
    // Variables
    public Text DisplayActivity;
    public Text tapToExit;
    public GameObject textRecBackground;

    // Transparent rectangle object
    public Button transRectangle;

    // Start is called before the first frame update
    void Start()
    {
        // Rectangles and text not visible at start
        textRecBackground.SetActive(false);
        transRectangle.gameObject.SetActive(false);
    }

    public IEnumerator OnSpinButtonClickDelay()
    {
        // Display rectangles and text
        yield return new WaitForSeconds(2); // New line
        textRecBackground.SetActive(true);
        transRectangle.gameObject.SetActive(true);
        tapToExit.text = "Tap anywhere to exit";

        // Displays a random activity from curSpinner
        DisplayActivity.text = ProfileManager.Instance.curSpinner.GetRandomActivity();
    }

    public void OnSpinButtonClick()
    {
        StartCoroutine(OnSpinButtonClickDelay());
    }

    public void OnExitButtonClick() // When the player clicks to exit out of their generated activity
    {
        textRecBackground.SetActive(false);
        transRectangle.gameObject.SetActive(false);
        DisplayActivity.text = " ";
        tapToExit.text = " ";
    }
}
