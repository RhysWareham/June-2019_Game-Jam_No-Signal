using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VanOpenMap : MonoBehaviour {

    public GameObject mapUI;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if(mapUI != null)
            {
                collision.gameObject.GetComponent<PlayerMovement>().isPaused = true;
                mapUI.SetActive(true);
            }
        }
    }
}
