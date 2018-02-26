using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceMarker : MonoBehaviour
{
    public Transform DistanceTo;
    public TextMesh Text;

    public void Start()
    {
        if (DistanceTo == null)
        {
            DistanceTo = Camera.main.transform;
        }
    }

    public void Update()
    {
        float dst = Vector3.Distance(transform.position, DistanceTo.position);
        int distance = (int)dst;

        Text.text = distance + "m";

        Text.transform.LookAt(DistanceTo);
        Text.transform.Rotate(0f, 180f, 0f);
    }
}