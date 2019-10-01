using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlateScript : MonoBehaviour {

    private int[] order = new int[4] {1, 2, 3, 4};
    public int puzzlePos = 0;
    public int prevPuzzlePos;
    private int chosenTile = 0;

    [SerializeField]
    private GameObject success;

    public delegate void resetTiles();

    public static resetTiles tileReset;

	// Use this for initialization
	void Start () {
        prevPuzzlePos = puzzlePos;
	}
	
	// Update is called once per frame
	void Update () {

		
	}

    public void tilePressed(int tileNumber)
    {
        chosenTile = tileNumber;
        checkOrder();
    }

    private void checkOrder()
    {
        if (chosenTile != 0)
        {
            prevPuzzlePos = puzzlePos;
            if (order[puzzlePos] == chosenTile)
            {
                puzzlePos++;
                if (puzzlePos == 4)
                {
                    success.SetActive(false);
                    chosenTile = 0;
                    puzzlePos = 0;
                }
            }
            else if (order[puzzlePos] != chosenTile)
            {
                prevPuzzlePos = 0;
                puzzlePos = 0;
                tileReset();
            }
        }
        return;
    }
}
