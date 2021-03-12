using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CustomList : MonoBehaviour
{
    // source of original code which i am modifying: https://answers.unity.com/questions/1101002/adding-a-new-string-to-my-array-after-each-button.html
    public Button addActivity;
    public Canvas canvas;
    public InputField activity;
    public string[] activityList; // can be changed to be a fixed size array later on
    int index = 0;
    public void Start()
    {
        addActivity = addActivity.GetComponent<Button>();
        canvas = canvas.GetComponent<Canvas>();
        activity = activity.GetComponent<InputField>();
        activityList = new string[100]; // max size is 100
    }
    public void AddToSpinner()
    {
        // with each click of button, the input is added to the array
        activityList[index] = activity.text; // adds text from input field to our array's index
        Debug.Log("index: " + index + ", input: " + activity.text);
        if (index != 99)
        {
            index += 1;
        }
    }
    public void OnButtonClick()
    {
        AddToSpinner();
    }
}