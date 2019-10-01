using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveFrequencyScript : MonoBehaviour {

    public LineRenderer lineRenderer;
    public Transform point0;
    public Transform point1;

    private int numPoints = 50;
    private Vector3[] positions = new Vector3[50];
    
    // Use this for initialization
	void Start () {
        //lineRenderer.SetVertexCount(numPoints);
        lineRenderer.positionCount = numPoints;
        DrawLinearCurve();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void DrawLinearCurve()
    {
        for (int i = 1; i < numPoints + 1; i++)
        {
            float t = i / (float)numPoints;
            positions[i - 1] = CalculateLinearBezierPoint(t, point0.position, point1.position);
        }
        lineRenderer.SetPositions(positions);
    }

    private Vector3 CalculateLinearBezierPoint(float t, Vector3 returnP0, Vector3 returnP1)
    {
        return returnP0 + t * (returnP1 - returnP0);
    }

    private Vector3 CalculateQuadraticBezierPoint(float t, Vector3 returnP0, Vector3 returnP1, Vector3 returnP2)
    {
        //return 
        float u = 1 - t;
        return returnP2;
    }
}
