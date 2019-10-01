using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

    //[SerializeField]
    private Transform player;

    private void Start()
    {
        player = GameObject.Find("PlayerCharacter").GetComponent<Transform>();
    }

    void FixedUpdate () {
        transform.position = new Vector3(player.position.x, player.position.y, -10);
	}
}
