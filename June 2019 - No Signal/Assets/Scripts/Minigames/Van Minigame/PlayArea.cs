using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayArea : MonoBehaviour
{
    [SerializeField]
    private GameObject obstacle;

    private float spawnDelay = 1.0f;
	
	// Update is called once per frame
	void Update ()
    {
        spawnDelay -= Time.deltaTime;

        if(spawnDelay <= 0.0f)
        {
            Instantiate(obstacle, new Vector3(9.5f, -2.0f, 0.0f), new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));
            spawnDelay = 2.0f;
        }
	}
}
