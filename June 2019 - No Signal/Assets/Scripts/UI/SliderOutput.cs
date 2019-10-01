using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderOutput : MonoBehaviour {

    [SerializeField]
    private Text UIText;

    public void UpdateValue(float value)
    {
        UIText.text = Math.Round(value,2).ToString() + " MHz";
    }
}
