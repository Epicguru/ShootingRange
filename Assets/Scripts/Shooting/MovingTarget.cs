using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingTarget : MonoBehaviour
{
    public float Speed;
    public float Length;

    private bool Ping;

    public void Update()
    {
        if (Ping)
        {
            // Moving to the right.
            Vector3 pos = transform.localPosition;
            pos.x += Time.deltaTime * Speed;
            if (pos.x > Length)
            {
                Ping = false;
            }
            pos.x = Mathf.Clamp(pos.x, -Length, Length);
            transform.localPosition = pos;
        }
        else
        {
            // Moving to the left.
            Vector3 pos = transform.localPosition;
            pos.x -= Time.deltaTime * Speed;
            if (pos.x < -Length)
            {
                Ping = true;
            }
            pos.x = Mathf.Clamp(pos.x, -Length, Length);
            transform.localPosition = pos;
        }
    }
}