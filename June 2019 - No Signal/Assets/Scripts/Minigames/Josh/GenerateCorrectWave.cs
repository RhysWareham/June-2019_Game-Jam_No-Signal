using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GenerateCorrectWave : MonoBehaviour
{

    [SerializeField] private GameObject SinWave;
    [SerializeField] private Vector3 WaveStartPosition;
    private float timeToWait = 2.25f;
    int currentInt = 0;

    // Use this for initialization
    void Start()
    {
        StartCoroutine(LoopFunction(timeToWait));

    }

    private IEnumerator LoopFunction(float waitTime)
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime);
            Instantiate(SinWave, WaveStartPosition, Quaternion.identity);
        }
    }
}
