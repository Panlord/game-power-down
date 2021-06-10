// Created by Peter Lin.
// Make the brightness meter STICK TO THE FLASHLIGHT.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClampMeter : MonoBehaviour
{
    public GameObject BrightnessMeter;

    void Update()
    {
        var flashlightPos = Camera.main.WorldToScreenPoint(this.transform.position);

        var meterPos = flashlightPos;
        this.BrightnessMeter.transform.position = meterPos;
    }
}