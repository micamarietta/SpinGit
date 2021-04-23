using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SpinController : MonoBehaviour
{
    // Spinning vars
    public float rotSpeed;
    public GameObject spinnerButton;

    // Display vars
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
        rotSpeed = 0.0f;
    }

    void Update()
    {
        spinnerButton.transform.Rotate(0, 0, rotSpeed);

        rotSpeed *= 0.96f;

        if (rotSpeed <= 0.01) // This is to actually stop the spinning of the spinner
        {
            rotSpeed = 0;
        }

        if (rotSpeed > 0) // While rotating, interacting with the button is set to false; otherwise, it's true
        {
            spinnerButton.GetComponent<Button>().interactable = false;
        }
        else // <= 0
        {
            spinnerButton.GetComponent<Button>().interactable = true;

            if (ProfileManager.Instance.spinnerActivated)
            {
                // Display rectangles and text
                textRecBackground.SetActive(true);
                transRectangle.gameObject.SetActive(true);
                tapToExit.text = "Tap anywhere to exit";

                // Displays a random activity from curSpinner
                DisplayActivity.text = ProfileManager.Instance.curSpinner.GetRandomActivity();
            }

            ProfileManager.Instance.spinnerActivated = false;
        }
    }

    public void SpinButton() // Called when the spinner button is clicked
    {
        rotSpeed = 20; // Sets the speed of the rotation
        ProfileManager.Instance.spinnerActivated = true; // Spinner is activated
    }

    public void ExitButton() // When the player clicks to exit out of their generated activity
    {
        textRecBackground.SetActive(false);
        transRectangle.gameObject.SetActive(false);
        DisplayActivity.text = " ";
        tapToExit.text = " ";
    }
}
