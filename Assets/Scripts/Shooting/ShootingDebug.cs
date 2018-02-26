using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingDebug : MonoBehaviour
{
    public void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawRay(transform.position, transform.forward * 1000f);
    }
}