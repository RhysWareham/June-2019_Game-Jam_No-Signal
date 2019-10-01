using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbientSoundsController : MonoBehaviour
{
    [SerializeField]
    private AudioSource heavyBreathing;

    [SerializeField]
    private GameObject goal;

	// Update is called once per frame
	void Update ()
    {
		if(!goal.activeSelf)
        {
            heavyBreathing.loop = true;
            heavyBreathing.PlayOneShot(heavyBreathing.clip);
        }
	}
}
