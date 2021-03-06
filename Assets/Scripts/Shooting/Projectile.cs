﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float Speed = 800f;

    public GameObject BulletHolePrefab;

    public float GravityScale = 1f;
    public List<Vector3> ExternalForces = new List<Vector3>();
    public float TrailStartTime;

    public LayerMask CollisionMask;

    public bool LogPath = true;

    private List<Vector3> pathPoints = new List<Vector3>();
    private bool hitObject;

    [SerializeField]
    [ReadOnly]
    private Vector3 ExternalVelocity;
    [SerializeField]
    [ReadOnly]
    private Vector3 InternalVelocity;
    private float timer;

    public void Start()
    {
        Destroy(gameObject, 20f);
        if (LogPath)
        {
            pathPoints.Add(transform.position);
        }
    }

    public void Update()
    {
        if (hitObject)
            return;

        if(timer > -1f)
            timer += Time.deltaTime;
        if(timer > TrailStartTime)
        {
            GetComponent<TrailRenderer>().enabled = true;
            timer = -1f;
        }

        ExternalVelocity += Physics.gravity * GravityScale * Time.deltaTime;

        for (int i = 0; i < ExternalForces.Count; i++)
        {
            ExternalVelocity += ExternalForces[i] * Time.deltaTime;
        }

        InternalVelocity = transform.forward * Speed;

        Vector3 oldPos = transform.position;
        Vector3 newPos = transform.position + (ExternalVelocity * Time.deltaTime) + (InternalVelocity * Time.deltaTime);
        transform.LookAt(newPos);

        if (RespondToCollision(oldPos, newPos))
        {
            // TEMP
            hitObject = true;
            Destroy(gameObject);
            return;
        }

        transform.position = newPos;

        if (LogPath)
        {
            pathPoints.Add(transform.position);
        }
    }

    public bool RespondToCollision(Vector3 oldPos, Vector3 newPos)
    {
        bool hit;
        RaycastHit hitInfo = DetectCollision(oldPos, newPos, out hit);

        if (hit)
        {
            transform.position = hitInfo.point;

            // Spawn particles.
            GameObject bulletHole = Instantiate(BulletHolePrefab);
            bulletHole.transform.position = hitInfo.point + hitInfo.normal * 0.01f;
            bulletHole.transform.LookAt(hitInfo.point + hitInfo.normal);
            Destroy(bulletHole, 30f);
            if (LogPath)
            {
                pathPoints.Add(transform.position);
            }
        }

        return hit;
    }

    public RaycastHit DetectCollision(Vector3 a, Vector3 b, out bool hit)
    {
        RaycastHit hitInfo;
        bool didHit = Physics.Linecast(a, b, out hitInfo, CollisionMask);

        if (didHit)
        {
            hit = true;
            return hitInfo;
        }
        else
        {
            hit = false;
            return new RaycastHit();
        }

    }

    public void OnDrawGizmos()
    {
        if (LogPath)
        {
            for (int i = 0; i < pathPoints.Count - 1; i++)
            {
                Vector3 x = pathPoints[i];
                Vector3 y = pathPoints[i + 1];
                bool colorA = i % 2 == 0;

                Gizmos.color = colorA ? Color.red : Color.green;
                Gizmos.DrawLine(x, y);
            }
        }
    }
}