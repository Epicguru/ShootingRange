using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ShootingTrigger : MonoBehaviour
{
    public UnityEvent ShootEvent = new UnityEvent();

    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ShootEvent.Invoke();
        }
    }
}