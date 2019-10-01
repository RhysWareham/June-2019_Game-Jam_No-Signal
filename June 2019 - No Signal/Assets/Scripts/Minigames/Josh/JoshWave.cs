using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class JoshWave : MonoBehaviour
{

    private float moveSpeed = 2.5f;
    public static float frequency = 10.0f;  // Speed of sine movement
    public static float amplitude = 0.5f;   // Size of sine movement

    private Vector3 axis;
    private Vector3 pos;

    void Start()
    {
        pos = transform.position;
        Destroy(gameObject, 2.25f);
        axis = transform.up;
    }

    void Update()
    {
        pos += transform.right * Time.deltaTime * moveSpeed;
        transform.position = pos + axis * Mathf.Sin(Time.time * frequency) * amplitude;
    }
}

