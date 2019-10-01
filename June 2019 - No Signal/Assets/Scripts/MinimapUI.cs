using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapUI : MonoBehaviour {

    [SerializeField]
    private Canvas uiObject;

    bool uiOpen = true;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.M))
        {
            ToggleUI();
        }

	}

    private void ToggleUI()
    {
        uiObject.gameObject.SetActive(!uiObject.gameObject.activeSelf);
    }
}
