using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileCollisionScript : MonoBehaviour {

    [SerializeField]
    private int tileNumber;
    [SerializeField]
    private PressurePlateScript puzzle;
    [SerializeField]
    private GameObject tileOff;
    [SerializeField]
    private GameObject tileOn;
    [SerializeField]
    private AudioSource tileClicked;
    [SerializeField]
    private AudioSource tileUnclicked;
    //[SerializeField]
    //private Material red;
    //[SerializeField]
    //private Material green;
    //[SerializeField]
    //private Material white;


    // Use this for initialization
    void Start () {
        PressurePlateScript.tileReset += localTileReset;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        puzzle.tilePressed(tileNumber);
        if(puzzle.prevPuzzlePos < puzzle.puzzlePos)
        {
            tileOff.SetActive(false);
            tileOn.SetActive(true);
            tileClicked.PlayOneShot(tileClicked.clip);
        }
        else
        {
            tileUnclicked.PlayOneShot(tileUnclicked.clip);

        }
    }


    private void localTileReset()
    {
        tileOff.SetActive(true);
        tileOn.SetActive(false);
    }
}
