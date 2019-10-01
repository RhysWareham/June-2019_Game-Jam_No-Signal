using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField]
    private float speed = 5.0f;

	void Update ()
    {
        this.transform.position = new Vector2(this.transform.position.x - (speed * Time.deltaTime), this.transform.position.y);
	}
}
