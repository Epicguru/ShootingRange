using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scope : MonoBehaviour
{
    public Camera Cam;
    public PlayerLookInput Look;
    public FlipFlop ScopeToggle;

    public KeyCode ZoomIn, ZoomOut;

    public float NormalFOV;
    public float[] ScopedFOV;
    public float[] ScopedSensitivity;
    public int ScopeLevel;

    public void Update()
    {
        if (Input.GetKeyDown(ZoomIn))
        {
            ScopeLevel++;
        }
        if (Input.GetKeyDown(ZoomOut))
        {
            ScopeLevel--;
        }

        ScopeLevel = Mathf.Clamp(ScopeLevel, 0, ScopedFOV.Length);

        ScopeToggle.Toggle = ScopeLevel != 0;

        int index = ScopeLevel - 1;

        if (ScopeLevel == 0)
        {
            Cam.fieldOfView = NormalFOV;
            Look.Sensitivity = 1f;
        }
        else
        {
            Cam.fieldOfView = ScopedFOV[index];
            Look.Sensitivity = ScopedSensitivity[index];
        }
    }
}