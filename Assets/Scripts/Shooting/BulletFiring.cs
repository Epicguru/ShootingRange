using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFiring : MonoBehaviour {

    public GameObject Prefab;
    public float Speed = 500f;

    public void Shoot()
    {
        SpawnBullet(Speed);
    }

	public void SpawnBullet(float speed)
    {
        Projectile p = Instantiate(Prefab, transform.position, transform.rotation).GetComponent<Projectile>();
        p.Speed = speed;
    }
}
