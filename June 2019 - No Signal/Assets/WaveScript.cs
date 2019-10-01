using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveScript : MonoBehaviour {

    [SerializeField]
    private AnimationCurve frequencyCurve;

    [SerializeField]
    private AnimationCurve amplitudeCurve;

    [SerializeField]
    private float xSpeed = 1;

    private void Start()
    {
        frequencyCurve.postWrapMode = WrapMode.Loop;
        amplitudeCurve.postWrapMode = WrapMode.Loop;
    }

    private void Update()
    {
        float t = Time.time;
        float amplitude = amplitudeCurve.Evaluate(t);
        float frequency = frequencyCurve.Evaluate(t);
        float phase = 0;
        float y = amplitude * Mathf.Sin(2 * Mathf.PI * frequency * t + phase);

        transform.position = Vector3.up * y + Vector3.right * xSpeed * t;
    }
}
