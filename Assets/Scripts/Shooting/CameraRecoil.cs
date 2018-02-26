using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRecoil : MonoBehaviour
{
    public Transform Horizontal;
    public Transform Vertical;

    public float OffX;
    public float OffY;

    public float RecoverySpeed;

    public void Shoot()
    {
        OffX -= Random.Range(-2f, 2f);
        OffY -= Random.Range(1, 3);
    }

    public void Update()
    {
        OffX = Mathf.Clamp(OffX, -50f, 50f);
        OffY = Mathf.Clamp(OffY, -70f, 70f);

        Horizontal.localEulerAngles = new Vector3(0f, OffX, 0f);
        Vertical.localEulerAngles = new Vector3(OffY, 0f, 0f);

        OffX = Mathf.Lerp(OffX, 0f, Time.deltaTime * RecoverySpeed);
        OffY = Mathf.Lerp(OffY, 0f, Time.deltaTime * RecoverySpeed);
    }
}