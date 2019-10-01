using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialLevelScript : MonoBehaviour {

    [SerializeField]
    private PlayerMovement player;

    [SerializeField]
    private TextMesh text;

    [SerializeField]
    private GameObject textBox;

    private string[] textArray = new string[3]
    {
        "OH  YIKES!\nA  UFO!",
        "Well, time\nto  track  it!",
        "Click  LMB  to\nturn  on  \ntracker"

    };
    private int textNum = 0;

	// Use this for initialization
	void Start () {
        text.text = textArray[0];
	}
	
	// Update is called once per frame
	void Update () {
        

        if(player.clickCount < textArray.Length)
        {
            DisplayText();
            //textNum++;
        }
        else
        {
            text.text = "";
            textBox.SetActive(false);
        }
    }

    private void DisplayText()
    {
        text.text = textArray[player.clickCount];
        //textNum++;
    }

}
