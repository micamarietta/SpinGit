using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomTextGenerator : MonoBehaviour
{
    public Text txt;
    List<string> genList = new List<string>(new string[]
    { "It's a feature, not a bug!",
        "A pocketful of decisions",
        "Spiiiiiiiiin",
        "Let's do things",
        "Decide my day!",
        "The pocket spinner",
        "The wheel of spontaneity",
        "Woah, I'm getting dizzy",
        "Way better than rock paper scissors",
        "Hi Prate!",
        "Wheel of Fortune has nothing on us",
    });

    // Start is called before the first frame update
    void Start()
    {
        string genText = genList[Random.Range(0, genList.Count - 1)];
        txt = gameObject.GetComponent<Text>();
        txt.text = genText;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
