using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SpinnerMechanics : MonoBehaviour
{

    //variables
    public Text DisplayActivity;
    public Text tapToExit;
    public GameObject textRecBackground;
    public List<string> ActivityList;

    //transparent rectangle object
    public Button transRectangle;

    // Start is called before the first frame update
    void Start()
    {
        //rectangles and text not visible at start
        textRecBackground.SetActive(false);
        transRectangle.gameObject.SetActive(false);
        CreateActivityList();
    }

    private void CreateActivityList()
    {
        ActivityList.Add("Take a hike");
        ActivityList.Add("Go for a jog");
        ActivityList.Add("Skip class (we don't condone this)");
        ActivityList.Add("Fail data structures (it's bound to happen)");
        ActivityList.Add("Do yoga");
        ActivityList.Add("Cry about your future");
        ActivityList.Add("Wonder what Erik looks like irl");
        ActivityList.Add("Tell Cole baseball is as boring as watching grass grow");
        ActivityList.Add("Grow some grass");
        ActivityList.Add("Learn to skate");
        ActivityList.Add("Watch a movie");
        ActivityList.Add("Find a new tv show");
        ActivityList.Add("Adopt a llama");
        ActivityList.Add("Learn tutnese");
        ActivityList.Add("Laugh nervously about your gpa");
        ActivityList.Add("Drink too much coffee");
        ActivityList.Add("Hidrate");
        ActivityList.Add("YOU Code an app that tells u what to do you ungrateful brat");
    }


    private string GetRandomActivity()
    {
        int randomIndex = Random.Range(0, ActivityList.Count); // picks random index from o to roster.count
        return ActivityList[randomIndex];
    }

    public void OnSpinButtonClick()
    {
        string randomActivity = GetRandomActivity();

        //display rectangles and text
        textRecBackground.SetActive(true);
        transRectangle.gameObject.SetActive(true);
        tapToExit.text = "Tap anywhere to exit";
        DisplayActivity.text = randomActivity;
    }

    //when the player clicks to exit out of their generated activity
    public void OnExitButtonClick()
    {
        textRecBackground.SetActive(false);
        transRectangle.gameObject.SetActive(false);
        DisplayActivity.text = " ";
        tapToExit.text = " ";
    }
}