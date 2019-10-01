using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndText : MonoBehaviour {

    [SerializeField]
    private PlayerMovement player;

    [SerializeField]
    private TextMesh text;

    [SerializeField]
    private GameObject textBox;

    private string[] textArray = new string[]
    {
        "Wait I'm \nhere again",
        "Maybe I'm ...",
        "Stuck in a\n loop!!", 

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
